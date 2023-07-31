using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieTsunami.Core;

namespace ZombieTsunami.Core
{
    public class Coin : MonoBehaviour, IInteractable
    {

        public void Interact(Zombie zombie = null)
        {
            Events.OnCoinPickup?.Invoke(this);
            Destroy(this);
        }

    }
}
