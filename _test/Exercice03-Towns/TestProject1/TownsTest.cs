namespace TestProject1;
using Towns.Library;
public class TownsTest
{
	[Fact]
	public void CountChar_LessThan2()
	{
		List<string> towns = new List<string>()
		{
			"Paris", "Budapest", "Skopje", "Rotterdam", "Valence", "Vancouver", "Amsterdam", "Vienne", "Sydney", "New York", "Londres", "Bangkok", "Hong Kong", "Dubaï", "Rome", "Istanbul"
		};
		var ts = new SearchTown(towns);
		Assert.Throws<NotFoundException>(() => ts.Search("z"));
	}
}
