using System.ComponentModel.DataAnnotations;

namespace GerenciamentoEstudantes.Models;

public class Aluno
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O nome do aluno é obrigatório.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "A data de nascimento do aluno é obrigatória.")]
    public DateTime DataNascimento { get; set; }

    [Required(ErrorMessage = "O endereço do aluno é obrigatório.")]
    public string Endereco { get; set; }

    [Required(ErrorMessage = "O e-mail do aluno é obrigatório.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O CPF do aluno é obrigatório.")]
    public string CPF { get; set; }
}
