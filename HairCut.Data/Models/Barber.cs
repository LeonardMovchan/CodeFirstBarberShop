using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairCut.Data.Models
{
    public class Barber
    {
        public int Id { get; set; }
        public int Salary { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Expirience { get; set; }

        public int BarberShopId { get; set; }
        public BarberShop BarberShop { get; set; }

        public ICollection<BarberEquipment> BarberEquipments { get; set; }

        public ICollection<HairCutAppointment> HairCutAppointments { get; set; }
        
    }
}
