using System;

namespace ZombieTsunami.Core
{
    public static class Events
    {
        public static Action OnHumanEaten;
        public static Action<Zombie> OnZombieKilled;
        public static Action<Coin> OnCoinPickup;
    }
}
