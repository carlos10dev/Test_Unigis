namespace Test_Unigis.DTOs
{
    public class ProductoUpdateDto
    {
        public int Id { get; set; }
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