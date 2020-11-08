using System;
using System.Collections;

namespace HairCut.Data.Models

{
    public class HairCutAppointment
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string HairCutStyle { get; set; }    
        public DateTime Date { get; set; }

        public virtual Barber Barber { get; set; }
        public int BarberId { get; set; }

        public virtual BarberShop BarberShop { get; set; }
        public int BarberShopId { get; set; }
    }
}
