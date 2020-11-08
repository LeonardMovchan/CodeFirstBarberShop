using HairCut.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairCut.Data.Repositories
{
    public class BarberEquipmentEFRepository
    {
        private readonly HairCutAppointmentContext _ctx;

        public BarberEquipmentEFRepository()
        {
            _ctx = new HairCutAppointmentContext();
        }
        public BarberEquipment Create(BarberEquipment model)
        {
            _ctx.BarberEquipments.Add(model);
            _ctx.SaveChanges();

            return model;
        }

        public IEnumerable<BarberEquipment> GetAll()
        {
            return _ctx.BarberEquipments.ToList();
        }

        public BarberEquipment GetById(int id)
        {
            return _ctx.BarberEquipments.FirstOrDefault(x => x.Id == id);
        }

        public BarberEquipment Update(BarberEquipment model)
        {
            var entity = _ctx.BarberEquipments.FirstOrDefault(x => x.Id == model.Id);

            entity.Name = model.Name;
            entity.Price = model.Price;
            entity.Quantity = model.Quantity;

            _ctx.SaveChanges();

            return model;
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = _ctx.BarberEquipments.FirstOrDefault(x => x.Id == id);

                _ctx.BarberEquipments.Remove(entity);
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
