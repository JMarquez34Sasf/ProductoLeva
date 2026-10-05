
using ProductoLeva.Models;

namespace ProductoLeva.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ArgumentException ex)
            {
                context.Response.StatusCode = 400;

                var respuesta = new ResponseGenerico<string>
                {
                    codigo = 400,
                    message = "Error de Validacion",
                    response = ex.Message
                };

                await context.Response.WriteAsJsonAsync(respuesta);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;

                var respuesta = new ResponseGenerico<string>
                {
                    codigo = 500,
                    message = "Error inesperado",
                    response = ex.Message
                };

                await context.Response.WriteAsJsonAsync(respuesta);
            }
        }
    }
}