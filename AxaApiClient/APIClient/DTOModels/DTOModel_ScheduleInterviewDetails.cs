using System;

namespace APIClient.APIClient.DTOModels
{
    public class DTOModel_ScheduleInterviewDetails
    {
        public DateTime ProposedDate { get; set; } = DateTime.Now;
        public TimeSpan ProposedTime { get; set; } = TimeSpan.FromSeconds(0);
        public bool Online { get; set; } = false;
    }
}
