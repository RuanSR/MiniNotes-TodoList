using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MiniNotes_TodoList.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Prencha o nome corretamente!")]
        [MaxLength(100)]
        [MinLength(3)]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Prencha o nome de usuário corretamente!")]
        [MaxLength(100)]
        [MinLength(3)]
        [Display(Name = "Nome de Usuário")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Prencha seu email!")]
        [EmailAddress(ErrorMessage = "Preencha o campo email corretamente!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Crie uma senha!")]
        public string Password { get; set; }

        public IList<Note> Notes { get; set; }
    }
}