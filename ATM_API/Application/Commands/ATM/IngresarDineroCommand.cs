namespace ATM_API.Application.Commands.ATM
{
    public class IngresarDineroCommand
    {
        public string NumeroCuenta { get; }
        public decimal Cantidad { get; }

        public IngresarDineroCommand(string numeroCuenta, decimal cantidad)
        {
            NumeroCuenta = numeroCuenta;
            Cantidad = cantidad;
        }
    }
}
