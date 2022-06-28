using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Tridi_Case_Study.Models
{
    public class TridiContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public TridiContext(DbContextOptions<TridiContext> options) : base(options)
        {


        }
        public DbSet<User> Users { get; set; }
    }
}
