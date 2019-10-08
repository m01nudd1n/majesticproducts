using Majestic.Models.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Majestic.Domain.AuthenticationContext
{
    public class MajesticAuthContext : IdentityDbContext
    {
        public MajesticAuthContext(DbContextOptions options) : base(options)
        {

        }
        
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
