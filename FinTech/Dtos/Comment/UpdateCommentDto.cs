using System.ComponentModel.DataAnnotations;

namespace FinTech.Dtos.Comment
{
    public class UpdateCommentDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "Title must be atleast 3 character long")]
        [MaxLength(100, ErrorMessage = "Title must be atmost 100 character long")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = "Content must be atleast 5 character long")]
        [MaxLength(100, ErrorMessage = "Comtemt must be atmost 100 character long")]
        public string Content { get; set; } = string.Empty;
    }
}
