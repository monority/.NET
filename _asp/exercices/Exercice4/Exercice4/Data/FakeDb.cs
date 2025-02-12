using Exercice4.Models;

namespace Exercice4.Data
{
    public class FakeDb
    {
        public readonly HashSet<GraDino> GraDinos = new()
        {
            new GraDino() { Id = 1,NickName = "Mols", height = 150, weight = 50, specy = "Ravager"},
            new GraDino() { Id = 2 ,NickName = "Dalos", height = 200, weight = 150, specy = "Erasor"},

        };
    }
}
