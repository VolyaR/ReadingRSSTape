using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using DataLayer.Model;

namespace DataLayer
{
    public class NewsContext : DbContext
    {
        public NewsContext() : base("DbConnection")
        {
        }

        public DbSet<PieceOfNewsDb> PieceOfNews { get; set; }

    }

    public class DataBase
    {
        public static IReadOnlyCollection<PieceOfNewsDb> _listOfNews;

        public DataBase(IReadOnlyCollection<PieceOfNewsDb> listOfNews)
        {
            _listOfNews = listOfNews ?? throw new ArgumentNullException(nameof(listOfNews));
        }

        public void Create()
        {
            using (NewsContext db = new NewsContext())
            {
                foreach(var pieceOfNews in _listOfNews)
                {
                    db.PieceOfNews.Add(pieceOfNews);
                }
            }
        }

        public IReadOnlyCollection<PieceOfNewsDb> ReadHabrNews()
        {
            const string partOfHabrNewsId = "https://habr.com/";
            return ReadSpetialNews(partOfHabrNewsId);
        }

        public IReadOnlyCollection<PieceOfNewsDb> ReadInterfaxNews()
        {
            const string partOfInterfaxNewsId = "https://www.interfax.by/";
            return ReadSpetialNews(partOfInterfaxNewsId);
        }

        public IReadOnlyCollection<PieceOfNewsDb> ReadAllNews()
        {
            var news = new List<PieceOfNewsDb>();
            using (NewsContext db = new NewsContext())
            {
                foreach (var piece in db.PieceOfNews)
                {
                    news.Add(piece);
                }
            }

            return news.AsReadOnly();
        }

        private IReadOnlyCollection<PieceOfNewsDb> ReadSpetialNews(string partOfNewsId)
        {
            IReadOnlyCollection<PieceOfNewsDb> news = ReadAllNews();

            return news
                .Where(x => x.Id.Contains(partOfNewsId))
                .Select(x => x)
                .ToList();
        }
    }
}
