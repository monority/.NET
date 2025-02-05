using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceHotel.Repositories
{
	internal interface IRepository<T, Tid> where T : new()
	{
		T? Add(T entity);
		T? Update(Tid id, T entity);
		T? GetById(Tid id);
		T? Get(Func<T, bool> predicate);
		IEnumerable<T> GetAll();
		IEnumerable<T> GetAll(Func<T, bool> predicate);
		bool Delete(Tid id);
		bool DeleteAllEntry(T entity);
	}
}
