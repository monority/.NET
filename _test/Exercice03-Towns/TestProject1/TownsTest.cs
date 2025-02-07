namespace TestProject1;
using Towns.Library;
public class TownsTest
{
	List<string> towns = new List<string>()
		{
			"Paris", "Budapest", "Skopje", "Rotterdam", "Valence", "Vancouver", "Amsterdam", "Vienne", "Sydney", "New York", "Londres", "Bangkok", "Hong Kong", "Dubaï", "Rome", "Istanbul"
		};
	[Fact]
	public void CountChar_LessThan2()
	{
		var ts = new SearchTown(towns);

		Assert.Throws<NotFoundException>(() => ts.Search("z"));
	}
	[Fact]
	public void Word_EqualOrSuperior_2_Return_AllTowns_StartingWithWord()
	{
		var ts = new SearchTown(towns);
		var result = ts.Search("Va");
		var expected = new List<string> { "Valence", "Vancouver" };
		Assert.Equal(expected, result);
	}
	[Fact]
		public void Search_Not_CaseSensitive()
	{
		var ts = new SearchTown(towns);
		var result = ts.Search("va");
		var expected = new List<string> { "Valence", "Vancouver" };
		Assert.Equal(expected, result);
	}
}
