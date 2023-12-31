﻿using System.Text.Json.Serialization;

namespace Application.Dtos.Animals
{
    public class BirdDto
    {
        public string Name { get; set; } = string.Empty;
        public bool CanFly { get; set; }
        public string OwnerBirdUserName { get; set; } = string.Empty;
        [JsonIgnore]
        public ICollection<Guid> BirdOwnerIds { get; set; } = new List<Guid>();

    }
}
