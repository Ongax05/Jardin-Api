using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ClienteController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClienteController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<ClienteDto>>> Get([FromQuery] Params ClienteParams)
        {
            if (ClienteParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.Clientes.GetAllAsync(
                ClienteParams.PageIndex,
                ClienteParams.PageSize
            );
            var ClienteListDto = _mapper.Map<List<ClienteDto>>(registers);
            return new Pager<ClienteDto>(
                ClienteListDto,
                totalRegisters,
                ClienteParams.PageIndex,
                ClienteParams.PageSize
            );
        }

        private ActionResult<Pager<ClienteDto>> BadRequest(ApiResponse apiResponse)
        {
            throw new NotImplementedException();
        }

        [HttpGet("v1")]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> Get1_1()
        {
            var registers = await _unitOfWork.Clientes.GetAllAsync();
            var ClienteListDto = _mapper.Map<List<ClienteDto>>(registers);
            return ClienteListDto;
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Cliente>> Post(ClienteDto ClienteDto)
        {
            var Cliente = _mapper.Map<Cliente>(ClienteDto);
            _unitOfWork.Clientes.Add(Cliente);
            await _unitOfWork.SaveAsync();
            ClienteDto.Id = Cliente.Id;
            return CreatedAtAction(nameof(Post), new { id = ClienteDto.Id }, ClienteDto);
        }

        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<ClienteDto>> Put(int id, [FromBody] ClienteDto ClienteDto)
        {
            if (ClienteDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var Cliente = _mapper.Map<Cliente>(ClienteDto);
            _unitOfWork.Clientes.Update(Cliente);
            await _unitOfWork.SaveAsync();
            return ClienteDto;
        }

        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Delete(int id)
        {
            var Cliente = await _unitOfWork.Clientes.GetByIdAsync(id);
            _unitOfWork.Clientes.Remove(Cliente);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpGet("GetSpanishCustomersNames")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<List<NombresClientesDto>>> GetSpanishCustomersNames()
        {
            var r = await _unitOfWork.Clientes.GetSpanishCustomersNames();
            return _mapper.Map<List<NombresClientesDto>>(r);
        }

        [HttpGet("GetClientsFromMadridWithEmployeeRepresentant30Or11")]
        [MapToApiVersion("1.0")]
        public async Task<
            ActionResult<List<ClienteDto>>
        > GetClientsFromMadridWithEmployeeRepresentant30Or11()
        {
            var r = await _unitOfWork.Clientes.GetClientsFromMadridWithEmployeeRepresentant30Or11();
            return _mapper.Map<List<ClienteDto>>(r);
        }

        [HttpGet("GetClientsWithRepSalInfo")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<List<ClientsWithRepSalInfoDto>>> GetClientsWithRepSalInfo()
        {
            var r = await _unitOfWork.Clientes.GetClientsWithEmployee();
            return _mapper.Map<List<ClientsWithRepSalInfoDto>>(r);
        }

        [HttpGet("GetClientsWithRepSalInfoIfHavePayments")]
        [MapToApiVersion("1.0")]
        public async Task<
            ActionResult<List<ClientsWithRepSalInfoDto>>
        > GetClientsWithRepSalInfoIfHavePayments()
        {
            var r = await _unitOfWork.Clientes.GetClientsWithRepSalInfoIfHavePayments();
            return _mapper.Map<List<ClientsWithRepSalInfoDto>>(r);
        }

        [HttpGet("GetClientsWithRepSalInfoIfDontHavePayments")]
        [MapToApiVersion("1.0")]
        public async Task<
            ActionResult<List<ClientsWithRepSalInfoDto>>
        > GetClientsWithRepSalInfoIfDontHavePayments()
        {
            var r = await _unitOfWork.Clientes.GetClientsWithRepSalInfoIfDontHavePayments();
            return _mapper.Map<List<ClientsWithRepSalInfoDto>>(r);
        }

        [HttpGet("GetClientsWithRepSalInfoIfHavePaymentsPlusOfficeCity")]
        [MapToApiVersion("1.0")]
        public async Task<
            ActionResult<List<ClientsWithRepSalInfoPlusOfficeCityDto>>
        > GetClientsWithRepSalInfoIfHavePaymentsPlusOfficeCity()
        {
            var r = await _unitOfWork.Clientes.GetClientsWithRepSalInfoIfHavePayments();
            return _mapper.Map<List<ClientsWithRepSalInfoPlusOfficeCityDto>>(r);
        }

        [HttpGet("GetClientsWithRepSalInfoIfDontHavePaymentsPlusOfficeCity")]
        [MapToApiVersion("1.0")]
        public async Task<
            ActionResult<List<ClientsWithRepSalInfoPlusOfficeCityDto>>
        > GetClientsWithRepSalInfoIfDontHavePaymentsPlusOfficeCity()
        {
            var r = await _unitOfWork.Clientes.GetClientsWithRepSalInfoIfDontHavePayments();
            return _mapper.Map<List<ClientsWithRepSalInfoPlusOfficeCityDto>>(r);
        }

        [HttpGet("GetClientsWhoHaveReceivedABackorder")]
        [MapToApiVersion("1.0")]
        public async Task<
            ActionResult<List<ClienteNombreDto>>
        > GetClientsWhoHaveReceivedABackorder()
        {
            var BackOrders = await _unitOfWork.Pedidos.GetBackOrders();
            var ClientIds = BackOrders.Select(x => x.ClienteId).ToList();
            var r = await _unitOfWork.Clientes.GetClientsWhoHaveReceivedABackorder(ClientIds);
            return _mapper.Map<List<ClienteNombreDto>>(r);
        }

        [HttpGet("RangesPurchasedByEachCustomer")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<List<ClienteConGamas>>> RangesPurchasedByEachCustomer()
        {
            var r = await _unitOfWork.Clientes.RangesPurchasedByEachCustomer();
            List<ClienteConGamas> clientes = new();
            foreach (var c in r)
            {
                var gamas = c.Pedidos
                    .SelectMany(p => p.Detalles_Pedidos.Select(d => d.Producto.Gama_ProductoId))
                    .Distinct()
                    .ToList();
                ClienteConGamas cliente =
                    new() { Nombre_Cliente = c.Nombre_Cliente, Gamas = gamas };
                clientes.Add(cliente);
            }
            return clientes;
        }

        [HttpGet("CustomersWhoHaveNotMadePayments")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> CustomersWhoHaveNotMadePayments()
        {
            var r = await _unitOfWork.Clientes.CustomersWhoHaveNotMadePayments();
            return _mapper.Map<List<ClienteDto>>(r);
        }

        [HttpGet("CustomersWhoHaveNotMadePaymentsOrPlacedOrders")]
        [MapToApiVersion("1.0")]
        public async Task<
            ActionResult<IEnumerable<ClienteDto>>
        > CustomersWhoHaveNotMadePaymentsOrPlacedOrders()
        {
            var r = await _unitOfWork.Clientes.CustomersWhoHaveNotMadePaymentsOrPlacedOrders();
            return _mapper.Map<List<ClienteDto>>(r);
        }

        [HttpGet("CustomersWithOrdersButNotPayments")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> CustomersWithOrdersButNotPayments()
        {
            var r = await _unitOfWork.Clientes.CustomersWithOrdersButNotPayments();
            return _mapper.Map<List<ClienteDto>>(r);
        }
    }
}
