using System.ComponentModel.DataAnnotations;

namespace office.Models
{
    public class Doc
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        public String Url { get; set; }  
        public String Tittle { get; set; }
        public String Description { get; set; }
        [Range(1, 10, ErrorMessage = "Section must be between 1 and 10 only!!")]
        public String Section { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}
