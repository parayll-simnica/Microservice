using System.ComponentModel.DataAnnotations;

namespace ComandsService.Dtos
{
    public class CommandReadDto
    {
        [Required]
        public string HowTo { get; set; }
        [Required]
        public string CommandLine { get; set; }
    }
}