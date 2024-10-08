using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AddressRepository: BaseRepository<Address>,IAddressRepository
    {
        private readonly ApplicationContext _repository;

        public AddressRepository(ApplicationContext repository) : base(repository) 
        {
            _repository = repository;
        }

        //public Address? GetAddressById(int id)
        //{
        //    return _repository.Addresses.Include(a => a.User).FirstOrDefault(a => a.Id == id);
        //}
    }
}
