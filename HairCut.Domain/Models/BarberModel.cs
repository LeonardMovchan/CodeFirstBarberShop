using HairCut.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairCut.Domain.Models
{
    public class BarberModel
    {
        public int Id { get; set; }
        public int Salary { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Expirience { get; set; }


        public int BarberShopId { get; set; }
        public BarberShopModel BarberShop { get; set; }

        public ICollection<BarberEquipmentModel> BarberEquipmentModels { get; set; }

        public ICollection<HairCutAppointmentModel> HairCutAppointmentModels { get; set; }
    }
}
