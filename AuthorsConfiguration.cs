﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace FluentAPI
{
    public class AuthorsConfiguration : IEntityTypeConfiguration<Autors>
    {
        public void Configure(EntityTypeBuilder<Autors> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Ignore(a => a.FirstName);
            builder.ToTable("Creators");
            builder.Property(p => p.LastName).HasColumnName("FullName");

            builder.Property(a => a.LastName).HasMaxLength(50);

            builder
                .HasMany(a => a.Books)
                .WithMany(a => a.Autors);
        }
    }
}
