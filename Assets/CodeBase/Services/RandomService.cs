using System;

namespace Assets.CodeBase.Services
{
    public class RandomService 
    {
        private Random _random = new();

        public int GetRandom(int min, int max) =>
            _random.Next(min, max);
    }
}