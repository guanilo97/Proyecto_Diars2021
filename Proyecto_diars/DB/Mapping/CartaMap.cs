using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proyecto_diars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_diars.DB.Mapping
{
    public class CartaMap : IEntityTypeConfiguration<Carta>
    {
        public void Configure(EntityTypeBuilder<Carta> builder)
        {
            builder.ToTable("Carta");
            builder.HasKey(o=> o.Id_carta);


        }
    }
}
