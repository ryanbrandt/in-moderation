using InModeration.Backend.API.Models;
using System;

namespace InModeration.Backend.API.Resources
{
    public class SiteRuleResource
    {
        public int UserId { get; set; }

        public int SiteId { get; set; }

        public string Domain { get; set; }

        public int Time { get; set; }

        public int Points { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public SiteRuleResource(SiteRule rule)
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
