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
    public class BarberService
    {
        private readonly BarberEFRepository _barberRepository;
        private readonly IMapper _mapper;
        public BarberService()
        {
            _barberRepository = new BarberEFRepository();
            var mapperConfig = new MapperConfiguration(cfg =>
            {           
                cfg.CreateMap<BarberModel, Barber>().ReverseMap();
                
            });
            _mapper = new Mapper(mapperConfig);
        }

        public void CreateBarber(BarberModel model)
        {
            var barber = _mapper.Map<Barber>(model);

            _barberRepository.Create(barber);
        }

        public IEnumerable<BarberModel> GetAll()
        {
            IEnumerable<Barber> models = _barberRepository.GetAll();

            var mappedModels = _mapper.Map<IEnumerable<BarberModel>>(models);

            return mappedModels;
        }

        public BarberModel GetById(int id)
        {
            Barber model = _barberRepository.GetById(id);
            return _mapper.Map<BarberModel>(model);
        }

        public bool Delete(int id)
        {
            return _barberRepository.Delete(id);
        }

        public BarberModel UpdateBarber(BarberModel model)
        {
            var barber = _mapper.Map<Barber>(model);

            var updatedBarber = _barberRepository.Update(barber);

            return _mapper.Map<BarberModel>(updatedBarber);
        }
    }
}
