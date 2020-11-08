using AutoMapper;
using HairCut.Domain;
using HairCut.Domain.Models;
using HairCut.Models.PostModels;
using HairCut.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace HairCut.Controllers
{
    public class HairCutAppointmentControllers
    {
        private readonly HairCutService _hairCutService;
        private readonly IMapper _mapper;
        public int MinTimeBeforeAppointment { get; set; }
        public HairCutAppointmentControllers()
        {
            _hairCutService = new HairCutService();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateHairCutAppointmentPostModel, HairCutAppointmentModel>();
                cfg.CreateMap<HairCutAppointmentModel, HairCutAppointmentViewModel>();
                cfg.CreateMap<CreateBarberPostModel, BarberModel>().ReverseMap();
                cfg.CreateMap<CreateBarberShopPostModel, BarberShopModel>().ReverseMap();
                cfg.CreateMap<BarberViewModel, BarberModel>().ReverseMap();
                cfg.CreateMap<BarberShopViewModel, BarberShopModel>().ReverseMap();
                cfg.CreateMap<BarberEquipmentViewModel, BarberEquipmentModel>().ReverseMap();
                cfg.CreateMap<CreateBarberEquipmentPostModel, BarberEquipmentModel>().ReverseMap();

            });
            _mapper = new Mapper(mapperConfig);
        }

        public void CreateHairCutRequest(CreateHairCutAppointmentPostModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Phone))
                throw new Exception("Phone number is reuqired to make a reservation");
            if (string.IsNullOrWhiteSpace(model.FullName))
                throw new Exception("Full Name is required to make a reservation");
            if (model.Date < DateTime.UtcNow.AddHours(MinTimeBeforeAppointment))
                throw new Exception("Our barbers need some time to prepare");

            var hairCutAppointment = _mapper.Map<HairCutAppointmentModel>(model);

            _hairCutService.CreateHairCutRequest(hairCutAppointment);
        }

     public IEnumerable<HairCutAppointmentViewModel> GetAll()
        {
            IEnumerable<HairCutAppointmentModel> models = _hairCutService.GetAll();

            return _mapper.Map<IEnumerable<HairCutAppointmentViewModel>>(models);
        }

      public HairCutAppointmentViewModel GetById(int id)
        {
            HairCutAppointmentModel model = _hairCutService.GetById(id);
            return _mapper.Map<HairCutAppointmentViewModel>(model);
        }

       public bool Delete(int id)
        {
            return _hairCutService.Delete(id);
        }
    }
}
