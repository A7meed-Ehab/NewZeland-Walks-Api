﻿namespace NZWalks.Api.Models.Domain
{
    public class Region : BaseModel
    {
        public string Code { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}