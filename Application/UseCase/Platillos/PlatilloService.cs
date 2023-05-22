﻿using Application.Interfaces.IPlatillo;
using Application.Request;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Platillos
{
    public class PlatilloService : IPlatilloService
    {
        private readonly IPlatilloQuery _query;
        private readonly IPlatilloCommand _command;

        public PlatilloService(IPlatilloQuery query, IPlatilloCommand command)
        {
            _query = query;
            _command = command;
        }

        public PlatilloResponse CreatePlatillo(PlatilloRequest request)
        {
            var nuevoPlatillo = new Platillo
            {
                Descripcion = request.descripcion,
                Precio = request.precio,
                Activado = true
            };

            _command.CreatePlatillo(nuevoPlatillo);
            var responsePlatillo = GetPlatilloById(nuevoPlatillo.IdPlatillo);
            return responsePlatillo;
        }

        public List<PlatilloResponse> GetAll()
        {
            var platillosAMapear = _query.GetAll();
            List<PlatilloResponse> platillos = new List<PlatilloResponse>();

            foreach (var platilloMapear in platillosAMapear)
            {
                var platoAdd = new PlatilloResponse
                {
                    id = platilloMapear.IdPlatillo,
                    descripcion = platilloMapear.Descripcion,
                    precio = platilloMapear.Precio,
                    activado = platilloMapear.Activado
                };

                platillos.Add(platoAdd);
            }

            return platillos;
        }

        public PlatilloResponse GetPlatilloById(int idPlatillo)
        {
            var platilloRecuperado = _query.GetPlatilloById(idPlatillo);
           
            if(platilloRecuperado == null) { return null; };

            return new PlatilloResponse
            {
                id = platilloRecuperado.IdPlatillo,
                descripcion = platilloRecuperado.Descripcion,
                precio = platilloRecuperado.Precio,
                activado = platilloRecuperado.Activado
            };
        }

        public PlatilloResponse UpdatePrecio(int idPlatillo, double nuevoPrecio)
        {
            var platilloActualizado = _command.UpdatePrecio(idPlatillo, nuevoPrecio);

            return new PlatilloResponse
            {
                id = platilloActualizado.IdPlatillo,
                descripcion = platilloActualizado.Descripcion,
                precio = platilloActualizado.Precio,
                activado = platilloActualizado.Activado
            };
        }
    }
}