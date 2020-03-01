using System;
using System.Collections.Generic;
using System.Text;
using UserList.EntityFrameworkCore;
using System.Linq;
using UserList.Models;
using UserList.DbModels;

namespace UserList.Services
{
    public class UserServices : IUserServices
    {
        private readonly UserListDbContext _context;

        public UserServices(UserListDbContext userListDbContext)
        {
            _context = userListDbContext;
        }

        public bool AddUsers(UserLIstModel userLIstModel)
        {
            var P = new List<UserPhone>();
            foreach (var item in userLIstModel.Phone)
            {
                P.Add(new UserPhone { Phone = item.ToString() });
            }


            var a = _context.UserList.Select(x => x).Count();
            _context.UserList.Add(new DbModels.UserLists
            {
                DateOfBirth = userLIstModel.DateOfBirth,
                Name = userLIstModel.Name,
                Surname = userLIstModel.Surname,
                Nationaly = userLIstModel.Nationaly,
                PayrollCurrency = userLIstModel.PayrollCurrency,
                PersonalNumber = userLIstModel.personalnumber,
                Salary = userLIstModel.Salary,
                UserPhone = P,


            });
            _context.SaveChanges();
            return true;
        }


        public List<UserLIstModel> GetUser(UserLIstModel UserLIstModel)
        {
            var result = new List<UserLIstModel>();

            //result = (from P in _context.UserPhone
            //          join u in _context.UserList on P.UserListId equals u.Id
            //          select new UserLIstModel

            result= _context.UserList.Select(u => new UserLIstModel
            {
                Id = u.Id,
                Name = u.Name,
                Surname = u.Surname,
                DateOfBirth = u.DateOfBirth,
                Nationaly = u.Nationaly,
                PayrollCurrency = u.PayrollCurrency,
                personalnumber = u.PersonalNumber,
                Salary = u.Salary,
                Phone = u.UserPhone.Select(x=>x.Phone).ToList(),
            }).ToList();

            return result;



        }

        public UserLIstModel Edit(int id)
        {


            var resultdb = _context.UserList.Where(x => x.Id == id).Select(x => new UserLIstModel
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                personalnumber = x.PersonalNumber,
                PayrollCurrency = x.PayrollCurrency,
                DateOfBirth = x.DateOfBirth,
                Nationaly = x.Nationaly,
                Salary = x.Salary,
                Phone = x.UserPhone.Select(p => p.Phone).ToList()

            }).FirstOrDefault();

            return resultdb;
        }
        public bool Edit(UserLIstModel userLIstModel)
        {
            var u = _context.UserList.FirstOrDefault(x => x.Id == userLIstModel.Id);



            u.Id = userLIstModel.Id;
            u.Name = userLIstModel.Name;
            u.Surname = userLIstModel.Surname;
            u.PersonalNumber = userLIstModel.personalnumber;
            u.PayrollCurrency = userLIstModel.PayrollCurrency;
            u.DateOfBirth = userLIstModel.DateOfBirth;
            u.Nationaly = userLIstModel.Nationaly;
            u.Salary = userLIstModel.Salary;
            u.UserPhone =  userLIstModel.Phone.Select(p=> new UserPhone {Phone=p }).ToList();


            _context.SaveChanges();

            return true;
        }
        public bool Delete(int id)
        {

            _context.UserList.RemoveRange(_context.UserList.Where(x => x.Id == id));
            _context.UserPhone.RemoveRange(_context.UserPhone.Where(x => x.UserListId == id));
            _context.SaveChanges();
            return true;
        }
    }
}
