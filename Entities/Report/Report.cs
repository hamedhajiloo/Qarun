using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Report:BaseEntity<long>
    {
        /// <summary>
        /// ریپورت کننده
        /// </summary>
        [ForeignKey(nameof(ReporterUser))]
        public string ReporterUserId { get; set; }
        public virtual User ReporterUser { get; set; }



        /// <summary>
        /// ریپورت شونده
        /// </summary>
        [ForeignKey(nameof(ReportedUser))]
        public string ReportedUserId { get; set; }
        public virtual User ReportedUser { get; set; }

    }
}
