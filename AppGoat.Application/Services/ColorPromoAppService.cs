using AppGoat.Domain.Entities;
using AppGoat.Domain.RepositoryServices;
using System.Collections.Generic;
using System.Linq;

namespace AppGoat.Application.Services
{
    public class ColorPromoAppService : IColorPromoAppService
    {
        private readonly IColorPromoRepository _colorPromoRepository;

        public ColorPromoAppService(IColorPromoRepository colorPromoRepository)
        {
            _colorPromoRepository = colorPromoRepository;
        }


        public IEnumerable<ColorPromo> GetColors()
        {
            return _colorPromoRepository.GetElements().OrderBy(x => x.Name);
        }

        public ColorPromo GetColor(byte id)
        {
            return _colorPromoRepository.GetElement(id);
        }

        public void Add(ColorPromo element)
        {
            _colorPromoRepository.Add(element);
            _colorPromoRepository.SaveChanges();
        }

        public void Edit(ColorPromo element)
        {
            _colorPromoRepository.Edit(element);
            _colorPromoRepository.SaveChanges();
        }

        public void Delete(byte id)
        {
            _colorPromoRepository.Delete(id);
            _colorPromoRepository.SaveChanges();
        }
    }
}