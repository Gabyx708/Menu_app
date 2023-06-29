﻿namespace Application.Response
{
    public class MenuPlatilloGetResponse
    {
        public int id { get; set; }

        public Guid idMenuPlato { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }
        public int stock { get; set; }
        public int pedido { get; set; }
    }
}
