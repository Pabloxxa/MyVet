using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext>)
        {

        }

        public DbSet<Owner> Owners { get; set; }
    }
}
