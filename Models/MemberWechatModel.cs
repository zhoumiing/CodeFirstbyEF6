using System;
namespace MemberManagement1.Models
{
    public class MemberWechatModel
    {
        public MemberWechatModel()
        {
        }
        public string wechatId { get; set; }
        public string sexual { get; set; }
        public string nickname { get; set; }
        public string country { get; set; }
        public string area { get; set; }

        //外键属性
        public string memberId { get; set; }
        public MemberModel member { get; set; }
    }
}

