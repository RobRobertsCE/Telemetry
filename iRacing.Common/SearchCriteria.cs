using System;

namespace iRacing.Common
{
    public class SearchCriteria
    {
        public int? SeasonMin { get; set; }
        public int? SeasonMax { get; set; }
        public int? LapsMin { get; set; }
        public int? LapsMax { get; set; }
        public Guid? TrackId { get; set; }
        public Guid? SetupId { get; set; }
    }
}
