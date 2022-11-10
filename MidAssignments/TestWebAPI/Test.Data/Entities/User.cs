/*using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Test.Data.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? UserId { get; set; }
        public string? UserName { get; set; }

        public string? Password { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public List<BookBorrowingRequest>? BookBorrowingRequests { get; set; } // user stander
        public List<BookBorrowingRequest>? ProcessedRequests { get; set; }     // user pro co ca 2
    }
}
*/