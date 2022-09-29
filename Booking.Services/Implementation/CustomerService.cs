using AutoMapper;
using Booking.Dtos.BaseDTOs;
using Booking.Models;
using Booking.Repository.Abstractions;
using Booking.Services.Abstraction;

namespace Booking.Services.Implementation
{
    public class CustomerService : IBaseService<CustomerDto>, ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<CustomerDto>> GatAllAsync()
        {
            var customers = await _unitOfWork.CustomerRepository.GetAllAsync();
            var customersDto = _mapper.Map<IReadOnlyCollection<CustomerDto>>(customers);

            return customersDto;
        }

        public async Task<CustomerDto> GetAsync(int id)
        {
            var customer = await _unitOfWork.CustomerRepository.GetAsync(id);
            var customerDto = _mapper.Map<CustomerDto>(customer);

            return customerDto;
        }


        public async Task DeleteItemAsync(int id)
        {
            Customer customer = await _unitOfWork.CustomerRepository.GetAsync(id);

            if(customer != null)
            {
                await _unitOfWork.CustomerRepository.Delete(id);
                await _unitOfWork.CustomerRepository.CompleteAsync();
            }
        }

        public async Task CreateItemAsync(CustomerDto createCustomer)
        {
            var customers = await _unitOfWork.CustomerRepository.GetAllAsync();
            var customer = customers.FirstOrDefault(
                c => c.Name == createCustomer.Name
                && c.Surname == createCustomer.Surname 
                && c.PhoneNumber == createCustomer.PhoneNumber);

            if(customer == null)
            {
                customer = new Customer
                {
                    Name = createCustomer.Name,
                    Surname = createCustomer.Surname,
                    PhoneNumber = createCustomer.PhoneNumber,
                    Email = createCustomer.Email,
                    Instagram = createCustomer.Instagram,
                    Facebook = createCustomer.Facebook,
                    Telegram = createCustomer.Telegram
                };

                await _unitOfWork.CustomerRepository.CreateAsync(customer);
                await _unitOfWork.CustomerRepository.CompleteAsync();
            }
        }

        public async Task UpdateAsync(CustomerDto updateCustomer)
        {
            var customers = await _unitOfWork.CustomerRepository.GetAllAsync();
            var customer = customers.FirstOrDefault(
                c => c.Name == updateCustomer.Name
                && c.Surname == updateCustomer.Surname
                && c.PhoneNumber == updateCustomer.PhoneNumber);

            customer.Name = updateCustomer.Name;
            customer.Surname = updateCustomer.Surname;
            customer.PhoneNumber = updateCustomer.PhoneNumber;
            customer.Email = updateCustomer.Email;
            customer.Instagram = updateCustomer.Instagram;
            customer.Facebook = updateCustomer.Facebook;
            customer.Telegram = updateCustomer.Telegram;

            await _unitOfWork.CustomerRepository.CompleteAsync();
        }

        public Task<CustomerDto> GetAsync(string entity)
        {
            throw new NotImplementedException();
        }
    }
}