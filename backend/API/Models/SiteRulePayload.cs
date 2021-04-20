using System;

namespace InModeration.Backend.API.Models
{
    public class SiteRulePayload
    {
        public int UserId { get; set; }

        public int SiteId { get; set; }

        public string Domain { get; set; }

        public int Time { get; set; }

        public int Points { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public SiteRulePayload(SiteRule rule)
        {
            UserId = rule.UserId;
            SiteId = rule.SiteId;
            Domain = rule.Site?.Domain;
            Time = rule.Time;
            Points = rule.Points;
            Created = rule.Created;
            Modified = rule.Modified;
        }
    }
}
