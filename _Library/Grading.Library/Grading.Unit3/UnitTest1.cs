using Grading.Library;

namespace Demo01.TestsNUnit;

[TestFixture]
public sealed class GradingTest
{
	private GradingCalculator? _gCalculator;


	[SetUp] // s'exécutera AVANT CHAQUE TEST
	public void SetUp()
	{
		_gCalculator = new GradingCalculator();
	}

	[TearDown]
	public void TearDown()
	{
		_gCalculator = null;
	}
		
	[Theory]
	[TestCase(95, 90, 'A')]
	[TestCase(85, 90, 'B')]
	[TestCase(65, 90, 'C')]
	[TestCase(95, 65, 'B')]
	[TestCase(95, 55, 'F')]
	[TestCase(65, 55, 'F')]
	[TestCase(50, 90, 'F')]
	public void GetGrade_ValidInputs_ReturnsExpectedGrade(int score, int attendance, char expectedGrade)
	{
		Assert.IsNotNull(_gCalculator);
		var result = _gCalculator!.GetGrade(score, attendance);
		Assert.AreEqual(expectedGrade, result);
	}
}
