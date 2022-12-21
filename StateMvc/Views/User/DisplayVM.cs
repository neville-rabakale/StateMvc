using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace StateMvc.Views.User
{
    public class DisplayVM
    {
        public string SupportEmail { get; set; }
        public string CompanyName { get; set; }
    }
}
