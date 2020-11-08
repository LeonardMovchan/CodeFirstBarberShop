﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairCut.Models.ViewModels
{
    public class BarberShopViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }


        public ICollection<BarberViewModel> Barbers { get; set; }
        public virtual ICollection<HairCutAppointmentViewModel> HairCutAppointments { get; set; }
    }
}
