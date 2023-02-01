using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;

public class JwtExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is SecurityTokenExpiredException)
        {
            context.Result = new JsonResult(new { message = "Sessie afgelopen, log alstublieft opnieuw in. " })
            {
                StatusCode = StatusCodes.Status401Unauthorized
            };
        }
        else if (context.Exception is SecurityTokenInvalidSignatureException)
        {
            context.Result = new JsonResult(new { message = "Ongeldige sessie, probeer opnieuw. " })
            {
                StatusCode = StatusCodes.Status401Unauthorized
            };
        }
    }
}
