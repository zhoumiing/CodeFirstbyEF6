using System;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;




namespace MemberManagement1.Models
{
    public class DbConn:DbContext
    {
        public DbConn()
        {

        }


        public DbSet<MemberModel> MemberModels { get; set; }
        public DbSet<ContactModel> ContactModels { get; set; }
        public DbSet<MemberTagModel> MemberTagModels { get; set; }
        public DbSet<MemberWechatModel> MemberWechatModels { get; set; }
        public DbSet<MemberWithMemberTagModel> memberWithMemberTagModels { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=/Users/x.m./Projects/_Sqlite3/CodefirstByEF6.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberModel>(m =>
            {
                m.HasKey("memberId");
                m.HasIndex("memberId").IsUnique();
                m.Property<string>("memberId").IsRequired();
                //将会员加入日期改成sqlite Affinity type，即Text
                m.Property<DateOnly>("memberJoinDate").HasColumnType("TEXT");
                m.Property<DateOnly>("memberBirthday").HasColumnType("TEXT");
                
            });

            modelBuilder.Entity<ContactModel>(c =>
            {
                c.HasKey("commonId");
                c.HasIndex("commonId").IsUnique();
            });
            // contactModel的表关系,决定了必须要成对出现。因为with many 没有制定具体的对象
            modelBuilder.Entity<ContactModel>()
                .HasOne<MemberModel>(c => c.member)
                .WithMany(c => c.contacts)
                .HasForeignKey(c => c.memberId);

            modelBuilder.Entity<MemberWechatModel>(mw =>
            {
                mw.HasKey("wechatId");
                mw.HasIndex("wechatId").IsUnique();
            });
            // 和MemberModel 是 many - one 关系
            modelBuilder.Entity<MemberWechatModel>()
                .HasOne<MemberModel>(mw => mw.member)
                .WithMany(mw => mw.memberWechats)
                .HasForeignKey(mw => mw.memberId);

            modelBuilder.Entity<MemberTagModel>(mt =>
            {
                mt.HasKey("memberTagId");
                mt.HasIndex("memberTagId").IsUnique();
            });

            modelBuilder.Entity<MemberWithMemberTagModel>(mmt =>
            {
            mmt.HasKey("memberId","memberTagId");  //复合主键的定义
            });
            modelBuilder.Entity<MemberWithMemberTagModel>()
                .HasOne<MemberModel>(mmt => mmt.member)
                .WithMany(mmt => mmt.memberWithMemberTags)
                .HasForeignKey(mmt => mmt.memberId);

            modelBuilder.Entity<MemberWithMemberTagModel>()
                .HasOne<MemberTagModel>(mmt => mmt.memberTag)
                .WithMany(mmt => mmt.memberWithMemberTags)
                .HasForeignKey(mmt => mmt.memberTagId);


                

        }
    }
}

