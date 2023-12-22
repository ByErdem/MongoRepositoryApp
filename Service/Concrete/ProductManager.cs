using Data.Abstract;
using Entity.Concrete;
using Entity.Dtos;
using Service.Abstract;
using Shared.Utilities.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _uow;

        public ProductManager(IUnitOfWork uow)
        {
            _uow = uow;
        }


        public async Task<ResponseDto<bool>> Add(ProductDto dto)
        {
            var rsp = new ResponseDto<bool>();
            var product = await _uow.Products.GetAsync(x => x.Name == dto.Name);
            if (product == null)
            {
                await _uow.Products.AddAsync(new Product
                {
                    Name = dto.Name,
                    Quantity = dto.Quantity,
                    Value = dto.Value,
                });
            }

            rsp.SuccessMessage = "Ürün başarılı bir şekilde eklendi.";
            rsp.Data = true;
            rsp.ResultStatus = ResultStatus.Success;
            return rsp;
        }
    }
}
