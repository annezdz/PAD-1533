using System.ComponentModel.DataAnnotations;

namespace HBSIS.Padawan.Produtos.Application.Models
{
    public class AuthenticateModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}