using AutoMapper;
using HairCut.Domain;
using HairCut.Domain.Models;
using HairCut.Models.PostModels;
using HairCut.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairCut.Controllers
{
    public class BarberShopControllers
    {

        private readonly BarberShopService _barberShopService;
        private readonly IMapper _mapper;
        public BarberShopControllers()
        {
            _barberShopService = new BarberShopService();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateHairCutAppointmentPostModel, HairCutAppointmentModel>();
                cfg.CreateMap<HairCutAppointmentModel, HairCutAppointmentViewModel>();
                cfg.CreateMap<CreateBarberPostModel, BarberModel>().ReverseMap();
                cfg.CreateMap<CreateBarberShopPostModel, BarberShopModel>().ReverseMap();
                cfg.CreateMap<BarberViewModel, BarberModel>().ReverseMap();
                cfg.CreateMap<BarberShopViewModel, BarberShopModel>().ReverseMap();

            });
            _mapper = new Mapper(mapperConfig);
        }

        public void CreateBarberShop(CreateBarberShopPostModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
                throw new Exception("Name is required to add a new BarberShop");
            if (string.IsNullOrWhiteSpace(model.City))
                throw new Exception("City is required to add a new BarberShop");


            var barberShop = _mapper.Map<BarberShopModel>(model);

            _barberShopService.CreateBarberShop(barberShop);
        }

        public IEnumerable<BarberShopViewModel> GetAll()
        {
            IEnumerable<BarberShopModel> models = _barberShopService.GetAll();

            return _mapper.Map<IEnumerable<BarberShopViewModel>>(models);
        }

        public BarberShopViewModel GetById(int id)
        {
            BarberShopModel model = _barberShopService.GetById(id);
            return _mapper.Map<BarberShopViewModel>(model);
        }

        public bool Delete(int id)
        {
            return _barberShopService.Delete(id);
        }

        public CreateBarberShopPostModel UpdateBarberShop(CreateBarberShopPostModel model)
        {
            var barberShop = _mapper.Map<BarberShopModel>(model);

            var updatedBarberShop = _barberShopService.UpdateBarberShop(barberShop);

            return _mapper.Map<CreateBarberShopPostModel>(updatedBarberShop);
        }
    }
}
