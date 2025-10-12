using System.ComponentModel.DataAnnotations;

namespace EcoWaste.Core.DTOs
{
    public class PaginacaoDTO
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "A página deve ser maior que zero.")]
        public int Pagina { get; set; } = 1;

        [Required]
        [Range(1, 100, ErrorMessage = "O tamanho da página deve estar entre 1 e 100.")]
        public int TamanhoPagina { get; set; } = 10;
    }
}