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
        Task<ResponseDto<bool>> Nh_Add(ProductDto dto);
        Task<ResponseDto<bool>> Mg_Add(ProductDto dto);
        Task<ResponseDto<bool>> Ef_Add(ProductDto dto);
    }
}
