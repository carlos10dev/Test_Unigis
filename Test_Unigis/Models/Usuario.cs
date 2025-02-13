using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Test_Unigis.Enums;

namespace Test_Unigis.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public Rol Rol { get; set; }
    }
}