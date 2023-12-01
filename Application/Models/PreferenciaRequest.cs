namespace Application.Models
{
    public class PreferenciaRequest
    {
        public Guid idUsuario { get; set; }
        public List<CategoriaPrioridad>? categorias { get; set; }
    }

    public class PreferenciaResponse : PreferenciaRequest
    {
        public  string? nombre { get; set; }
        public string? apellido { get; set; }
    }


    public class CategoriaPrioridad
    {
        public  string? categoria { get; set; }
        public byte prioridad { get; set; }
    }
}
