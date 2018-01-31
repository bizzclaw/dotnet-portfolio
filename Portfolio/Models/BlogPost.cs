using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Portfolio.Models
{
    [Table(DbTable)]
    public class BlogPost
    {
        public const string DbTable = "blogposts";

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        [Column(TypeName = "text")]
        public string Body { get; set; }

        public void TimeStamp()
        {
            Date = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public string PartialBody(int maxLength = 40)
        {
            if (Body == null)
            {
                return "--";
            }
            return Body.Substring(0, Math.Min(maxLength, Body.Length));
        }
    }
}
