using System.ComponentModel.DataAnnotations;

namespace Gighub.Dtos
{
    public class GenreDto
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}