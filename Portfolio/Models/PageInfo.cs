using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Portfolio.Models
{
    [Table(DbTable)]
    public class PageInfo
    {
        public const string DbTable = "pageinfo";
        public string Title { get; set; }
        [Column(TypeName = "ntext")]
        public string MainInfo { get; set; }
    }
}
