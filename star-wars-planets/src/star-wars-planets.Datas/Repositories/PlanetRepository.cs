using Dapper;
using star_wars_planets.Data.Context;
using star_wars_planets.Domain.Interfaces;
using star_wars_planets.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace star_wars_planets.Data.Repositories
{
    public class PlanetRepository : IPlanetRepository
    {
        protected PlanetsContext Db = new PlanetsContext();

        public Planet Add(Planet planet)
        {
            Db.Planets.Add(planet);
            Db.SaveChanges();
            return GetById(planet.Id);
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Planet> GetAll()
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM Planet";

            return cn.Query<Planet>(sql);
        }

        public Planet GetById(int id)
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM Planet";

            var planets = cn.Query<Planet>(sql);

            return planets.FirstOrDefault(x => x.Id == id);
        }

        public Planet GetByName(string name)
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM Planet";

            var planets = cn.Query<Planet>(sql);

            return planets.FirstOrDefault(x => x.Name?.ToLower() == name?.ToLower());
        }

        public void Remove(int id)
        {
            var removePlante = Db.Planets.Find(id);
            if(removePlante != null)
                Db.Planets.Remove(removePlante);
            Db.SaveChanges();
        }
    }
}
