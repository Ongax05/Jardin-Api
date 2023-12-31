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
    public class PedidoController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PedidoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<PedidoDto>>> Get([FromQuery] Params PedidoParams)
        {
            if (PedidoParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.Pedidos.GetAllAsync(
                PedidoParams.PageIndex,
                PedidoParams.PageSize
            );
            var PedidoListDto = _mapper.Map<List<PedidoDto>>(registers);
            return new Pager<PedidoDto>(
                PedidoListDto,
                totalRegisters,
                PedidoParams.PageIndex,
                PedidoParams.PageSize
            );
        }

        private ActionResult<Pager<PedidoDto>> BadRequest(ApiResponse apiResponse)
        {
            throw new NotImplementedException();
        }

        [HttpGet("v1")]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<IEnumerable<PedidoDto>>> Get1_1()
        {
            var registers = await _unitOfWork.Pedidos.GetAllAsync();
            var PedidoListDto = _mapper.Map<List<PedidoDto>>(registers);
            return PedidoListDto;
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pedido>> Post(PedidoDto PedidoDto)
        {
            var Pedido = _mapper.Map<Pedido>(PedidoDto);
            _unitOfWork.Pedidos.Add(Pedido);
            await _unitOfWork.SaveAsync();
            PedidoDto.Id = Pedido.Id;
            return CreatedAtAction(nameof(Post), new { id = PedidoDto.Id }, PedidoDto);
        }

        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<PedidoDto>> Put(int id, [FromBody] PedidoDto PedidoDto)
        {
            if (PedidoDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var Pedido = _mapper.Map<Pedido>(PedidoDto);
            _unitOfWork.Pedidos.Update(Pedido);
            await _unitOfWork.SaveAsync();
            return PedidoDto;
        }

        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Delete(int id)
        {
            var Pedido = await _unitOfWork.Pedidos.GetByIdAsync(id);
            _unitOfWork.Pedidos.Remove(Pedido);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpGet("GetOrderstates")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<IEnumerable<EstadosDeOrdenDto>>> GetOrderstates()
        {
            var r = await _unitOfWork.Pedidos.GetAllAsync();
            var re = _mapper.Map<List<EstadosDeOrdenDto>>(r.DistinctBy(m => m.Estado));
            return re;
        }

        [HttpGet("GetBackOrders")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<IEnumerable<ResumenPedidoEsEnDto>>> GetBackOrders()
        {
            var r = await _unitOfWork.Pedidos.GetBackOrders();
            return _mapper.Map<List<ResumenPedidoEsEnDto>>(r);
        }

        [HttpGet("GetOrdersTwoDaysEarlier")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<IEnumerable<ResumenPedidoEsEnDto>>> GetOrdersTwoDaysEarlier()
        {
            var r = await _unitOfWork.Pedidos.GetOrdersTwoDaysEarlier();
            return _mapper.Map<List<ResumenPedidoEsEnDto>>(r);
        }

        [HttpGet("GetRejectedOrdersIn2009")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<IEnumerable<PedidoDto>>> GetRejectedOrdersIn2009()
        {
            var r = await _unitOfWork.Pedidos.GetRejectedOrdersIn2009();
            return _mapper.Map<List<PedidoDto>>(r);
        }

        [HttpGet("GetOrdersInJanuary")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<IEnumerable<PedidoDto>>> GetOrdersInJanuary()
        {
            var r = await _unitOfWork.Pedidos.GetOrdersInJanuary();
            return _mapper.Map<List<PedidoDto>>(r);
        }

        [HttpGet("HowManyOrdersByState")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<List<object>>> HowManyOrdersByState()
        {
            var r = await _unitOfWork.Pedidos.GetAllAsync();
            var sorted = r.GroupBy(p => p.Estado)
                .Select(g => new { Estado = g.Key, Total = g.Count() })
                .OrderByDescending(p => p.Total)
                .ToList();

            return Ok(sorted);
        }

        [HttpGet("ProductsDifferentByOrder")]
        [MapToApiVersion("1.0")]
        public async Task<
            ActionResult<List<PedidoConCuantosProductosDistintos>>
        > ProductsDifferentByOrder()
        {
            var r = await _unitOfWork.Pedidos.ProductsDifferentByOrder();
            return _mapper.Map<List<PedidoConCuantosProductosDistintos>>(r);
        }

        [HttpGet("ProductsByOrder")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<List<PedidoConCuantosProductos>>> ProductstByOrder()
        {
            var r = await _unitOfWork.Pedidos.ProductsDifferentByOrder();
            return _mapper.Map<List<PedidoConCuantosProductos>>(r);
        }
    }
}
