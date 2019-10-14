using Microsoft.EntityFrameworkCore;
using Restaurante.Core.Entities;
using Restaurante.Core.Interfaces;
using Restaurante.Infrastructure.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Restaurante.Infrastructure.Services
{
    public class GenericService<T> : IServicio<T> where T : class
    {
        private readonly DbSet<T> _entity;
        private readonly AppDbContext _context;

        public GenericService(AppDbContext dbContext)
        {
            _entity = dbContext.Set<T>();
            _context = dbContext;
        }
        public void DeleteRercord(T record) => _entity.Remove(record);

        public T Get(int id) => _entity.Find(id);

        public List<T> GetAll() => _entity.ToList();

        public void Insert(T record) => _entity.Add(record);

        public void Update(T record) => _entity.Update(record);

        public void SaveChanges() => _context.SaveChanges();
        public List<T> GetAllInclude() {
            Orden o = new Orden();
            var z = o.GetType().GetProperty("EmpleadoId").PropertyType;
            return _entity.Include(x => x.GetType().GetProperty("Producto").MemberType).ToList();
        } 
    }
}
