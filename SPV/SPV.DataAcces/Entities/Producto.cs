namespace SPV.DataAcces.Entities
{
    public class Producto
    {
        public int Codigo_pr { get; set; }
        public string Descripcion_pr { get; set; }
        public int Codigo_ma { get; set; }
        public string Descripcion_ma { get; set; }
        public int Codigo_um { get; set; }
        public string Descripcion_um { get; set; }
        public int Codigo_sf { get; set; }
        public string Descripcion_sf { get; set; }
        public decimal Precio_unitario { get; set; }
        public int Codigo_ad { get; set; }
        public string Descripcion_ad { get; set; }
        public string Observacion { get; set; }
        public byte[] Imagen { get; set; }
    }
}
