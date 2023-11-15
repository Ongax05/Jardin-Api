using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PagoController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public PagoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<PagoDto>>> Get(
            [FromQuery] Params PagoParams
        )
        {
            if (PagoParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.Pagos.GetAllAsync(
                PagoParams.PageIndex,
                PagoParams.PageSize
            );
            var PagoListDto = _mapper.Map<List<PagoDto>>(registers);
            return new Pager<PagoDto>(
                PagoListDto,
                totalRegisters,
                PagoParams.PageIndex,
                PagoParams.PageSize
            );
        }
        
        private ActionResult<Pager<PagoDto>> BadRequest(ApiResponse apiResponse)
        {
        throw new NotImplementedException();
        }
        
        [HttpGet]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<IEnumerable<PagoDto>>> Get1_1()
        {
            var registers = await _unitOfWork.Pagos.GetAllAsync();
            var PagoListDto = _mapper.Map<List<PagoDto>>(registers);
            return PagoListDto;
        }
        
        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pago>> Post(PagoDto PagoDto)
        {
            var Pago = _mapper.Map<Pago>(PagoDto);
            _unitOfWork.Pagos.Add(Pago);
            await _unitOfWork.SaveAsync();
            PagoDto.Id = Pago.Id;
            return CreatedAtAction(nameof(Post), new { id = PagoDto.Id }, PagoDto);
        }
        
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<PagoDto>> Put(
            int id,
            [FromBody] PagoDto PagoDto
        )
        {
            if (PagoDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var Pago = _mapper.Map<Pago>(PagoDto);
            _unitOfWork.Pagos.Update(Pago);
            await _unitOfWork.SaveAsync();
            return PagoDto;
        }
        
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Delete(string id)
        {
            var Pago = await _unitOfWork.Pagos.GetByIdAsync(id);
            _unitOfWork.Pagos.Remove(Pago);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}