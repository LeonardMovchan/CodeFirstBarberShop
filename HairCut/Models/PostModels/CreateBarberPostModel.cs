using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairCut.Models.PostModels
{
    public class CreateBarberPostModel
    {
        public int Id { get; set; }
        public int Salary { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Expirience { get; set; }

        public int BarberShopId { get; set; }
        public CreateBarberShopPostModel BarberShop { get; set; }

        public ICollection<CreateBarberEquipmentPostModel> BarberEquipments { get; set; }
        public ICollection<CreateHairCutAppointmentPostModel> HairCutAppointments { get; set; }
    }
}
