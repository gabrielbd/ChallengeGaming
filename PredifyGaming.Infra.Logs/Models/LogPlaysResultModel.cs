using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredifyGaming.Infra.Logs.Models
{
    public class LogPlaysResultModel
    {
        public long PlayerId { get; set; }
        public long GameId { get; set; }
        public string? DescriptionPlayer { get; set; }
        public string? DescriptionGame { get; set; }

        public long BalancePlayer { get; set; }
        public DateTime? TimeStamp { get; set; }
    }
}
