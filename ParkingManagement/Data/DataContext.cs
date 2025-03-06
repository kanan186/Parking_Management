using System.Data;
using Microsoft.EntityFrameworkCore;
using ParkingManagement.Models;

namespace ParkingManagement.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<User>Users { get; set; }

    }
}
