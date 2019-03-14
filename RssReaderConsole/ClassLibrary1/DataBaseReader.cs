using System.Collections.Generic;

using DataLayer;

namespace Services
{
    public class DataBaseReader
    {
        public IReadOnlyCollection<DataLayer.Model.PieceOfNews> ReadHabrNews()
        {
            var converter = new PieceOfNewsConverter();
            var dataBase = new DataBase();

            return dataBase.ReadHabrNews();
        }

        public IReadOnlyCollection<DataLayer.Model.PieceOfNews> ReadInterfaxNews()
        {
            var converter = new PieceOfNewsConverter();
            var dataBase = new DataBase();

            return dataBase.ReadInterfaxNews();
        }

        public IReadOnlyCollection<DataLayer.Model.PieceOfNews> ReadAllNews()
        {
            var converter = new PieceOfNewsConverter();
            var dataBase = new DataBase();

            return dataBase.ReadAllNews();
        }
    }
}
