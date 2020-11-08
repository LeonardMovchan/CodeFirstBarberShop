using System;

namespace HairCut.Models.PostModels
{
    public class CreateHairCutAppointmentPostModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string HairCutStyle { get; set; }
        public DateTime Date { get; set; }

        public int BarberId { get; set; }
        public virtual CreateBarberPostModel Barber { get; set; }


        public int BarberShopId { get; set; }
        public virtual CreateBarberShopPostModel BarberShop { get; set; }
    }
}
