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
    public class BarberEquipmentControllers
    {
        private readonly BarberEquipmentService _barberEquipmentService;
        private readonly IMapper _mapper;
        public int MinTimeBeforeAppointment { get; set; }
        public BarberEquipmentControllers()
        {
            _barberEquipmentService = new BarberEquipmentService();
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

        public void CreateHairCutRequest(CreateBarberEquipmentPostModel model)
        {
          
            var barberEquipment = _mapper.Map<BarberEquipmentModel>(model);

            _barberEquipmentService.Create(barberEquipment);
        }

        public IEnumerable<BarberEquipmentViewModel> GetAll()
        {
            IEnumerable<BarberEquipmentModel> models = _barberEquipmentService.GetAll();

            return _mapper.Map<IEnumerable<BarberEquipmentViewModel>>(models);
        }

        public BarberEquipmentViewModel GetById(int id)
        {
            BarberEquipmentModel model = _barberEquipmentService.GetById(id);
            return _mapper.Map<BarberEquipmentViewModel>(model);
        }

        public bool Delete(int id)
        {
            return _barberEquipmentService.Delete(id);
        }
    }
}
