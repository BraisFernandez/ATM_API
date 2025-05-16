namespace ATM_API.Application.Commands.ATM
{
    public class RetirarDineroCommand
    {
        public string NumeroCuenta { get; }
        public decimal Cantidad { get; }

        public RetirarDineroCommand(string numeroCuenta, decimal cantidad)
        {
            NumeroCuenta = numeroCuenta;
            Cantidad = cantidad;
        }
    }
}
