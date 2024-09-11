using MediatR;
using Microsoft.AspNetCore.Mvc;
using PokeChallenge.API.Application.PokemonMasters.Create;
using PokeChallenge.API.Application.PokemonMasters.GetById;

namespace PokeChallenge.API.Controllers.v1.PokemonMasters;

[Route("api/v1/pokemon-masters")]
public class PokemonMasterController : ApiControllerBase
{
    private readonly ISender _sender;

    public PokemonMasterController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var query = new GetPokemonMasterByIdQuery(id);

        var result = await _sender.Send(query, cancellationToken);

        return result.Match(ValidResult, ErrorResult);
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterPokemonMasterRequest request, CancellationToken cancellationToken)
    {
        var command = new CreatePokemonMasterCommand(request.Nome, request.Email, request.Cpf);

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsError)
        {
            return ErrorResult(result.Errors);
        }

        return CreatedAtAction(nameof(GetById), new { id = result.Value }, new { id = result.Value });
    }
}
