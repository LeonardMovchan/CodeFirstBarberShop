using AutoMapper;
using HairCut.Data.Models;
using HairCut.Data.Repositories;
using HairCut.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairCut.Domain
{
    public class BarberEquipmentService
    {    
        private readonly BarberEquipmentEFRepository _barberEquipmentRepository;
        private readonly IMapper _mapper;
        public BarberEquipmentService()
        {
            _barberEquipmentRepository = new BarberEquipmentEFRepository();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BarberEquipmentModel, BarberEquipment>().ReverseMap();

            });
            _mapper = new Mapper(mapperConfig);
        }

        public void Create(BarberEquipmentModel model)
        {
            var barberEquipment = _mapper.Map<BarberEquipment>(model);

            _barberEquipmentRepository.Create(barberEquipment);
        }

        public IEnumerable<BarberEquipmentModel> GetAll()
        {
            IEnumerable<BarberEquipment> models = _barberEquipmentRepository.GetAll();

            var mappedModels = _mapper.Map<IEnumerable<BarberEquipmentModel>>(models);

            return mappedModels;
        }

        public BarberEquipmentModel GetById(int id)
        {
            BarberEquipment model = _barberEquipmentRepository.GetById(id);
            return _mapper.Map<BarberEquipmentModel>(model);
        }

        public bool Delete(int id)
        {
            return _barberEquipmentRepository.Delete(id);
        }

        public BarberEquipmentModel UpdateBarber(BarberEquipmentModel model)
        {
            var barberEquipment = _mapper.Map<BarberEquipment>(model);

            var updatedBarberEquipment = _barberEquipmentRepository.Update(barberEquipment);

            return _mapper.Map<BarberEquipmentModel>(updatedBarberEquipment);
        }
    }
}
