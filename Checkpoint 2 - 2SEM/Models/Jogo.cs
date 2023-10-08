using System;
using System.ComponentModel.DataAnnotations;

namespace Checkpoint_2___2SEM.Models
{

    public enum GeneroJogo
    {
        Acao,
        Aventura,
        RPG,
        Esportes,
        Estrategia,
        Corrida,
        Simulacao,
        Horror
    }

    public enum ClassificacaoIndicativa
    {
        Livre,
        MaioresDe10,
        MaioresDe12,
        MaioresDe14,
        MaioresDe16,
        MaioresDe18
    }

    public class Jogo
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome do Jogo")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Gênero")]
        public GeneroJogo Genero { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de Lançamento")]
        public DateTime DataLancamento { get; set; }

        [Display(Name = "Classificação Indicativa")]
        public ClassificacaoIndicativa Classificacao { get; set; }

        [StringLength(500, ErrorMessage = "A descrição não pode exceder 500 caracteres.")]
        [Display(Name = "Descrição Breve")]
        public string Descricao { get; set; }
    }
}
