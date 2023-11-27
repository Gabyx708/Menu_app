namespace Application.Models
{
    public class PreferenciaRequest
    {
        public Guid idUsuario { get; set; }
        public List<CategoriaPrioridad>? Categorias { get; set; }
    }

    public class PreferenciaResponse : PreferenciaRequest
    {
        public  string? Nombre { get; set; }
        public string? Apellido { get; set; }
    }


    public class CategoriaPrioridad
    {
        public  string? Categoria { get; set; }
        public byte prioridad { get; set; }
    }
}
