using Application.Tools.Encrypt;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Config.TestData
{
    public class AdministradorTest : IEntityTypeConfiguration<Personal>
    {
        public void Configure(EntityTypeBuilder<Personal> builder)
        {
            builder.HasData(

                new Personal
                {
                    IdPersonal = Guid.NewGuid(),
                    Nombre = "Administrador",
                    Apellido = "Aker",
                    Dni = "administrador",
                    FechaNac = new DateTime(1990, 5, 15),
                    FechaIngreso = new DateTime(2022, 1, 1),
                    FechaAlta = new DateTime(2022, 1, 1),
                    Mail = "sistemas@tecnaingenieria.com",
                    Telefono = "1234567890",
                    Privilegio = 1,
                    Password = Encrypt256.GetSHA256("ded572vb")
                }
            );
        }


    }
}
