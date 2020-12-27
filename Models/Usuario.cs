using System.Collections.Generic;

namespace MiniNotes_TodoList.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int NotaId { get; set; }
        public IList<Nota> Notas { get; set; }
    }
}