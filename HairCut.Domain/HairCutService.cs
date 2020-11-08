using AutoMapper;
using HairCut.Data.Models;
using HairCut.Data.Repositories;
using HairCut.Domain.Models;
using System.Collections.Generic;

namespace HairCut.Domain
{
    public class HairCutService
    {
        private readonly HairCutAppointmentEFRepository _hairCutAppointmentRepository;
        private readonly IMapper _mapper;
        public HairCutService()
        {
            _hairCutAppointmentRepository = new HairCutAppointmentEFRepository();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HairCutAppointmentModel, HairCutAppointment>().ReverseMap();
                cfg.CreateMap<BarberModel,Barber>().ReverseMap();
                cfg.CreateMap<BarberShopModel,BarberShop>().ReverseMap();

            });
            _mapper = new Mapper(mapperConfig);
        }

        public void CreateHairCutRequest(HairCutAppointmentModel model)
        {
            var hairCutAppointmenet = _mapper.Map<HairCutAppointment>(model);

            _hairCutAppointmentRepository.Create(hairCutAppointmenet);
        }

        public IEnumerable<HairCutAppointmentModel> GetAll()
        {
            IEnumerable<HairCutAppointment> models = _hairCutAppointmentRepository.GetAll();

            var mappedModels = _mapper.Map<IEnumerable<HairCutAppointmentModel>>(models);

            return mappedModels;
        }

        public HairCutAppointmentModel GetById(int id)
        {
            HairCutAppointment model = _hairCutAppointmentRepository.GetById(id);
            return _mapper.Map<HairCutAppointmentModel>(model);
        }

        public bool Delete(int id)
        {
           return _hairCutAppointmentRepository.Delete(id);
        }

        public HairCutAppointmentModel UpdateHairCutAppointment(HairCutAppointmentModel model)
        {
            var hairCutAppointment = _mapper.Map<HairCutAppointment>(model);

            var updatedHairCutAppointment = _hairCutAppointmentRepository.Update(hairCutAppointment);

            return _mapper.Map<HairCutAppointmentModel>(updatedHairCutAppointment);
        }
    }
}
