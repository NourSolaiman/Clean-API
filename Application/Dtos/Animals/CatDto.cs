﻿namespace Application.Dtos.Animals
{
    public class CatDto
    {
        public string Name { get; set; } = string.Empty;
        public bool LikesToPlay { get; set; }
        public string Breed { get; set; }
        public int Weight { get; set; }
    }
}
