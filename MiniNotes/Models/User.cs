using System.Collections.Generic;

namespace MiniNotes_TodoList.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int NoteId { get; set; }
        public IList<Note> Notas { get; set; }
    }
}