using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AddressRepository
    {
        private readonly ApplicationContext _repository;

        public AddressRepository(ApplicationContext repository)
        {
            _repository = repository;
        }

        public Address? GetAddressById(int id)
        {
            return _repository.Addresses.Include(a => a.User).FirstOrDefault(a => a.Id == id);
        }
    }
}
