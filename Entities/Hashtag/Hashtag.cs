using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Hashtag:BaseEntity<long>
    {
        public string Key { get; set; }

        public virtual ICollection<ProductHashtag> ProductHashtags { get; set; }

    }
}
