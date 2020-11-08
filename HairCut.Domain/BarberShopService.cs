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
    public class BarberShopService
    {
        private readonly BarberShopEFRepository _barberShopEFRepository;
        private readonly IMapper _mapper;
        public BarberShopService()
        {
            _barberShopEFRepository = new BarberShopEFRepository();
            var mapperConfig = new MapperConfiguration(cfg =>
            {              
                cfg.CreateMap<BarberShopModel, BarberShop>().ReverseMap();

            });
            _mapper = new Mapper(mapperConfig);
        }

        public void CreateBarberShop(BarberShopModel model)
        {
            var barberShop = _mapper.Map<BarberShop>(model);

            _barberShopEFRepository.Create(barberShop);
        }

        public IEnumerable<BarberShopModel> GetAll()
        {
            IEnumerable<BarberShop> models = _barberShopEFRepository.GetAll();

            var mappedModels = _mapper.Map<IEnumerable<BarberShopModel>>(models);

            return mappedModels;
        }

        public BarberShopModel GetById(int id)
        {
            BarberShop model = _barberShopEFRepository.GetById(id);
            return _mapper.Map<BarberShopModel>(model);
        }

        public bool Delete(int id)
        {
            return _barberShopEFRepository.Delete(id);
        }

        public BarberShopModel UpdateBarberShop(BarberShopModel model)
        {
            var barberShop = _mapper.Map<BarberShop>(model);

            var updatedBarberShop = _barberShopEFRepository.Update(barberShop);

            return _mapper.Map<BarberShopModel>(updatedBarberShop);
        }
    }
}
