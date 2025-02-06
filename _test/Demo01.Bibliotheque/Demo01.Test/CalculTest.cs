namespace Demo01.Test;
using Demo01.Bibliotheque;
[TestClass]
public class CalculTest // ne pas oublier le public
{
	[TestMethod]
	public void WhenAddition_10_30_Then_40() // ne pas oublier le public
	{
		// Notions de Triple A
		// Arrange
		var calcul = new Calcul();
		// Act
		var result = calcul.Addittion(10, 30);
		// Assert
		Assert.AreEqual(result, 40);

		//Assert.IsTrue(result == 40); à eviter car moins d'informations en cas d'échec
	}
	[TestMethod]
	public void WhenDivision_30_10_Then_3()
	{
		// Arrange
		var calcul = new Calcul();
		// Act
		var result = calcul.Division(30, 10);
		// Assert
		Assert.AreEqual(3, result);
	}
	[TestMethod]
	public void WhenDivision_1_0_Then_DivideByZeroException()
	{
		var calcul = new Calcul();

		Assert.ThrowsException<DivideByZeroException>(() => calcul.Division(1, 0));

	}
}
