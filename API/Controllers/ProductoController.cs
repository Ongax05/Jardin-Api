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
        public async Task<ActionResult<Pager<ProductoDto>>> Get(
            [FromQuery] Params ProductoParams
        )
        {
            if (ProductoParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.Productos.GetAllAsync(
                ProductoParams.PageIndex,
                ProductoParams.PageSize
            );
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
        
        [HttpGet]
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
        public async Task<ActionResult<ProductoDto>> Put(
            int id,
            [FromBody] ProductoDto ProductoDto
        )
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
    }
}