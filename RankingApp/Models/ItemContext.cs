using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace RankingApp.Models
{
    public class ItemContext : DbContext
    {

        public ItemContext(DbContextOptions<ItemContext> options)
            : base(options)
        {
            
        }

        public DbSet<ItemModel> Items { get; set; }
    }
}
