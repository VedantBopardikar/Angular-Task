using System.Xml.Serialization;
using Forms.api.Models;
using Microsoft.EntityFrameworkCore;


namespace Forms.api.DB
{
    public class FormDBContext : DbContext
    {
        public FormDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<FormModel> Forms { get; set; }
    }

    
}
