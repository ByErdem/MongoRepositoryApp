using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract
{
    public interface IProductService
    {
        Task<ResponseDto<bool>> Add(ProductDto dto);
    }
}
