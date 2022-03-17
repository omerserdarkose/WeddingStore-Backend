using System;
using HelenSposa.Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HelenSposa.Entities.Concrete;

#nullable disable

namespace HelenSposa.DataAccess.Context
{
    //Scaffold-DbContext "Server=DRMORAREES\SQLEXPRESS;Database=HelenSposaDb;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Concrete/ -ContextDir../HelenSposa.DataAccess/Context/ -Context HelenSposaDbContext -force
    public partial class HelenSposaDbContext : DbContext
    {
        public virtual DbSet<Basket> Baskets { get; set; }
        public virtual DbSet<BasketDetail> BasketDetails { get; set; }
        public virtual DbSet<BasketsEvent> BasketsEvents { get; set; }
        public virtual DbSet<Claim> Claims { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventType> EventTypes { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<ExpenseType> ExpenseTypes { get; set; }
        public virtual DbSet<Income> Incomes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserClaim> UserClaims { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DRMORAREES\\SQLEXPRESS;Database=HelenSposaDb;Trusted_Connection=True;");
            }
        }
    }
}
