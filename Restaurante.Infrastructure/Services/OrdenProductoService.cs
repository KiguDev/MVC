using Microsoft.EntityFrameworkCore;
using Restaurante.Core.Entities;
using Restaurante.Core.Interfaces;
using Restaurante.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurante.Infrastructure.Services
{
    public class OrdenProductoService : IOrdenProducto
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<OrdenProducto> _entity;
        public OrdenProductoService(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
            _entity = _appDbContext.Set<OrdenProducto>();
        }
        public void DeleteRercord(OrdenProducto record) => _entity.Remove(record);

        public OrdenProducto Get(int id) => _entity.Find(id);

        public OrdenProducto Get(OrdenProducto ordenProducto) => _entity.Where(o => o.ProductoId == ordenProducto.ProductoId && o.OrdenId == ordenProducto.OrdenId).FirstOrDefault();

        public List<OrdenProducto> GetAll(int id) => _entity.ToList();

        public List<OrdenProducto> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<OrdenProducto> GetAllInclude(int id) => _entity.Where(o => o.OrdenId == id).Include(o => o.Producto).ToList();

        public void Insert(OrdenProducto record) => _entity.Add(record);

        public void SaveChanges() => _appDbContext.SaveChanges();

        public void Update(OrdenProducto record) => _entity.Update(record);
    }
}
