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
    public class BarberControllers
    {
        private readonly BarberService _barberService;
        private readonly IMapper _mapper;
        public BarberControllers()
        {
            _barberService = new BarberService();
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

        public void CreateBarber(CreateBarberPostModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Phone))
                throw new Exception("Phone number is reuqired to add barber");
            if (string.IsNullOrWhiteSpace(model.FullName))
                throw new Exception("Full Name is required to add barber");


            var barber = _mapper.Map<BarberModel>(model);

            _barberService.CreateBarber(barber);
        }

        public IEnumerable<BarberViewModel> GetAll()
        {
            IEnumerable<BarberModel> models = _barberService.GetAll();

            return _mapper.Map<IEnumerable<BarberViewModel>>(models);
        }

        public BarberViewModel GetById(int id)
        {
            BarberModel model = _barberService.GetById(id);
            return _mapper.Map<BarberViewModel>(model);
        }

        public bool Delete(int id)
        {
            return _barberService.Delete(id);
        }

        public CreateBarberPostModel UpdateBarber(CreateBarberPostModel model)
        {
            var barber = _mapper.Map<BarberModel>(model);

            var updatedBarber = _barberService.UpdateBarber(barber);

            return _mapper.Map<CreateBarberPostModel>(updatedBarber);
        }
    }
}
