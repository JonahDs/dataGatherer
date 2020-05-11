using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dataGatherer.Repository
{
    public class DataInit
    {
        private readonly Context _context;

        public DataInit(Context context)
        {
            _context = context;   
        }

        public async Task InitDb()
        {
            //_context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            await _context.SaveChangesAsync();
        }
    }
}
