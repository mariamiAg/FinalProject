using FinalProject.BusinesLogic.Contracts;
using FinalProject.DataAccess;
using FinalProject.DomainModels;
using FinalProject.Repositories.Repository;
using static FinalProject.BusinesLogic.Services.CustomerService;

namespace FinalProject.BusinesLogic.Services
{
    public class CustomerService : ICustomerService
    {
      public readonly CustomerRepository _customerRepository;

            public CustomerService(CustomerRepository customerRepository)
            {
                this._customerRepository = customerRepository;
            }

            public CustomerDTO GetCustomerById(int customerID)
            {
                var customer2 = _customerRepository.Get(customerID);
                var result = new CustomerDTO
                {
                    Id = customer2.Id,
                    FirstName = customer2.FirstName,
                    LastName = customer2.LastName,
                    Gender = customer2.Gender,
                    BirthDate = customer2.BirthDate,
                    PersonalNumber = customer2.PersonalNumber,
                    CustomersPhoneNumbers = customer2.CustomersPhoneNumbers,
                    Email = customer2.Email,
                    City = customer2.City,
                    Country = customer2.Country,
                };
                return result;
            }
            public List<CustomerDTO> GetCustomer()
            {
                var customer2 = _customerRepository.GetAll();
                List<CustomerDTO> result = customer2.Select(customer_2 => new CustomerDTO
                {
                    Id = customer_2.Id,
                    FirstName = customer_2.FirstName,
                    LastName = customer_2.LastName,
                    Gender = customer_2.Gender,
                    BirthDate = customer_2.BirthDate,
                    PersonalNumber = customer_2.PersonalNumber,
                    CustomersPhoneNumbers = customer_2.CustomersPhoneNumbers,
                    Email = customer_2.Email,
                    City = customer_2.City,
                    Country = customer_2.Country,
                }
                ).ToList();

                return result;
            }
            public bool CreateNewCustomer(CustomerDTO customer)
            {

                try
                {
                    if (customer == null || !customer.Id.HasValue)
                        throw new Exception("Invalid Data");
                    Customer customer1 = new Customer();
                    customer1.FirstName = customer.FirstName;
                    customer1.LastName = customer.LastName;
                    customer1.Gender = customer.Gender;
                    customer1.BirthDate = customer.BirthDate;
                    customer1.PersonalNumber = customer.PersonalNumber;
                    customer1.CustomersPhoneNumbers = customer.CustomersPhoneNumbers;
                    customer1.Email = customer.Email;
                    customer1.City = customer.City;
                    customer1.Country = customer.Country;
                    _customerRepository.Insert(customer1);
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            public bool EditCustomer(CustomerDTO customer)
            {

                try
                {
                    if (customer == null || !customer.Id.HasValue)
                        throw new Exception("Invalid Data");

                    var customer_1 = _customerRepository.Get(customer.Id.Value);
                    customer_1.FirstName = customer.FirstName;
                    customer_1.LastName = customer.LastName;
                    customer_1.Gender = customer.Gender;
                    customer_1.BirthDate = customer.BirthDate;
                    customer_1.CustomersPhoneNumbers = customer.CustomersPhoneNumbers;
                    customer_1.Email = customer.Email;
                    customer_1.City = customer.City;
                    customer_1.Country = customer.Country;
                    _customerRepository.Update(customer_1);
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            public bool DeleteCustomer(int customerId)
            {

                try
                {
                    var customer = _customerRepository.Get(customerId);
                    if (customer == null)
                        throw new Exception("ERROR");
                    _customerRepository.Delete(customer);
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }
    }
