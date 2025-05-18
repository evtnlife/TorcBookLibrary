using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TorcBookLibrary.Domain.Entities
{
    [Table("books")]
    public class Book
    {
        [Key]
        [Column("book_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        
        [Required]
        [Column("title")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [Column("first_name")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Column("last_name")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [Column("total_copies")]
        public int TotalCopies { get; set; }

        [Required]
        [Column("copies_in_use")]
        public int CopiesInUse { get; set; }

        [Column("type")]
        [MaxLength(50)]
        public string Type { get; set; }

        [Column("isbn")]
        [MaxLength(80)]
        public string ISBN { get; set; }

        [Column("category")]
        [MaxLength(50)]
        public string Category { get; set; }
       
    }
}
