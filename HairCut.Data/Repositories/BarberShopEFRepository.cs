
using HairCut.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairCut.Data.Repositories
{
    public class BarberShopEFRepository 
    {
      private readonly HairCutAppointmentContext _ctx;

        public BarberShopEFRepository()
        {
            _ctx = new HairCutAppointmentContext();
        }
        public BarberShop Create(BarberShop model)
        {
            _ctx.BarberShops.Add(model);
            _ctx.SaveChanges();

            return model;
        }

        public IEnumerable<BarberShop> GetAll()
        {
            return _ctx.BarberShops.ToList();
        }

        public BarberShop GetById(int id)
        {
            return _ctx.BarberShops.FirstOrDefault(x => x.Id == id);
        }

        public BarberShop Update(BarberShop model)
        {
            var entity = _ctx.BarberShops.FirstOrDefault(x => x.Id == model.Id);

            entity.Name = model.Name;
            entity.Address = model.Address;
            entity.City = model.City;

            _ctx.SaveChanges();

            return model;
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = _ctx.BarberShops.FirstOrDefault(x => x.Id == id);

                _ctx.BarberShops.Remove(entity);
                _ctx.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
