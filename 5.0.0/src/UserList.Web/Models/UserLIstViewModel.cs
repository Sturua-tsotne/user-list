using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserList.Web.Models
{
    public class UserLIstViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }  
        public string Surname { get; set; }
        public string personalnumber { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime DateOfBirth { get; set; }
        public string Nationaly { get; set; }  
        public Nullable<int> Salary { get; set; }
        public string PayrollCurrency { get; set; }
        public List<string>Phone{ get; set; }
    }
}
