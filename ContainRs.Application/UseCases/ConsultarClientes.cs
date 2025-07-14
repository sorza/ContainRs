using ContainRs.Application.Repositories;
using ContainRs.Domain.Models;

namespace ContainRs.Application.UseCases
{
    public class ConsultarClientes
    {
        private readonly IClienteRepository repository;
        public ConsultarClientes(UnidadeFederativa? estado, IClienteRepository repository)
        {
            Estado = estado;
            this.repository = repository;
        }

        public UnidadeFederativa? Estado { get; }

        public async Task<IEnumerable<Cliente>> ExecutarAsync(IClienteRepository repository)
        {
            if(Estado is not null)            
                return await repository.GetAsync(c => c.Estado == Estado);            
           
            return await repository.GetAsync();            
        }
    }
}
