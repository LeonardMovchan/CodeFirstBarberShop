using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairCut.Data.Models
{
    public class BarberShop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public ICollection<Barber> Barbers { get; set; }
        public  ICollection<HairCutAppointment> HairCutAppointments { get; set; }

    }
}
