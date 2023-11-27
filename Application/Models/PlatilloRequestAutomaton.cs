namespace Application.Models
{
    public class PlatilloRequestAutomation
    {
        public int id { get; set; }
        public string? descripcion { get; set; }
        public string? categoria { get; set; }
        public string? color { get; set; }
    }

    public class PlatilloResponseAutomation : PlatilloRequestAutomation { };
}
