using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Baner
{
    public class Baner:BaseEntity<int>
    {
        public string Title { get; set; }

        public string Picture { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndTime { get; set; }

        public string Link { get; set; }

    }
}
