using Grading.Library;

namespace Demo01.TestsXUnit
{
	public sealed class GradingCalculatorTest : IDisposable
	{
		private GradingCalculator? _gCalculator;

		public GradingCalculatorTest()
		{
			_gCalculator = new GradingCalculator();
		}

		public void Dispose()
		{
			_gCalculator = null;
		}


		[Fact]
		public void Score95_Presence90_NoteA()
		{

			var result = _gCalculator.GetGrade(95,90);

			Assert.Equal('A', result);
		}
		[Fact]
		public void Score85_Presence90_NoteB()
		{

			var result = _gCalculator.GetGrade(85, 90);

			Assert.Equal('B', result);
		}
		[Fact]
		public void Score65_Presence90_NoteC()
		{

			var result = _gCalculator.GetGrade(65, 90);

			Assert.Equal('C', result);
		}
		[Fact]
		public void Score95_Presence65_NoteB()
		{

			var result = _gCalculator.GetGrade(95, 65);

			Assert.Equal('B', result);
		}
		[Fact]
		public void Score95_Presence55_NoteF()
		{

			var result = _gCalculator.GetGrade(95, 55);

			Assert.Equal('F', result);
		}
		[Fact]
		public void Score65_Presence55_NoteF()
		{

			var result = _gCalculator.GetGrade(65, 55);

			Assert.Equal('F', result);
		}
		[Fact]
		public void Score50_Presence90_NoteF()
		{

			var result = _gCalculator.GetGrade(50, 90);

			Assert.Equal('F', result);
		}
		[Theory]
		[InlineData(95, 90, 'A')]
		[InlineData(85, 90, 'B')]
		[InlineData(65, 90, 'C')]
		[InlineData(95, 65, 'B')]
		[InlineData(95, 55, 'F')]
		[InlineData(65, 55, 'F')]
		[InlineData(50, 90, 'F')]
		public void GetGrade_ValidInputs_ReturnsExpectedGrade(int score, int attendance, char expectedGrade)
		{
			var result = _gCalculator.GetGrade(score, attendance);
			Assert.Equal(expectedGrade, result);
		}
	}
}
