namespace Application.Request
{
    public class PedidoRequest
    {
        public Guid idUsuario { get; set; }

        public List<Guid> MenuPlatillos { get; set; }
    }
}
