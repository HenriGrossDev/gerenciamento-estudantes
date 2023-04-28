using System.ComponentModel.DataAnnotations;

namespace GerenciamentoEstudantes.Models
{
    public class Disciplina
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "O campo nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        [MaxLength(500, ErrorMessage = "O campo descrição deve ter no máximo 500 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo carga horária é obrigatório")]
        public int CargaHoraria { get; set; }

    }
}
