using System;

namespace Services
{
    public sealed class PieceOfNewsConverter
    {
        public DataLayer.Model.PieceOfNews ToPieceOfNewsDb(PieceOfNews pieceOfNews)
        {
            if (pieceOfNews == null)
            {
                throw new ArgumentNullException(nameof(pieceOfNews));
            }

            return new DataLayer.Model.PieceOfNews
            {
                Id = pieceOfNews.Id,
                Title = pieceOfNews.Title,
                Summary = pieceOfNews.Summary,
                PublishDate = pieceOfNews.PublishDate
            };
        }
    }
}
