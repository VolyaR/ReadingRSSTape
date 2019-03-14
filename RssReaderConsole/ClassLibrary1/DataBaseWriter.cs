using System.Collections.Generic;
using System.Linq;

using DataLayer;

namespace Services
{
    public class DataBaseWriter
    {
        public int WriteToDataBaseAndReturnCounter()
        {
            var reader = new NewsReader();
            List<PieceOfNews> habrNews = reader.GetNewsFromHabr();
            List<PieceOfNews> interfaxNews = reader.GetNewsFromInterfax();
            var allNews = habrNews.Concat(interfaxNews);

            var converter = new PieceOfNewsConverter();
            List<DataLayer.Model.PieceOfNews> newModel = allNews
                .Select(x => converter.ToPieceOfNewsDb(x)).
                ToList();

            var dataBase = new DataBase(newModel);
            var recordCounter = dataBase.CreateNewRecordsAndReturnItsCounter();

            return recordCounter;
        }
    }
}
