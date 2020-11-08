
using HairCut.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HairCut.Data.Repositories 
{
    public class HairCutAppointmentEFRepository 
    {
        private readonly HairCutAppointmentContext _ctx;

        public HairCutAppointmentEFRepository()
        {
            _ctx = new HairCutAppointmentContext();
        }
        public HairCutAppointment Create(HairCutAppointment model)
        {
            _ctx.HairCutAppointments.Add(model);
            _ctx.SaveChanges();

            return model;
        }

        public IEnumerable<HairCutAppointment> GetAll()
        {
            return _ctx.HairCutAppointments.ToList();
        }

        public HairCutAppointment GetById(int id)
        {
            return _ctx.HairCutAppointments.FirstOrDefault(x => x.Id == id);
        }

        public HairCutAppointment Update(HairCutAppointment model)
        {
            var entity = _ctx.HairCutAppointments.FirstOrDefault(x => x.Id == model.Id);

            entity.FullName = model.FullName;
            entity.Phone = model.Phone;
            entity.Barber = model.Barber;
            entity.Date = model.Date;
            entity.HairCutStyle = model.HairCutStyle;
            _ctx.SaveChanges();

            return model;
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = _ctx.HairCutAppointments.FirstOrDefault(x => x.Id == id);

                _ctx.HairCutAppointments.Remove(entity);
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
