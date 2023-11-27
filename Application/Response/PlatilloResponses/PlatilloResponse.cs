namespace Application.Response.PlatilloResponses
{
    public class PlatilloResponse
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public string? categoria { get; set; }
        public string? categoriaColor { get; set; }

        public decimal precio { get; set; }
        public bool activado { get; set; }
    }
}
