using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BLL
{
    public class StyloService
    {
        public readonly MyDbContext _db;

        public StyloService(MyDbContext db)
        {
            _db = db;
        }
        public List<Stylo> GetAll()
        {
            return _db.stylos.ToList();
        }
        public void CreateStylo(Stylo stylo)
        {

            _db.stylos.Add(stylo);
            _db.SaveChanges();
        }

        public void DeleteStylo(Stylo stylo)
        {
            _db.stylos.Remove(stylo);
            _db.SaveChanges();
        }

        public void UpdateStylo(Stylo stylo)
        {
            
            Stylo stylo1 = _db.stylos.Find(stylo.Id);
            if (stylo1 != null) 
            {
                stylo1.Nom = stylo.Nom;
                stylo1.NomMarque = stylo.NomMarque;
                stylo1.NomType = stylo.NomType;
                stylo1.Photo = stylo.Photo;
                stylo1.Prix = stylo.Prix;
                _db.SaveChanges();
            }
            
        }
        public Stylo GetStylo(int id)
        {
            return _db.stylos.Find(id);
        }
    }
}
