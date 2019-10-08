using Majestic.Domain.MajesticContext;
using Majestic.Domain.Repositories.Interfaces;
using Majestic.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Majestic.Domain.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        MajesticDbContext _db = new MajesticDbContext();
        public Address AddAddress(Address address)
        {
            var IsExists = IsAddressExists(address.StreetAddress,address.City,address.PinCode);

            if (address != null)
            {
                address.AddressType = address.AddressType.ToUpper();
                address.City = address.City.ToUpper();
                address.State = address.State.ToUpper();
                address.StreetAddress = address.StreetAddress.ToUpper();
                address.FullName = address.FullName.ToUpper();

                _db.Addresses.Add(address);
                _db.SaveChanges();
                 return address;
            }
            

            

            return address;
        }

        public Address GetAddress(string id)
        {
            var getTheId = _db.Addresses.Where(uId => uId.CustomerId == id).Select(uId => uId.Id).FirstOrDefault();
            var findById = _db.Addresses.Find(getTheId);
            if (findById == null)
            {
                return null;
            }
            return findById;
        }

        public bool IsAddressExists(string streetAddress, string city, string pinCode)
        {
            var isExists = _db.Addresses.Where(address => address.StreetAddress == streetAddress && address.City == city && address.PinCode == pinCode).FirstOrDefault();

            return isExists != null;


        }
    }
}
