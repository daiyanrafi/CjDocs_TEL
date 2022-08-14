using Microsoft.EntityFrameworkCore;
using office.Models;

namespace office.Data;

 public class ApplicationDbContext: DbContext
 {
    internal object docs;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    public DbSet<Doc> Docs { get; set; }
}