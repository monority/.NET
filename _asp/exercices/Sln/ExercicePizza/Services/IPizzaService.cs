using ExercicePizza.DTOs;
using ExercicePizza.Models;

namespace ExercicePizza.Services
{
    public interface IPizzaService
    {
        Task<IEnumerable<PizzaDTO>> GetAll(string? name = null, string? description = null, decimal? price = null, Enum? status = null, List<Ingredients>? ingredients = null);
        Task<PizzaDTO?> GetById(int id);
        Task<PizzaDTO> Create(PizzaDTO PizzaDto);
        Task<PizzaDTO> Update(int id, PizzaDTO PizzaDto);
        Task Delete(int id);
    }
}
