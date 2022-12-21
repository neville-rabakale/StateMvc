using System.ComponentModel.DataAnnotations;

namespace StateMvc.Views.User
{
    public class IndexVM
    {
        [Required]
        [EmailAddress]
        public string SupportEmail { get; set; }
        [Required]
        public string CompanyName { get; set; }
    }
}
