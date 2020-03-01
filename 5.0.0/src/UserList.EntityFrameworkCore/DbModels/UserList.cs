using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserList.DbModels
{
    public partial class UserLists
    {
        public UserLists()
        {
            UserPhone = new HashSet<UserPhone>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationaly { get; set; }
        public int? Salary { get; set; }
        public string PayrollCurrency { get; set; }

        public virtual ICollection<UserPhone> UserPhone { get; set; }
    }

    public class UserListConfiguration : IEntityTypeConfiguration<UserLists>
    {
        public void Configure(EntityTypeBuilder<UserLists> entity)
        {
            entity.ToTable("UserLists");

            entity.Property(e => e.DateOfBirth).HasColumnType("date");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.Nationaly)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.PayrollCurrency).HasMaxLength(10);

            entity.Property(e => e.PersonalNumber)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.Surname)
                .IsRequired()
                .HasMaxLength(50);

        }
    }

}
