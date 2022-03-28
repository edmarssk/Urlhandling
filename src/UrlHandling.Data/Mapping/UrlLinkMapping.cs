using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UrlHandling.Business.Models;

namespace UrlHandling.Data.Mapping
{
    public class UrlLinkMapping : IEntityTypeConfiguration<UrlLink>
    {
        public void Configure(EntityTypeBuilder<UrlLink> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.ShortUrl).IsRequired().HasColumnType("varchar(100)");

            builder.Property(b => b.OriginalUrl).IsRequired().HasColumnType("varchar(500)");

            builder.Property(b => b.Active).HasColumnType("bit");

            builder.ToTable("UrlLink");
        }
    }
}
