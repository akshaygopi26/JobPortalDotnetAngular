using System.ComponentModel.DataAnnotations;

namespace JobPortal.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}