namespace ATM_API.Domain.Entities
{
    public class CuentaBancaria
    {
        public string NumeroCuenta { get; private set; }
        public string Entidad { get; private set; }
        public decimal Saldo { get; private set; }

        public CuentaBancaria(string numeroCuenta, string entidad, decimal saldoInicial)
        {
            NumeroCuenta = numeroCuenta;
            Entidad = entidad;
            Saldo = saldoInicial;
        }

        public void IngresarDinero(decimal cantidad)
        {
            if (cantidad <= 0 || cantidad > 3000)
                throw new ArgumentException("La cantidad debe ser mayor a 0 y no superior a 3000 EUR.");

            Saldo += cantidad;
        }

        public void RetirarDinero(decimal cantidad)
        {
            if (cantidad <= 0 || cantidad > 1000)
                throw new ArgumentException("La cantidad debe ser mayor a 0 y no superior a 1000 EUR.");

            if (Saldo < cantidad)
                throw new InvalidOperationException("Saldo insuficiente.");

            Saldo -= cantidad;
        }
    }
}
