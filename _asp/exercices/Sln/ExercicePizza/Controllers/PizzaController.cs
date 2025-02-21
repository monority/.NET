using ExercicePizza.Exceptions;
using ExercicePizza.DTOs;
using ExercicePizza.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using ExercicePizza.Helpers;
using ExercicePizza.Models;

namespace ExercicePizza.Controllers
{
    [Route("pizzas")]
    [ApiController]
    [Authorize] 
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        // GET /pizzas
        [HttpGet]
        [SwaggerOperation(Summary = "Obtenir la liste des pizzas",
                  Description = "Récupère tous les pizzas avec des filtres optionnels sur le prénom, le nom, le numéro de téléphone et l'email.")]
        [ProducesResponseType(typeof(IEnumerable<PizzaDTO>), StatusCodes.Status200OK)]
        [AllowAnonymous] // permet de donner l'accès à l'endpoint aux personnes sans JWT => remplace l'annotion [Authorize] du controller
        public async Task<IActionResult> Get(
            [FromQuery] string? name,
            [FromQuery] string? description,
            [FromQuery] decimal? price,
            [FromQuery] Enum? status,
            [FromQuery] List<Ingredients>? ingredients)
        {
            var pizzas = await _pizzaService.GetAll(name, description, price, status, ingredients);
            return Ok(pizzas);
        }

        // GET /pizzas/{id}
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtenir un pizza par ID",
                  Description = "Récupère un pizza en fonction de son identifiant unique.")]
        [ProducesResponseType(typeof(PizzaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var pizza = await _pizzaService.GetById(id);
            return pizza != null ? Ok(pizza) : NotFound($"Pizza avec l'id {id} non trouvé.");
        }

        

        [HttpPost]
        [SwaggerOperation(Summary = "Créer un nouveau pizza",
                  Description = "Ajoute un nouveau pizza dans le répertoire.")]
        [ProducesResponseType(typeof(PizzaDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] PizzaDTO pizza)
        {
            try
            {
                var newPizza = await _pizzaService.Create(pizza);
                return CreatedAtAction(nameof(GetById),
                                       new { id = newPizza.Id },
                                       newPizza);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erreur lors de la création du pizza : {ex.Message}");
            }
        }

        // PUT /pizzas/{id}
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Mettre à jour un pizza",
                  Description = "Met à jour les informations d'un pizza existant.")]
        [ProducesResponseType(typeof(PizzaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] PizzaDTO pizza)
        {
            try
            {
                var updatedPizza = await _pizzaService.Update(id, pizza);
                return Ok(updatedPizza);
            }
            catch (NotFoundException nex)
            {
                return NotFound(nex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erreur lors de la mise à jour du pizza : {ex.Message}");
            }
        }

        // DELETE /pizzas/{id}
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Supprimer un pizza",
                  Description = "Supprime un pizza à partir de son identifiant.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _pizzaService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erreur lors de la suppression du pizza : {ex.Message}");
            }
        }
    }
}
