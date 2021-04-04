using System.Collections.Generic;

namespace MiniNotes_TodoList.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Conteudo { get; set; }
        public int UserId { get; set; }
        public int TagId { get; set; }
        public IList<Tag> Tags { get; set; }
    }
}