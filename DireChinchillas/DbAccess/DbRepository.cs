using DireChinchillas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DireChinchillas.DbAccess
{
    public class DbRepository : IDisposable
    {
        private readonly ApplicationDbContext _context;

        public DbRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Chinchilla> GetAllChinchillas()
        {
            var chinchillas = _context.Chinchillas.Include(c => c.Colour).Include(c => c.Father).Include(c => c.Mother);
            return chinchillas.ToList();
        }

        public Chinchilla GetChinchillaById(int id)
        {
            return _context.Chinchillas.Find(id);
        }

        public List<Chinchilla> GetChinchillaBySex(Enums.SexTypes sex)
        {
            return _context.Chinchillas.Where(c => c.Sex == sex).ToList();
        }

        public void AddChinchilla(Chinchilla newChin)
        {
            _context.Chinchillas.Add(newChin);
        }

        public void RemoveChinchilla(Chinchilla chinToRemove)
        {
            _context.Chinchillas.Remove(chinToRemove);
        }

        public List<ColourMutation> GetAllColours()
        {
            return _context.ColorMutations.ToList();
        }

        public ColourMutation GetColourById(int id)
        {
            return _context.ColorMutations.Find(id);
        }

        public void AddColour(ColourMutation newColour)
        {
            _context.ColorMutations.Add(newColour);
        }

        public void RemoveColour(ColourMutation colourToRemove)
        {
            _context.ColorMutations.Remove(colourToRemove);
        }

        public void Modify<T>(T entityToModify) where T : class
        {
            _context.Entry(entityToModify).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}