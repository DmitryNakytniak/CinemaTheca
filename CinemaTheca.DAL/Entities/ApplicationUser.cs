using Microsoft.AspNet.Identity.EntityFramework;

namespace CinemaTheca.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
    }
}
