using System;
namespace MemberManagement1.Models
{
    public class ContactModel
    {
        public ContactModel()  // 这个和 MemberModel 是一对多关系
        {
        }
        public string commonId { get; set; } //其实是一个外键，直接用作PK 
        public string contactType { get; set; }  //例如电话，邮件
        public string contactValue { get; set; }  // 例如电话的值，邮件具体地址
        public string comments { get; set; }

        //inverse navigation property
        public string memberId { get; set; }
        public MemberModel member { get; set; }
    }
}

