namespace Application.Response.MenuPlatilloResponses
{
    public class MenuPlatilloGetResponse
    {
        public int id { get; set; }

        public Guid idMenuPlato { get; set; }
        public string? descripcion { get; set; }
        public decimal precio { get; set; }
        public int stock { get; set; }
        public int pedido { get; set; }
        public CategoriaPlato? categoria {get; set;}  
    }

    public class CategoriaPlato
    {
        public string? descripcion { get; set;}
        public string? color { get; set;}
    }
}
