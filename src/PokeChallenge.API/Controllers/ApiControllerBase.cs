using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace PokeChallenge.API.Controllers;

[ApiController]
public abstract class ApiControllerBase : ControllerBase
{
    protected IActionResult ErrorResult(List<Error> errors)
    {
        if (errors is null || errors.Count == 0)
        {
            return Problem();
        }

        if (errors.TrueForAll(p => p.Type == ErrorType.Validation))
        {
            return BadRequest(ErrorResponse(StatusCodes.Status400BadRequest, "Falha na validação dos dados.", HttpContext.Request.Path, errors));
        }

        if (errors.TrueForAll(p => p.Type == ErrorType.NotFound))
        {
            return NotFound(ErrorResponse(StatusCodes.Status404NotFound, "Recurso não encontrado.", HttpContext.Request.Path, errors));
        }

        if (errors.TrueForAll(p => p.Type == ErrorType.Conflict))
        {
            return Conflict(ErrorResponse(StatusCodes.Status409Conflict, "Conflito de dados.", HttpContext.Request.Path, errors));
        }

        return StatusCode(StatusCodes.Status500InternalServerError, ErrorResponse(StatusCodes.Status500InternalServerError, "Erro interno", HttpContext.Request.Path, errors));
    }

    protected IActionResult ErrorResult(Error error) => ErrorResult(new List<Error> { error });

    protected IActionResult ValidResult(object data)
    {
        if (IsNullOrEmptyCollection(data))
        {
            return base.NoContent();
        }

        return base.Ok(data);
    }

    protected IActionResult ValidResult(Success data)
    {
        return base.Ok(data);
    }

    private static bool IsNullOrEmptyCollection(object data)
    {
        return data is null || data is IEnumerable<object> enumerable && !enumerable.Any();
    }

    private ProblemDetails ErrorResponse(int statusCode, string detail, string? instance, List<Error> errors)
    {
        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = "Falha na requisição",
            Detail = detail,
            Instance = instance
        };
        foreach (var error in errors)
        {
            problemDetails.Extensions.Add(error.Code, error.Description);
        }
        return problemDetails;
    }
}
