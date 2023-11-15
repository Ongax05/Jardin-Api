using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class Gama_ProductoController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public Gama_ProductoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<Gama_ProductoDto>>> Get(
            [FromQuery] Params Gama_ProductoParams
        )
        {
            if (Gama_ProductoParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.Gamas_Productos.GetAllAsync(
                Gama_ProductoParams.PageIndex,
                Gama_ProductoParams.PageSize
            );
            var Gama_ProductoListDto = _mapper.Map<List<Gama_ProductoDto>>(registers);
            return new Pager<Gama_ProductoDto>(
                Gama_ProductoListDto,
                totalRegisters,
                Gama_ProductoParams.PageIndex,
                Gama_ProductoParams.PageSize
            );
        }
        
        private ActionResult<Pager<Gama_ProductoDto>> BadRequest(ApiResponse apiResponse)
        {
        throw new NotImplementedException();
        }
        
        [HttpGet]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<IEnumerable<Gama_ProductoDto>>> Get1_1()
        {
            var registers = await _unitOfWork.Gamas_Productos.GetAllAsync();
            var Gama_ProductoListDto = _mapper.Map<List<Gama_ProductoDto>>(registers);
            return Gama_ProductoListDto;
        }
        
        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Gama_Producto>> Post(Gama_ProductoDto Gama_ProductoDto)
        {
            var Gama_Producto = _mapper.Map<Gama_Producto>(Gama_ProductoDto);
            _unitOfWork.Gamas_Productos.Add(Gama_Producto);
            await _unitOfWork.SaveAsync();
            Gama_ProductoDto.Id = Gama_Producto.Id;
            return CreatedAtAction(nameof(Post), new { id = Gama_ProductoDto.Id }, Gama_ProductoDto);
        }
        
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Gama_ProductoDto>> Put(
            int id,
            [FromBody] Gama_ProductoDto Gama_ProductoDto
        )
        {
            if (Gama_ProductoDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var Gama_Producto = _mapper.Map<Gama_Producto>(Gama_ProductoDto);
            _unitOfWork.Gamas_Productos.Update(Gama_Producto);
            await _unitOfWork.SaveAsync();
            return Gama_ProductoDto;
        }
        
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Delete(string id)
        {
            var Gama_Producto = await _unitOfWork.Gamas_Productos.GetByIdAsync(id);
            _unitOfWork.Gamas_Productos.Remove(Gama_Producto);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}