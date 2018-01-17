﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicAuthentication.Models
{
	[Table("Answers")]
	public class Answers
	{
		[Key]
		public int Id { get; set; }
		public string Description { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int QuestionId { get; set; }
		public virtual Question Question { get; set; }
	}
}
