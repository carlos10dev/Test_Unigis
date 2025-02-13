using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Unigis.Models
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nombre { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Alto { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Ancho{ get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Profundidad{ get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Volumen{ get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Peso{ get; set; }

        public DateTime FechaCreacion{ get; set; }

        public bool Activo{ get; set; }
    }
}