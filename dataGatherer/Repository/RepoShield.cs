using dataGatherer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dataGatherer.Repository
{
    public interface RepoShield
    {
        IEnumerable<Model> GetAll();
        IEnumerable<SyncModelStore> GetAllSync();
        string GetDataUri(int index);
        Model GetId(int index);
        void Push(Model model);
        void Push(SyncModelStore model);
    }
}
