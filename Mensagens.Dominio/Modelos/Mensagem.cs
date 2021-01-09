using System.ComponentModel.DataAnnotations;

namespace Mensagens.Dominio.Modelos
{
    public class Mensagem
    {
        public int Id { get; set; }
        [Required]
        public string Texto { get; set; }
    }
}