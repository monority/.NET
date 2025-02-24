using AutoMapper;
using ExercicePizza.DTOs;
using ExercicePizza.Exceptions;
using ExercicePizza.Models;
using ExercicePizza.Repositories;
using ExercicePizza.Services;
using Microsoft.IdentityModel.Tokens;

namespace PizzaWithDtos.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IRepository<Pizza, int> _PizzaRepository;
        private readonly IMapper _mapper;

        public PizzaService(IRepository<Pizza, int> PizzaRepository,
                              IMapper mapper)
        {
            _PizzaRepository = PizzaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PizzaDTO>> GetAll(string? name = null, string? description = null, decimal? price = null, Enum? status = null ,List<Ingredients>? ingredients = null)
        {
            return _mapper.Map<IEnumerable<PizzaDTO>>(
                await _PizzaRepository.GetAll(c =>
                    (string.IsNullOrEmpty(name) || c.Name != null && c.Name.Contains(name)) &&
                    (string.IsNullOrEmpty(description) || c.Description != null && c.Description.Contains(description)) &&
                    (!price.HasValue || c.Price == price) &&
                    (status == null || c.Status.Equals(status) &&
                    ingredients != null && ingredients.Any())
                ));
        }

        public async Task<PizzaDTO?> GetById(int id) => _mapper.Map<PizzaDTO?>(await _PizzaRepository.GetById(id));


        public async Task<PizzaDTO> Create(PizzaDTO PizzaDto)
        {
            var Pizza = _mapper.Map<Pizza>(PizzaDto);
            try
            {
                return _mapper.Map<PizzaDTO>(await _PizzaRepository.Add(Pizza));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erreur d'ajout pour le Pizza nommé {PizzaDto.Name}: {e.Message}");
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public async Task<PizzaDTO> Update(int id, PizzaDTO PizzaDto)
        {
            var Pizza = _mapper.Map<Pizza>(PizzaDto);
            try
            {
                Pizza.Id = id;
                return _mapper.Map<PizzaDTO>(await _PizzaRepository.Update(Pizza)) ?? throw new NotFoundException($"Pizza avec l'id {id} non trouvé.");
            }
            catch (Exception e)
            {
                    // Ajout du Logging de l'erreur rencontrée
                Console.WriteLine($"Erreur de modification pour le Pizza avec l'id {id}: {e.Message}");
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                if (!await _PizzaRepository.Delete(id))
                    throw new NotFoundException($"Pizza avec l'id {id} non trouvé.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erreur de modification pour le Pizza avec l'id {id}: {e.Message}");
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }
    }
}
