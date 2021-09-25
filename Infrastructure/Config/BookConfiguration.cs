using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Config
{
    class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.BookName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(180);
            builder.Property(p => p.Description).HasColumnType("decimal(18,2)");
            builder.HasOne(b => b.CategoryName).WithMany()
                .HasForeignKey(p => p.CategoryId);
            builder.HasOne(b => b.BookAuthor).WithMany()
                .HasForeignKey(p => p.BookAuthorId);
        }
    }
}
