using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configuration
{
    public class HouseConfiguration : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {
            builder.HasData(
                new House
                {
                    Id = 1,
                    Name = "Gryffindor"
                },
                new House
                {
                    Id = 2,
                    Name = "Hufflepuff"
                },
                new House
                {
                    Id = 3,
                    Name = "Ravenclaw"
                },
                new House
                {
                    Id = 4,
                    Name = "Slytherin"
                });
        }
    }
}
