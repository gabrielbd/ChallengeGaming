using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredifyGaming.Domain.DTO
{
    public class PlayerDTO
    {
        public long IdPlayer { get; set; }
        public string? Name { get; set; }
        public DateTime DateTimeCreate { get; set; }
    }
}
