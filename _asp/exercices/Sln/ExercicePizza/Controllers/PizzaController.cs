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
        [SwaggerOperation(Summary = "Get list of pizzas",
                  Description = "Get list of pizzas with their specifications.")]
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
        [SwaggerOperation(Summary = "Get pizza by id",
                  Description = "Get a pizza by his unique identifier.")]
        [ProducesResponseType(typeof(PizzaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var pizza = await _pizzaService.GetById(id);
            return pizza != null ? Ok(pizza) : NotFound($"Pizza : {id} was not found.");
        }

        

        [HttpPost]
        [SwaggerOperation(Summary = "Create a pizza",
                  Description = "Add a pizza to the list.")]
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
                return BadRequest($"Error while creating the pizza : {ex.Message}");
            }
        }

        // PUT /pizzas/{id}
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Change pizza recipe.",
                  Description = "Update pizza informations.")]
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
                return BadRequest($"Error while trying to update the pizza : {ex.Message}");
            }
        }

        // DELETE /pizzas/{id}
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a pizza",
                  Description = "Delete a pizza by his id")]
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
                return BadRequest($"Error while deleting a pizza : {ex.Message}");
            }
        }
    }
}
