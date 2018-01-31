using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    [Table(DbTable)]
    public class PageInfo
    {
        [Key]
        public int Id { get; set; }
        public const string DbTable = "pageinfo";
        public string Name { get; set; }
        public string Title { get; set; }
        [Column(TypeName = "text")]
        public string MainInfo { get; set; }

        [NotMapped]
        public List<Project> Projects;
    }
}
