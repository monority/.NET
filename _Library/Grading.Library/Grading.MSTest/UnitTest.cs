
using Grading.Library;

namespace Demo01.Tests;

[TestClass]
public sealed class GradingTest
{
	private GradingCalculator? _gCalculator;

	[TestInitialize]
	public void SetUp()
	{
		_gCalculator = new GradingCalculator();
	}

	[TestCleanup]
	public void TearDown()
	{
		_gCalculator = null;
	}

	[TestMethod]
	[DataRow(95, 90, 'A')]
	[DataRow(85, 90, 'B')]
	[DataRow(65, 90, 'C')]
	[DataRow(95, 65, 'B')]
	[DataRow(95, 55, 'F')]
	[DataRow(65, 55, 'F')]
	[DataRow(50, 90, 'F')]
	public void GetGrade_ValidInputs_ReturnsExpectedGrade(int score, int attendance, char expectedGrade)
	{
		Assert.IsNotNull(_gCalculator);
		var result = _gCalculator!.GetGrade(score, attendance);
		Assert.AreEqual(expectedGrade, result);
	}
}

