namespace Domain.Entities
{
    public class Descuento
    {
        public Guid IdDescuento { get; set; }
        public DateTime FechaInicioVigencia { get; set; }
        public double Porcentaje { get; set; }

        public ICollection<Recibo> Recibos { get; set; }
    }
}
