using System;
using UnityEngine;

namespace ZombieTsunami.Core
{
    public static class Events
    {
        public static Action OnHumanEaten;
        public static Action<Zombie> OnZombieKilled;
        public static Action<Coin> OnCoinPickup;
        public static Action<Transform,Transform> OnPlayerEnterNewGround; 
    }
}
