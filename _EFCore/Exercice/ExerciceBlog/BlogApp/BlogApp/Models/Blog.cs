using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Models
{
	internal class Blog
	{
		public int Id { get; set; }
		public string Name { get; set; } = null;
		public string Url { get; set; } = null;

		public List<Post> Posts { get; set; } = new List<Post>();
	}
}
