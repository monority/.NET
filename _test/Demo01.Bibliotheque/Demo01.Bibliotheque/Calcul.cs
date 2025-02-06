using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo01.Bibliotheque;
namespace Demo01.Bibliotheque;

// Ne pas oublier le public et la référence de projet depuis TEST vers Bibliotheque
public class Calcul
{
	public double Addittion (double a, double b)
	{
		return a + b;
	}
	public double Division(double a, double b)
	{
		if (b != 0)
		
			return a/ b;
		throw new DivideByZeroException("Divide by 0 impossible");
	}
}
