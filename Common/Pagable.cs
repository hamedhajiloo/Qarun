using System.Collections.Generic;

namespace Common
{
    public class Pagable
    {
        /// <summary>
        /// صفحه
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// تعداد در هر صفحه
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// فیلد مرتب سازی
        /// </summary>
        public List<string> Order { get; set; } = null;

        /// <summary>
        /// نزولی
        /// </summary>
        public bool Desc { get; set; } = true;

        /// <summary>
        /// جستجو
        /// </summary>
        public string Search { get; set; } = "";
    }
}
