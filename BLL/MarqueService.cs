using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MarqueService
    {
        public readonly MyDbContext _db;
        public MarqueService(MyDbContext db) {  _db = db; }
        public List<Marque> GetAll()
        {
            return _db.marques.ToList();
        }

    }
}
