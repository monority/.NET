
using System.Security.Cryptography.X509Certificates;
using Towns.Library;

namespace Towns.Library
{
	public class SearchTown
	{
		private List<string> _towns;
		public SearchTown(List<string> towns)
		{
			_towns = towns;
		}

		public List<string> Search(string word)
		{
			if (word == "*")
			{
				return _towns.ToList();
			}
			else if (word.Length < 2)
			{
				throw new NotFoundException("Word need to have more than 2 characters");
			}
			else { return _towns.FindAll(x => x.StartsWith(word, StringComparison.OrdinalIgnoreCase) || x.Contains(word)).ToList(); }

		}
	}
}


