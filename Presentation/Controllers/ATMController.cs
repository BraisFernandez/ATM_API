using ATM_API.Application.Commands.ATM;
using ATM_API.Application.Services;
using ATM_API.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ATM_API.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ATMController : ControllerBase
    {
        private readonly ATMService _atmService;

        public ATMController(ATMService atmService)
        {
            _atmService = atmService;
        }

        /// <summary>
        /// Ingresar dinero en una cuenta bancaria.
        /// </summary>
        /// <param name="command">Comando con el número de cuenta y la cantidad a ingresar.</param>
        /// <returns>Mensaje de éxito o error.</returns>
        [HttpPost("ingresar")]
        public IActionResult IngresarDinero([FromBody] IngresarDineroCommand command)
        {
            try
            {
                _atmService.IngresarDinero(command);
                return Ok(new { message = $"Se han ingresado {command.Cantidad} EUR en la cuenta {command.NumeroCuenta}." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Retirar dinero de una cuenta bancaria.
        /// </summary>
        /// <param name="command">Comando con el número de cuenta y la cantidad a retirar.</param>
        /// <returns>Mensaje de éxito o error.</returns>
        [HttpPost("retirar")]
        public IActionResult RetirarDinero([FromBody] RetirarDineroCommand command)
        {
            try
            {
                _atmService.RetirarDinero(command);
                return Ok(new { message = $"Se han retirado {command.Cantidad} EUR de la cuenta {command.NumeroCuenta}." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Consultar el saldo de una cuenta bancaria.
        /// </summary>
        /// <param name="numeroCuenta">Número de cuenta a consultar.</param>
        /// <returns>Saldo actual de la cuenta.</returns>
        [HttpGet("saldo/{numeroCuenta}")]
        public IActionResult ConsultarSaldo(string numeroCuenta)
        {
            var cuenta = _atmService.ObtenerCuenta(numeroCuenta);
            if (cuenta == null)
                return NotFound(new { error = "Cuenta no encontrada." });

            return Ok(new { saldo = cuenta.Saldo });
        }
    }
}
