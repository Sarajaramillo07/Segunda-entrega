﻿using lib_aplicaciones.Interfaces;
using Lib_Dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class PeliculasAplicacion : IPeliculasAplicacion
    {
        private IConexion? IConexion = null;

        public PeliculasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Peliculas? Borrar(Peliculas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            this.IConexion!.Peliculas!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Peliculas? Guardar(Peliculas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.Peliculas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Peliculas> Listar()
        {
            return this.IConexion!.Peliculas!.Take(20).ToList();
        }

        public List<Peliculas> PorCodigo(Peliculas? entidad)
        {
            return this.IConexion!.Peliculas!
            .Where(x => x.Nombre!.Contains(entidad!.Nombre!))
            .ToList();
        }

        public Peliculas? Modificar(Peliculas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            var entry = this.IConexion!.Entry<Peliculas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
        public void GuardarAuditoria(string? accion)
        {
            var con = this.IConexion.Auditorias;
            var entidad = new Auditorias();
            {
                entidad.Usuario = 1;
                entidad.Accion = accion;
                entidad.FechaHora = DateTime.Now;
            }
            ;
            this.IConexion.Auditorias.Add(entidad);

        }

    }
}