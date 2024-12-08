namespace Shared
{
    public class ResponseGetCliente
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; } = null!;

        public string? Telefono { get; set; } = null!;

        public string? Email { get; set; } = null!;

    }
}
