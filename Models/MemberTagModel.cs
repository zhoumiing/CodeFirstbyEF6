using System;
namespace MemberManagement1.Models
{
    public class MemberTagModel
    {
        public MemberTagModel()  // 这个其实是 many to many 
        {
        }
        public string memberTagId { get; set; }
        public string tagName { get; set; }
        public string tagComments { get; set; }

        // 这个member type model 也可以是一个principal entity
        // 同时也作为member 的s
        public List<MemberWithMemberTagModel> memberWithMemberTags { get; set; }
    }
}

