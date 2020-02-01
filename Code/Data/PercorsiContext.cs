using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PathApp.Data
{
    public class PercorsiContext : IdentityDbContext
    {
        public PercorsiContext(DbContextOptions<PercorsiContext> options)
            : base(options)
        {
        }

        public DbSet<Models.PercorsiModel> PercorsiModel { get; set; }


        public DbSet<Models.StazioneModel> StazioneModel { get; set; }
    }
}
