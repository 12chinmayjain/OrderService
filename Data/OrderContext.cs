using Microsoft.EntityFrameworkCore;
using OrderService.Models;
using System.Collections.Generic;

namespace OrderService.Repository
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
    }
}
