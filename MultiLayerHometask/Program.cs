using HairCut.Controllers;
using HairCut.Models.PostModels;
using System;

namespace MultiLayerHometask
{
    public class Program
    {
        static void Main(string[] args)
        {
            var controller = new HairCutAppointmentControllers();
            controller.MinTimeBeforeAppointment = 0;

            var model = new CreateHairCutAppointmentPostModel
            {
                Date = DateTime.Now.AddDays(2),
                FullName = "Court Cobain",
                Phone = "+3432123",
                HairCutStyle = "Vin Diesel",

                Barber = new CreateBarberPostModel
                {
                    FullName = "James Dean",
                    Phone = "+35-452-32-234",
                    Expirience = "Master",
                    Salary = 500
                    
                },
                BarberShop = new CreateBarberShopPostModel
                {
                    Name = "Heroin Paradise",
                    Address = "Somewhere only we know 45",
                    City = "Kharkiv"
                }
                
            };


            var barber = new BarberControllers();

            var barberModel = new CreateBarberPostModel
            {
                FullName = "Jon Dou",
                Phone = "+352123561",
                Salary = 450,
                Expirience = "Grand Master"
            };
            //barber.CreateBarber(barberModel);

            var barberShop = new BarberShopControllers();

            var barberShopModel = new CreateBarberShopPostModel
            {
                Name = "Jay & Jones",
                Address = "Some str 45 ave",
                City = "Kharkiv",
            };

            barberShop.CreateBarberShop(barberShopModel);



            controller.CreateHairCutRequest(model);

            //var barberId = barber.GetAll();
            //var barberShopId = barberShop.GetAll();   
            var allAppointments = controller.GetAll();
            //var appointment = controller.GetById(1);

            //var delete = controller.Delete(1);

            //allAppointments = controller.GetAll();
        }
    }
}
