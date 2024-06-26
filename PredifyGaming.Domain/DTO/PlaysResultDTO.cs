﻿namespace PredifyGaming.Domain.DTO
{
    public class PlaysResultDTO
    {
        public long IdPlay { get; set; }
        public long PlayerId { get; set; }
        public long GameId { get; set; }
        public long PointsResult { get; set; }
        public DateTime TimeStamp { get; set; }
        public string? PlayerName { get; set; }
        public string? GameName { get; set; }
    }
}
