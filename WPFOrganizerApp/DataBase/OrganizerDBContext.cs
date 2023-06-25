using Microsoft.EntityFrameworkCore;
using WPFOrganizerApp.Models;

namespace WPFOrganizerApp.DataBase
{
    public class OrganizerDBContext : DbContext
    {
        public OrganizerDBContext(DbContextOptions<OrganizerDBContext> options) : base(options)
        {
        }

        public DbSet<Users> User { get; set; } 
    }
}
