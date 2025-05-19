using ATM_API.Application.Commands.ATM;
using ATM_API.Application.Services;
using Xunit;

namespace ATM_API.Tests
{
    public class ATMServiceTests
    {
        [Fact]
        public void IngresarDinero_DeberiaIngresarCantidadCorrectamente()
        {
            // Arrange
            var service = new ATMService();
            var command = new IngresarDineroCommand("1234567890", 500);

            // Act
            var resultado = service.IngresarDinero(command);

            // Assert
            Assert.Contains("Se han ingresado", resultado);
            Assert.Contains("500", resultado);
        }
        [Fact]
        public void IngresarDinero_CantidadValida_DeberiaIngresarCorrectamente()
        {
            // Arrange
            var service = new ATMService();
            var command = new IngresarDineroCommand("1234567890", 500);

            // Act
            var resultado = service.IngresarDinero(command);

            // Assert
            Assert.Contains("Se han ingresado", resultado);
            Assert.Contains("500", resultado);
        }
        [Fact]
        public void IngresarDinero_MayorA3000_DeberiaRetornarError()
        {
            // Arrange
            var service = new ATMService();
            var command = new IngresarDineroCommand("1234567890", 4000);

            // Act
            var resultado = Assert.Throws<ArgumentException>(() => service.IngresarDinero(command));

            // Assert
            Assert.Equal("La cantidad debe ser mayor a 0 y no superior a 3000 EUR.", resultado.Message);
        }
        [Fact]
        public void IngresarDinero_CuentaInvalida_DeberiaRetornarError()
        {
            // Arrange
            var service = new ATMService();
            var command = new IngresarDineroCommand("CUENTA_INVALIDA", 500);

            // Act
            var resultado = Assert.Throws<ArgumentException>(() => service.IngresarDinero(command));

            // Assert
            Assert.Equal("Cuenta no encontrada.", resultado.Message);
        }
        [Fact]
        public void RetirarDinero_CantidadValida_DeberiaRetirarCorrectamente()
        {
            // Arrange
            var service = new ATMService();
            var command = new RetirarDineroCommand("1234567890", 300);

            // Act
            var resultado = service.RetirarDinero(command);

            // Assert
            Assert.Contains("Se han retirado", resultado);
            Assert.Contains("300", resultado);
        }
        [Fact]
        public void RetirarDinero_MayorA1000_DeberiaRetornarError()
        {
            // Arrange
            var service = new ATMService();
            var command = new RetirarDineroCommand("1234567890", 1500);

            // Act
            var resultado = Assert.Throws<ArgumentException>(() => service.RetirarDinero(command));

            // Assert
            Assert.Equal("La cantidad debe ser mayor a 0 y no superior a 1000 EUR.", resultado.Message);
        }
        [Fact]
        public void RetirarDinero_SaldoInsuficiente_DeberiaLanzarExcepcion()
        {
            // Arrange
            var service = new ATMService();
            var command = new RetirarDineroCommand("0987654321", 800); // Saldo = 1500, pero válido (dentro de límite)

            // Simular operación previa que deja el saldo por debajo
            service.RetirarDinero(new RetirarDineroCommand("0987654321", 1000)); // deja saldo en 500

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => service.RetirarDinero(command));
            Assert.Equal("Saldo insuficiente.", ex.Message);
        }


        [Fact]
        public void RetirarDinero_CuentaInvalida_DeberiaRetornarError()
        {
            // Arrange
            var service = new ATMService();
            var command = new RetirarDineroCommand("CUENTA_INVALIDA", 200);

            // Act
            var resultado = Assert.Throws<ArgumentException>(() => service.RetirarDinero(command));

            // Assert
            Assert.Equal("Cuenta no encontrada.", resultado.Message);
        }
        [Fact]
        public void ConsultarSaldo_DeberiaRetornarSaldoCorrecto()
        {
            // Arrange
            var service = new ATMService();

            // Act
            var cuenta = service.ObtenerCuenta("1234567890");

            // Assert
            Assert.NotNull(cuenta);
            Assert.Equal(5000, cuenta.Saldo); // o el saldo inicial que hayas definido
        }
        [Fact]
        public void ConsultarSaldo_CuentaInvalida_DeberiaRetornarNull()
        {
            // Arrange
            var service = new ATMService();

            // Act
            var cuenta = service.ObtenerCuenta("CUENTA_INVALIDA");

            // Assert
            Assert.Null(cuenta);
        }


    }
}
