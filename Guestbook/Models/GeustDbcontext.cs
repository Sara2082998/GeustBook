using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Guestbook.Models
{
    public class GeustDbcontext:IdentityDbContext<ApplicationUser>
    {
        public GeustDbcontext()
        {
        }
        public GeustDbcontext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Message> Messages { get; set; }

        
    }
}
