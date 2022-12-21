using Microsoft.AspNetCore.Mvc;
using StateMvc.Views.User;

namespace StateMvc.Models
{
    public class DataService
    {
        List<User> Users = new List<User>();

        public void AddUser(IndexVM model) 
        {
            
            Users.Add(new User
            {
                SupportEmail= model.SupportEmail,
                CompanyName= model.CompanyName
            });
        }

        public IndexVM GetUser()
        {
            return Users.Select(x => new IndexVM
            {
                SupportEmail= x.SupportEmail,
                CompanyName= x.CompanyName
            }).Single();
        }

        
    }
}
