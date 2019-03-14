using System;
using System.Collections.Generic;
using System.Linq;

using DataLayer.Model;

namespace DataLayer
{
    public class DataBase
    {
        const string PartOfHabrNewsId = "https://habr.com/";
        const string PartOfInterfaxNewsId = "https://www.interfax.by/";

        public static IReadOnlyCollection<PieceOfNews> _listOfNews;

        public DataBase()
        {
        }

        public DataBase(IReadOnlyCollection<PieceOfNews> listOfNews)
        {
            _listOfNews = listOfNews ?? throw new ArgumentNullException(nameof(listOfNews));
        }

        public int CreateNewRecordsAndReturnItsCounter()
        {
            int counter = 0;
            using (NewsContext db = new NewsContext())
            {
                foreach (var pieceOfNews in _listOfNews)
                {
                    // Сравниваю по Id т.к. это более надежный способ.
                    // В процессе разработки появился баг:
                    // Ранее в базу записалась новость с title "Первый релиз открытЫго инструмента для тестирования поиска по продуктам"
                    // В то время, как мы пытались записать "Первый релиз открытОго инструмента для тестирования поиска по продуктам"
                    // Т.е. Заголовки разные, а Ids одинаковые, на этапе сохранения данных приложение падало с ошибкой
                    PieceOfNews pieceOfNewsFromDb = db.PieceOfNews
                        .FirstOrDefault(x => x.Id == pieceOfNews.Id);

                    if (pieceOfNewsFromDb == null)
                    {
                        db.PieceOfNews.Add(pieceOfNews);
                        counter++;
                    }
                }

                db.SaveChanges();
            }

            return counter;
        }

        public IReadOnlyCollection<PieceOfNews> ReadAllNews()
        {
            IReadOnlyCollection<PieceOfNews> news;
            using (NewsContext db = new NewsContext())
            {
                news = db.PieceOfNews.ToList();
            }

            return news;
        }

        public IReadOnlyCollection<PieceOfNews> ReadHabrNews()
        {
            return ReadSpetialNews(PartOfHabrNewsId);
        }

        public IReadOnlyCollection<PieceOfNews> ReadInterfaxNews()
        {
            return ReadSpetialNews(PartOfInterfaxNewsId);
        }

        private IReadOnlyCollection<PieceOfNews> ReadSpetialNews(string partOfNewsId)
        {
            IReadOnlyCollection<PieceOfNews> news = ReadAllNews();

            return news
                .Where(x => x.Id.Contains(partOfNewsId))
                .Select(x => x)
                .ToList();
        }
    }
}
