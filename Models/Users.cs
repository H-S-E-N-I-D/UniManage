using Microsoft.AspNetCore.Identity;

namespace UniManage.Models
{
    public class Users : IdentityUser
    {
        public string FullName { get; set; }
    }
}
