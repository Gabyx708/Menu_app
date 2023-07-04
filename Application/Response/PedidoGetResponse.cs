namespace Application.Response
{
    public class PedidoGetResponse
    {
        public Guid id { get; set; }
        public Guid Personal { get; set; }
        public Guid Recibo { get; set; }
        public DateTime Fecha { get; set; }
    }
}
