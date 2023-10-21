using FinalProject.DataAccess;
using FinalProject.DomainModels;

namespace FinalProject.BusinesLogic.Contracts
{
    public interface ICustomerService
    {
        List<CustomerDTO> GetCustomer();
        CustomerDTO GetCustomerById(int customerID);
        bool CreateNewCustomer(CustomerDTO customer);
        bool EditCustomer(CustomerDTO customer);
        bool DeleteCustomer(int customerId);


    }
}
