using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Entity;
using System.Reflection;
using UserList.DbModels;

namespace UserList.EntityFrameworkCore
{
    public class UserListDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...

        public UserListDbContext(DbContextOptions<UserListDbContext> options) 
            : base(options)
        {

        }


        public virtual Microsoft.EntityFrameworkCore.DbSet<UserLists> UserList { get; set; }
       public virtual Microsoft.EntityFrameworkCore.DbSet<UserPhone> UserPhone { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UserListConfiguration());


            //modelBuilder.ApplyEntityTypeConfigurations(Assembly.GetExecutingAssembly());


            //modelBuilder.Entity<UserLists>(entity =>
            //{
            //    entity.Property(e => e.DateOfBirth).HasColumnType("date");

            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.Nationaly)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.PayrollCurrency).HasMaxLength(10);

            //    entity.Property(e => e.PersonalNumber)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.Surname)
            //        .IsRequired()
            //        .HasMaxLength(50);
            //});

            //modelBuilder.Entity<UserPhone>(entity =>
            //{
            //    entity.Property(e => e.Phone)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.HasOne(d => d.UserList)
            //        .WithMany(p => p.UserPhone)
            //        .HasForeignKey(d => d.UserListId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_UserPone_UserList");
            //});

            //  OnModelCreatingPartial(modelBuilder);
        }

       // partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
