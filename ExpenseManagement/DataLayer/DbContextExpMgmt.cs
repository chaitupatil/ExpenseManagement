using Microsoft.EntityFrameworkCore;
using ExpenseManagement.Models;

namespace ExpenseManagement.DataLayer
{
    public class DbContextExpMgmt : DbContext
    {
        public DbContextExpMgmt(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ExpenseEntity> Expenses { get; set; }

        public DbSet<ExpenseCategoryEntity> ExpenseCategory { get; set; }

        public DbSet<UserProfile> UserProfile { get; set; }
    }
}
