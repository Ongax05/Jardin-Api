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
        public async Task<ActionResult<Pager<ClienteDto>>> Get(
            [FromQuery] Params ClienteParams
        )
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
        
        [HttpGet]
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
        public async Task<ActionResult<ClienteDto>> Put(
            int id,
            [FromBody] ClienteDto ClienteDto
        )
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
    }
}