using System;

namespace Services
{
    public class PieceOfNews
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public DateTimeOffset PublishDate { get; set; }
    }
}
