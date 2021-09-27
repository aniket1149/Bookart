using Core.Entities.Identities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           
        }
        private void SeedUsers(ModelBuilder builder)
        {
            var user = new AppUser
            {
                DisplayName = "Bob",
                Email = "bob@test.com",
                UserName = "bob@text.com",
                Address = new Address
                {

                    FirstName = "Bob",
                    LastName = "Bobbity",
                    Street = "Mulund West Hogwards",
                    City = "Hogwards",
                    State = "London",
                    ZipCode = "000934"
                }
            };

            builder.Entity<AppUser>().HasData(user);


        }
    }
}
