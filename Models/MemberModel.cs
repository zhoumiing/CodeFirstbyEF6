using System;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace MemberManagement1.Models
{
    public class MemberModel
    {
        //这个是一个principal entity
        public MemberModel()
        {
        }
        public string memberId { get; set; }
        public DateOnly memberJoinDate { get; set; }
        public string memberNickName { get; set; }
        public string sexual { get; set; }
        public DateOnly memberBirthday { get; set; }
        public string comments { get; set; }

        //针对1 to many 中，一个用户多个联系方式的 collection navigatioon property
        // 一般创建一个就有一个反向的
        public List<ContactModel> contacts { get; set; }
        public List<MemberWechatModel> memberWechats { get; set; }
        public List<MemberWithMemberTagModel> memberWithMemberTags { get; set; }
    }

}

