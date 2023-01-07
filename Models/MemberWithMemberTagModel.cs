using System;
namespace CodefirstByEF6.Models
{
    public class MemberWithMemberTagModel
    {
        public MemberWithMemberTagModel()
        {
        }
        public string memberId { get; set; }
        public string memberTagId { get; set; }
        public decimal similarScore { get; set; }
        public decimal supportScore { get; set; }
        public decimal tagScore { get; set; }

        //one to many
        public MemberModel member { get; set; }
        public MemberTagModel memberTag { get; set; }
    }
}

