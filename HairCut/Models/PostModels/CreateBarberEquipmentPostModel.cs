using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairCut.Models.PostModels
{
    public class CreateBarberEquipmentPostModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }


        public int BarberId { get; set; }
        public CreateBarberPostModel Barber { get; set; }
    }
}
