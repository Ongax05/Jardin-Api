using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductoController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<ProductoDto>>> Get([FromQuery] Params ProductoParams)
        {
            if (ProductoParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork
                .Productos
                .GetAllAsync(ProductoParams.PageIndex, ProductoParams.PageSize);
            var ProductoListDto = _mapper.Map<List<ProductoDto>>(registers);
            return new Pager<ProductoDto>(
                ProductoListDto,
                totalRegisters,
                ProductoParams.PageIndex,
                ProductoParams.PageSize
            );
        }

        private ActionResult<Pager<ProductoDto>> BadRequest(ApiResponse apiResponse)
        {
            throw new NotImplementedException();
        }

        [HttpGet("v1")]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> Get1_1()
        {
            var registers = await _unitOfWork.Productos.GetAllAsync();
            var ProductoListDto = _mapper.Map<List<ProductoDto>>(registers);
            return ProductoListDto;
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Producto>> Post(ProductoDto ProductoDto)
        {
            var Producto = _mapper.Map<Producto>(ProductoDto);
            _unitOfWork.Productos.Add(Producto);
            await _unitOfWork.SaveAsync();
            ProductoDto.Id = Producto.Id;
            return CreatedAtAction(nameof(Post), new { id = ProductoDto.Id }, ProductoDto);
        }

        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<ProductoDto>> Put(int id, [FromBody] ProductoDto ProductoDto)
        {
            if (ProductoDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var Producto = _mapper.Map<Producto>(ProductoDto);
            _unitOfWork.Productos.Update(Producto);
            await _unitOfWork.SaveAsync();
            return ProductoDto;
        }

        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Delete(string id)
        {
            var Producto = await _unitOfWork.Productos.GetByIdAsync(id);
            _unitOfWork.Productos.Remove(Producto);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpGet("GetProductsOrnamentalsWithMoreThan100Ordered")]
        [MapToApiVersion("1.0")]
        public async Task<
            ActionResult<IEnumerable<ProductoDto>>
        > GetProductsOrnamentalsWithMoreThan100Ordered()
        {
            var r = await _unitOfWork.Productos.GetProductsOrnamentalsWithMoreThan100Ordered();
            return _mapper.Map<List<ProductoDto>>(r);
        }

        [HttpGet("ProductsThatHaveNeverBeenOrdered")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> ProductsThatHaveNeverBeenOrdered()
        {
            var r = await _unitOfWork.Productos.ProductsThatHaveNeverBeenOrdered();
            return _mapper.Map<List<ProductoDto>>(r);
        }

        [HttpGet("ProductsThatHaveNeverBeenOrderedNameDescAndImg")]
        [MapToApiVersion("1.0")]
        public async Task<
            ActionResult<IEnumerable<ProductoNombreDescImg>>
        > ProductsThatHaveNeverBeenOrderedNameDescAndImg()
        {
            var r = await _unitOfWork.Productos.ProductsThatHaveNeverBeenOrderedNameDescAndImg();
            return _mapper.Map<List<ProductoNombreDescImg>>(r);
        }

        [HttpGet("Top20Products")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<IEnumerable<ProductoConCuantosVendidosDto>>> Top20Products()
        {
            var r = await _unitOfWork.Productos.Top20Products();
            var dtos = _mapper
                .Map<List<ProductoConCuantosVendidosDto>>(r)
                .OrderByDescending(p => p.Unidades_Vendidas)
                .ToList();
            return dtos;
        }
        [HttpGet("Top20ProductsGroupedByProductId")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<IEnumerable<object>>> Top20ProductsGroupedByProductId()
        {
            var r = await _unitOfWork.Productos.Top20Products();
            var dtos = _mapper
                .Map<List<ProductoConCuantosVendidosDto>>(r)
                .OrderByDescending(p => p.Unidades_Vendidas)
                .GroupBy(p=>p.Id)
                .Select(x => new { Id = x.Key, Items = x.ToList() })
                .ToList();
            return dtos;
        }
        [HttpGet("TopProductsGroupedByProductIdStartsWithOR")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<IEnumerable<object>>> TopProductsGroupedByProductIdStartsWithOR()
        {
            var r = await _unitOfWork.Productos.Top20Products();
            var dtos = _mapper
                .Map<List<ProductoConCuantosVendidosDto>>(r)
                .Where(p=>p.Id.StartsWith("OR"))
                .OrderByDescending(p => p.Unidades_Vendidas)
                .GroupBy(p=>p.Id)
                .Select(x => new { Id = x.Key, Items = x.ToList() })
                .ToList();
            return dtos;
        }
    }
}
