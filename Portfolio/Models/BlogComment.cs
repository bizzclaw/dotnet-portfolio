using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Models
{
    [Table(DbTable)]
    public class BlogComment
    {
        public const string DbTable = "blogcomment";

        private string _text;
        private string _contactInfo;
        private string _author;

        [Key]
        public int Id { get; set; }
        public int BlogPostId { get; set; }
        public string ContactInfo { get; set; }
        public string Text {
            get => _text;
            set => _text = value.Length > 255 ? value.Substring(0, 255) : value;
        }
        public string Contact {
            get => _contactInfo;
            set => _contactInfo = value.Length > 255 ? value.Substring(0, 255) : value;
        }
        public string Author {
            get => _author;
            set => _author = value.Length > 40 ? value.Substring(0, 40) : value;
        }

    }
}
