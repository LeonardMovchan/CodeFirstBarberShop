
using HairCut.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairCut.Data.Repositories
{
    public class BarberEFRepository 
    {
        private readonly HairCutAppointmentContext _ctx;

        public BarberEFRepository()
        {
            _ctx = new HairCutAppointmentContext();
        }
        public Barber Create(Barber model)
        {
            _ctx.Barbers.Add(model);
            _ctx.SaveChanges();

            return model;
        }

        public IEnumerable<Barber> GetAll()
        {
            return _ctx.Barbers.ToList();
        }

        public Barber GetById(int id)
        {
            return _ctx.Barbers.FirstOrDefault(x => x.Id == id);
        }

        public Barber Update(Barber model)
        {
            var entity = _ctx.Barbers.FirstOrDefault(x => x.Id == model.Id);

            entity.FullName = model.FullName;
            entity.Phone = model.Phone;
            entity.Salary = model.Salary;
            entity.Expirience = model.Expirience;           

            _ctx.SaveChanges();

            return model;
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = _ctx.Barbers.FirstOrDefault(x => x.Id == id);

                _ctx.Barbers.Remove(entity);
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
