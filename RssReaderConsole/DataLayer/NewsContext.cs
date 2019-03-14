using System.Data.Entity;

using DataLayer.Model;

namespace DataLayer
{
    public class NewsContext : DbContext
    {
        public NewsContext() : base("NewsDBConnection")
        {
        }

        public DbSet<PieceOfNews> PieceOfNews { get; set; }
    }
}
