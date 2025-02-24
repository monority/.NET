using System;
using System.Linq.Expressions;
using ExercicePizza.Data;
using ExercicePizza.Models;
using ExercicePizza.Repositories;
using Microsoft.EntityFrameworkCore;

namespace PizzaWithDtos.Repositories
{
    public class PizzaRepository : IRepository<Pizza, int>
    {
        private readonly ApplicationDbContext _db;

        public PizzaRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Pizza> Add(Pizza pizza)
        {
            await _db.Pizzas.AddAsync(pizza);
            await _db.SaveChangesAsync();
            return pizza;
        }

        public async Task<Pizza?> GetById(int id) => await _db.Pizzas.FindAsync(id);

        public async Task<Pizza?> Get(Expression<Func<Pizza, bool>> predicate) => await _db.Pizzas.FirstOrDefaultAsync(predicate);

        public async Task<IEnumerable<Pizza>> GetAll() => _db.Pizzas;

        public async Task<IEnumerable<Pizza>> GetAll(Expression<Func<Pizza, bool>> predicate) => await _db.Pizzas.Where(predicate).ToListAsync();

        public async Task<Pizza?> Update(Pizza Pizza)
        {
            var PizzaFromDb = await GetById(Pizza.Id);
            if (PizzaFromDb is null)
                return null;

            if (PizzaFromDb.Name != Pizza.Name)
                PizzaFromDb.Name = Pizza.Name;
            if (PizzaFromDb.Price != Pizza.Price)
                PizzaFromDb.Price = Pizza.Price;
            if (PizzaFromDb.Description != Pizza.Description)
                PizzaFromDb.Description = Pizza.Description;
            if (PizzaFromDb.Status != Pizza.Status)
                PizzaFromDb.Status = Pizza.Status;
            if (PizzaFromDb.Ingredients != Pizza.Ingredients)
                PizzaFromDb.Ingredients = Pizza.Ingredients;
            await _db.SaveChangesAsync();
            return PizzaFromDb;
        }

        public async Task<bool> Delete(int id)
        {
            var Pizza = await GetById(id);
            if (Pizza is null)
                return false;

            _db.Pizzas.Remove(Pizza);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
