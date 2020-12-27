using System.Collections.Generic;

namespace MiniNotes_TodoList.Models
{
    public class Nota
    {
        public int NotaId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Conteudo { get; set; }
        public int UsuarioId { get; set; }
        public int TagId { get; set; }
        public IList<Tag> Tags { get; set; }
    }
}