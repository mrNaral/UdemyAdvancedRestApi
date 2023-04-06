﻿using AdvancedRestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvancedRestApi.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
    }
}
