using Portfolio.Models;
using System.Linq;

namespace Portfolio.ViewModels
{
	public class BlogCommentListViewModel
	{
		public BlogPost BlogPost { get; set; }
		public IQueryable<BlogComment> BlogCommentList { get; set; }
	}
}
