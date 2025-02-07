
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
			if (word.Length < 2)
			{
				throw new NotFoundException("Word need to have more than 2 characters");
			}
				return _towns;
		
		}
	}
}


