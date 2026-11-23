using System.ComponentModel.DataAnnotations;

namespace EtAndHkIde.Archive.Models
{
    public class Item
    {
        [Key]
        public long Id { get; set; }
        public string Key { get; set; } = string.Empty;
        public string ItemType { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Abstract { get; set; } = string.Empty;
        public string Creators { get; set; } = string.Empty;
        public DateOnly? Date { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }
        public ItemContentType ItemContentType { get; set; }

        public ICollection<Attachment> Attachments { get; set; } = [];
        public ICollection<ItemAttribute> Attributes { get; set; } = [];
        public ICollection<Note> Notes { get; set; } = []; 
    }
}
