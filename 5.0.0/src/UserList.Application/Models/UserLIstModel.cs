using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserList.Models
{
    public class UserLIstModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string personalnumber { get; set; }

       // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]

        public DateTime DateOfBirth { get; set; }
        public string Nationaly { get; set; }
        public Nullable<int> Salary { get; set; }
        public string PayrollCurrency { get; set; }
        public List<string> Phone { get; set; }
    }
}
