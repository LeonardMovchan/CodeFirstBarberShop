using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairCut.Models.ViewModels
{
    public class BarberEquipmentViewModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }

        public int BarberId { get; set; }
        public BarberViewModel Barber { get; set; }
    }
}
