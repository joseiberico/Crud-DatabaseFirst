using Crud_databasefirst.Context;
using Crud_databasefirst.Models;
using Crud_databasefirst.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Crud_databasefirst.Repository
{
    public class ContactoRepository : IContactoRepository<Contacto>
    {
        private readonly DbcrudadoContext _context;
        private readonly DbSet<Contacto> _dbset;

        public ContactoRepository(DbcrudadoContext context)
        {
            _context = context;
            _dbset = context.Set<Contacto>();
        }

        public async Task<Contacto> Create(Contacto entity)
        {
            Contacto contacto = new Contacto()
            {
                Nombre = entity.Nombre,
                Telefono = entity.Telefono,
                Correo = entity.Correo
            };

            EntityEntry<Contacto> result = await _context.Contactos.AddAsync(contacto);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            Contacto entity = await GetById(id);
            if (entity == null)
            {
                return false;
            }
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Contacto>> GetAll()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<Contacto> GetById(int id)
        {
            return await _dbset.FirstAsync(x => x.IdContacto == id);
        }

        public async Task<Contacto> Update(Contacto entity)
        {
            var contacto = await GetById(entity.IdContacto);
            if (contacto == null)
            {
                return null;
            }

            contacto.Nombre = entity.Nombre;
            contacto.Telefono = entity.Telefono;
            contacto.Correo = entity.Correo;

            await _context.SaveChangesAsync();
            return contacto;
        }
    }
}
