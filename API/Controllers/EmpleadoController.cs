using System.Formats.Asn1;
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
    public class EmpleadoController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmpleadoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<EmpleadoDto>>> Get([FromQuery] Params EmpleadoParams)
        {
            if (EmpleadoParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork
                .Empleados
                .GetAllAsync(EmpleadoParams.PageIndex, EmpleadoParams.PageSize);
            var EmpleadoListDto = _mapper.Map<List<EmpleadoDto>>(registers);
            return new Pager<EmpleadoDto>(
                EmpleadoListDto,
                totalRegisters,
                EmpleadoParams.PageIndex,
                EmpleadoParams.PageSize
            );
        }

        private ActionResult<Pager<EmpleadoDto>> BadRequest(ApiResponse apiResponse)
        {
            throw new NotImplementedException();
        }

        [HttpGet("v1")]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<IEnumerable<EmpleadoDto>>> Get1_1()
        {
            var registers = await _unitOfWork.Empleados.GetAllAsync();
            var EmpleadoListDto = _mapper.Map<List<EmpleadoDto>>(registers);
            return EmpleadoListDto;
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Empleado>> Post(EmpleadoDto EmpleadoDto)
        {
            var Empleado = _mapper.Map<Empleado>(EmpleadoDto);
            _unitOfWork.Empleados.Add(Empleado);
            await _unitOfWork.SaveAsync();
            EmpleadoDto.Id = Empleado.Id;
            return CreatedAtAction(nameof(Post), new { id = EmpleadoDto.Id }, EmpleadoDto);
        }

        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<EmpleadoDto>> Put(int id, [FromBody] EmpleadoDto EmpleadoDto)
        {
            if (EmpleadoDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var Empleado = _mapper.Map<Empleado>(EmpleadoDto);
            _unitOfWork.Empleados.Update(Empleado);
            await _unitOfWork.SaveAsync();
            return EmpleadoDto;
        }

        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Delete(int id)
        {
            var Empleado = await _unitOfWork.Empleados.GetByIdAsync(id);
            _unitOfWork.Empleados.Remove(Empleado);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpGet("GetEmployeeWithBossWithBoss")]
        [MapToApiVersion("1.0")]
        public async Task<
            ActionResult<IEnumerable<EmpleadoConJefesDto>>
        > GetEmployeeWithBossWithBoss()
        {
            var r = await _unitOfWork.Empleados.GetEmployeeWithBossWithBoss();
            return _mapper.Map<List<EmpleadoConJefesDto>>(r);
        }

        [HttpGet("EmployeesWhoHaveNoAssociatedCustomersWithOffice")]
        [MapToApiVersion("1.0")]
        public async Task<
            ActionResult<IEnumerable<EmpleadoConOficinaDto>>
        > EmployeesWhoHaveNoAssociatedCustomersWithOffice()
        {
            var r = await _unitOfWork.Empleados.EmployeesWhoHaveNoAssociatedCustomersWithOffice();
            return _mapper.Map<List<EmpleadoConOficinaDto>>(r);
        }

        [HttpGet("EmployeesWithoutOfficeNorCustomers")]
        [MapToApiVersion("1.0")]
        public async Task<
            ActionResult<IEnumerable<EmpleadoDto>>
        > EmployeesWithoutOfficeNorCustomers()
        {
            var r = await _unitOfWork.Empleados.EmployeesWithoutOfficeNorCustomers();
            return _mapper.Map<List<EmpleadoDto>>(r);
        }

        [HttpGet("EmployeesWithoutClientsPlusBossName")]
        [MapToApiVersion("1.0")]
        public async Task<
            ActionResult<IEnumerable<EmpleadoConNombreJefeDto>>
        > EmployeesWithoutClientsPlusBossName()
        {
            var r = await _unitOfWork.Empleados.EmployeesWithoutClientsPlusBossName();
            return _mapper.Map<List<EmpleadoConNombreJefeDto>>(r);
        }

        [HttpGet("HowManyEmployeesAreInTheCompany")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<object>> HowManyEmployeesAreInTheCompany()
        {
            int r = await _unitOfWork.Empleados.HowMany();
            var t = new Dictionary<string, int>() { { "Total Empleados", r } };
            return t;
        }
        [HttpGet("HowManyClientesBySalesRepresentativesEmployees")]
        public async Task<ActionResult<IEnumerable<EmpleadoNombreCuantosClientes>>> HowManyClientesBySalesRepresentativesEmployees()
        {
            var r = await _unitOfWork.Empleados.SalesRepresentativesEmployees();
            return _mapper.Map<List<EmpleadoNombreCuantosClientes>>(r);
        }
        [HttpGet("EmployeesWhoHaveNoAssociatedCustomersWithOfficeSpecificDto")]
        [MapToApiVersion("1.0")]
        public async Task<
            ActionResult<IEnumerable<EmpleadoConOficinaEspecifico>>
        > EmployeesWhoHaveNoAssociatedCustomersWithOfficeSpecificDto()
        {
            var r = await _unitOfWork.Empleados.EmployeesWhoHaveNoAssociatedCustomersWithOffice();
            return _mapper.Map<List<EmpleadoConOficinaEspecifico>>(r);
        }
    }
}
