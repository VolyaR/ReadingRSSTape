using System;
using System.Collections.Generic;

namespace Services
{
    public class PieceOfNews
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public List<string> Categories { get; set; }

        public DateTimeOffset PublishDate { get; set; }
    }
}
