using System;
using System.Collections.Generic;

namespace DataLayer.Model
{
    public class PieceOfNewsDb
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public List<string> Categories { get; set; }

        public DateTimeOffset PublishDate { get; set; }
    }
}
