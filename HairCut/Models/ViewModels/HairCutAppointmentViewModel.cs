using System;

namespace HairCut.Models.ViewModels
{
    public class HairCutAppointmentViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string HairCutStyle { get; set; }
        public DateTime Date { get; set; }

        public int BarberId { get; set; }
        public virtual BarberViewModel Barber { get; set; }

        public int BarberShopId { get; set; }
        public virtual BarberShopViewModel BarberShop { get; set; }
    }
}
