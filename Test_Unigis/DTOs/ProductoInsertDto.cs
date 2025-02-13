namespace Test_Unigis.DTOs
{
    public class ProductoInsertDto
    {
        public string Nombre { get; set; }
        public decimal Alto { get; set; }
        public decimal Ancho { get; set; }
        public decimal Profundidad { get; set; }
        public decimal Volumen { get; set; }
        public decimal Peso{ get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }
    }
}