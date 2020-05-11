using dataGatherer.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace dataGatherer.Repository
{
    public class Repo : RepoShield
    {
        private readonly Context _context;
        private readonly DbSet<Model> _models;
        private readonly DbSet<SyncModelStore> _syncModels;
        public Repo(Context context)
        {
            _context = context;
            _models = _context.Models;
            _syncModels = _context.SyncModels;
        }

        public IEnumerable<Model> GetAll()
        {
            return _models.ToList();
        }

        public IEnumerable<SyncModelStore> GetAllSync()
        {
            return _syncModels.ToList();
        }

        public string GetDataUri(int index)
        {
            return _models.FirstOrDefault(t => t.ID.Equals(index))?.DataSourceUrl;
        }

        public Model GetId(int index)
        {
            return _models.FirstOrDefault(t => t.ID.Equals(index));
        }

        public void Push(Model model)
        {
            _models.Add(model);
            _context.SaveChanges();
        }

        public void Push(SyncModelStore model)
        {
            _syncModels.Add(model);
            _context.SaveChanges();
        }
    }
}
