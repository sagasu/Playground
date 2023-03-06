using System.Collections.Concurrent;

namespace MinimalAPI.Models
{
    public interface ICustomerRepository
    {
        void Create(Customer? customer);
        Customer? GetById(Guid id);
        List<Customer> GetAll();
        void Update(Customer customer);
        bool Delete(Guid id);
    }

    public class CustomerRepository : ICustomerRepository
    {
        private readonly ConcurrentDictionary<Guid, Customer> _customers = new();
        
        public void Create(Customer? customer)
        {
            if (customer is null) return;

            _customers[customer.Id] = customer;
        }

        public Customer? GetById(Guid id) => _customers.ContainsKey(id) ? _customers[id] : null;
        

        public List<Customer> GetAll() => _customers.Values.ToList();
        
        public void Update(Customer customer)
        {
            var existingCustomer = GetById(customer.Id);
            if (existingCustomer is null) return;

            _customers[customer.Id] = customer;
        }

        public bool Delete(Guid id) => _customers.TryRemove(id, out _);
    }
}
