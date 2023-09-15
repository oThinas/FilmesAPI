using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Filme
{
  [Key]
  [Required]
  public int Id { get; set; }

  [Required(ErrorMessage = "O campo Título é obrigatório")]
  public string Titulo { get; set; }

  [Required(ErrorMessage = "O campo Gênero é obrigatório")]
  [MaxLength(50, ErrorMessage = "O campo Gênero não pode ter mais de 50 caracteres")]
  public string Genero { get; set; }

  [Required]
  [Range(70, 600, ErrorMessage = "A duração deve ter entre 70 minutos e 600 minutos")]
  public int Duracao { get; set; }
}