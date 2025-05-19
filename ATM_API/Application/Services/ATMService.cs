using ATM_API.Application.Commands.ATM;
using ATM_API.Domain.Entities;

namespace ATM_API.Application.Services
{
    public class ATMService
    {
        private readonly List<CuentaBancaria> _cuentas; // Simulación de un repositorio en memoria

        public ATMService()
        {
            // Simulando datos iniciales
            _cuentas = new List<CuentaBancaria>
            {
                new CuentaBancaria("1234567890", "Banco Ejemplo", 5000),
                new CuentaBancaria("0987654321", "Banco Demo", 1500)
            };
        }

        public string IngresarDinero(IngresarDineroCommand command)
        {
            var cuenta = _cuentas.FirstOrDefault(c => c.NumeroCuenta == command.NumeroCuenta);

            if (cuenta == null)
                throw new ArgumentException("Cuenta no encontrada.");

            cuenta.IngresarDinero(command.Cantidad);
            return $"Se han ingresado {command.Cantidad} EUR en la cuenta {command.NumeroCuenta}.";
        }

        public string RetirarDinero(RetirarDineroCommand command)
        {
            var cuenta = _cuentas.FirstOrDefault(c => c.NumeroCuenta == command.NumeroCuenta);

            if (cuenta == null)
                throw new ArgumentException("Cuenta no encontrada.");

            cuenta.RetirarDinero(command.Cantidad);
            return $"Se han retirado {command.Cantidad} EUR en la cuenta {command.NumeroCuenta}.";
        }

        public CuentaBancaria? ObtenerCuenta(string numeroCuenta)
        {
            return _cuentas.FirstOrDefault(c => c.NumeroCuenta == numeroCuenta);
        }
    }
}
