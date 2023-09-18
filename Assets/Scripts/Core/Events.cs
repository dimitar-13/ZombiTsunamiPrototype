using System;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public static class Events
    {
        public static Action OnHumanEaten;
        public static Action<Zombie> OnZombieKilled;
        public static Action<Coin> OnCoinPickup;
        public static Action<GameObject> OnPlayerEnterNewGround;
        /// <summary>
        /// This gets called when a vehicle objects' current zombie count is changed
        /// Is used to change the sprite of the object.
        /// </summary>
        public static Action<int, SpriteRenderer> vehicleNumberChanged; 
    }
}
