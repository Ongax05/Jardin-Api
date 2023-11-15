using Aplication.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Persistency;

namespace Aplication.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiDbContext _context;
    private IRolRepository _roles;
    private IUserRepository _users;

    public UnitOfWork(ApiDbContext context)
    {
        _context = context;
    }

    public IRolRepository Roles
    {
        get
        {
            _roles ??= new RolRepository(_context);
            return _roles;
        }
    }

    public IUserRepository Users
    {
        get
        {
            _users ??= new UserRepository(_context);
            return _users;
        }
    }

    private ICliente _Clientes;
    public ICliente Clientes
    {
        get
        {
            _Clientes ??= new ClienteRepository(_context);
            return _Clientes;
        }
    }
    private IEmpleado _Empleados;
    public IEmpleado Empleados
    {
        get
        {
            _Empleados ??= new EmpleadoRepository(_context);
            return _Empleados;
        }
    }
    private IGama_Producto _Gamas_Productos;
    public IGama_Producto Gamas_Productos
    {
        get
        {
            _Gamas_Productos ??= new Gama_ProductoRepository(_context);
            return _Gamas_Productos;
        }
    }
    private IOficina _Oficinas;
    public IOficina Oficinas
    {
        get
        {
            _Oficinas ??= new OficinaRepository(_context);
            return _Oficinas;
        }
    }
    private IPago _Pagos;
    public IPago Pagos
    {
        get
        {
            _Pagos ??= new PagoRepository(_context);
            return _Pagos;
        }
    }
    private IPedido _Pedidos;
    public IPedido Pedidos
    {
        get
        {
            _Pedidos ??= new PedidoRepository(_context);
            return _Pedidos;
        }
    }
    private IProducto _Productos;
    public IProducto Productos
    {
        get
        {
            _Productos ??= new ProductoRepository(_context);
            return _Productos;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
