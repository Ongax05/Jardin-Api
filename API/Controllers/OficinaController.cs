using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    // [Authorize(Roles = "Employee,Admin")]
    public class OficinaController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OficinaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<OficinaDto>>> Get([FromQuery] Params OficinaParams)
        {
            if (OficinaParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.Oficinas.GetAllAsync(
                OficinaParams.PageIndex,
                OficinaParams.PageSize
            );
            var OficinaListDto = _mapper.Map<List<OficinaDto>>(registers);
            return new Pager<OficinaDto>(
                OficinaListDto,
                totalRegisters,
                OficinaParams.PageIndex,
                OficinaParams.PageSize
            );
        }

        private ActionResult<Pager<OficinaDto>> BadRequest(ApiResponse apiResponse)
        {
            throw new NotImplementedException();
        }

        [HttpGet("v1")]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<IEnumerable<OficinaDto>>> Get1_1()
        {
            var registers = await _unitOfWork.Oficinas.GetAllAsync();
            var OficinaListDto = _mapper.Map<List<OficinaDto>>(registers);
            return OficinaListDto;
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Oficina>> Post(OficinaDto OficinaDto)
        {
            var Oficina = _mapper.Map<Oficina>(OficinaDto);
            _unitOfWork.Oficinas.Add(Oficina);
            await _unitOfWork.SaveAsync();
            OficinaDto.Id = Oficina.Id;
            return CreatedAtAction(nameof(Post), new { id = OficinaDto.Id }, OficinaDto);
        }

        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<OficinaDto>> Put(int id, [FromBody] OficinaDto OficinaDto)
        {
            if (OficinaDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var Oficina = _mapper.Map<Oficina>(OficinaDto);
            _unitOfWork.Oficinas.Update(Oficina);
            await _unitOfWork.SaveAsync();
            return OficinaDto;
        }

        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Delete(string id)
        {
            var Oficina = await _unitOfWork.Oficinas.GetByIdAsync(id);
            _unitOfWork.Oficinas.Remove(Oficina);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpGet("OfficesWhereEmployeesOfCustomersWhoPurchaseFruitProductsDontWork")]
        [MapToApiVersion("1.0")]
        public async Task<
            ActionResult<IEnumerable<OficinaDto>>
        > OfficesWhereEmployeesOfCustomersWhoPurchaseFruitProductsDontWork()
        {
            var Clients = await _unitOfWork.Clientes.RangesPurchasedByEachCustomer();
            var OficceIds = Clients
                .Where(
                    c =>
                        c.Pedidos
                            .SelectMany(p => p.Detalles_Pedidos.DistinctBy(p => p.Producto))
                            .Select(p => p.Producto)
                            .Select(p => p.Gama_ProductoId)
                            .Contains("Frutales")
                )
                .Select(c => c.Empleado)
                .Select(e => e.OficinaId)
                .ToList();
            var offices = await _unitOfWork.Oficinas.NotOfficesByIdList(OficceIds);
            return _mapper.Map<List<OficinaDto>>(offices);
        }
    }
}
