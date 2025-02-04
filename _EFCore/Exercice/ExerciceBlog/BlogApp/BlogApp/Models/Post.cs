using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Models
{
	internal class Post
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public DateTime DatePublication { get; set; } = DateTime.Now;

		public Blog Blog { get; set; }	
	}
}
