using System.Collections.Generic;
using AppGoat.Domain.Entities;

namespace AppGoat.Application.Services
{
    public interface IColorPromoAppService
    {
        IEnumerable<ColorPromo> GetColors();

        ColorPromo GetColor(byte id);

        void Add(ColorPromo element);

        void Edit(ColorPromo element);

        void Delete(byte id);
    }
}