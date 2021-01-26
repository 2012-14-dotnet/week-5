using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebService.DemoApi.Controllers
{
  [ApiController]
  [Produces("application/json")]
  [Route("[controller]")]
  public class PokemonController : ControllerBase
  {
    private string[] _pokemon = { "infernape", "salamante", "haunter" };
    private string pokeApi = "https://pokeapi.co/api/v2/pokemon";

    // public void Start()
    // {
    //   Test();
    // }

    // public void Test()
    // {
    //   Get();
    // }

    [HttpGet]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Banana()
    {
      // Response.StatusCode = StatusCodes.Status200OK;
      // return new ObjectResult(_pokemon[(new Random()).Next(3)]);

      // return Created("", _pokemon[(new Random()).Next(3)]);

      var httpClient = new HttpClient(); // 3
      var response = await httpClient.GetAsync(pokeApi); // 1

      if (response.IsSuccessStatusCode) // 4
      {
        return Ok(await response.Content.ReadAsStringAsync()); // 2
      }

      return NotFound(response.StatusCode);
    }
  }
}
