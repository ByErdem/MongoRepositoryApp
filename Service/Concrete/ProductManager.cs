using Data.Abstract;
using Entity.Concrete;
using Entity.Dtos;
using Service.Abstract;
using Shared.Utilities.ComplexTypes;

namespace Service.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _uow;

        public ProductManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ResponseDto<bool>> Nh_Add(ProductDto dto)
        {
            var rsp = new ResponseDto<bool>();
            var product = await _uow.NhProducts.GetAsync(x => x.Name == dto.Name);
            if (product == null)
            {
                await _uow.NhProducts.AddAsync(new Product
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

        public async Task<ResponseDto<bool>> Mg_Add(ProductDto dto)
        {
            var rsp = new ResponseDto<bool>();
            var product = await _uow.MgProducts.GetAsync(x => x.Name == dto.Name);
            if (product == null)
            {
                await _uow.MgProducts.AddAsync(new Product
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

        public Task<ResponseDto<bool>> Ef_Add(ProductDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
