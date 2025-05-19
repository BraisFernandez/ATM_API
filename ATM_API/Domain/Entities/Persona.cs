namespace ATM_API.Domain.Entities
{
    public class Persona
    {
        public string DNI { get; private set; }
        public string Nombre { get; private set; }
        public string Apellidos { get; private set; }

        public Persona(string dni, string nombre, string apellidos)
        {
            DNI = dni;
            Nombre = nombre;
            Apellidos = apellidos;
        }
    }
}
