using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserList.DbModels
{
    public partial class UserPhone
    {
        public int Id { get; set; }
        public int UserListId { get; set; }
        public string Phone { get; set; }

        public virtual UserLists UserList { get; set; }
    }


    public class UserPhoneConfiguration : IEntityTypeConfiguration<UserPhone>
    {
        public void Configure(EntityTypeBuilder<UserPhone> entity)
        {

            entity.Property(e => e.Phone).HasColumnType("")
                    .IsRequired()
                    .HasMaxLength(50);

            entity.HasOne(d => d.UserList)
              .WithMany(p => p.UserPhone)
              .HasForeignKey(d => d.UserListId)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("FK_UserPone_UserList");
        }


        }
    }

