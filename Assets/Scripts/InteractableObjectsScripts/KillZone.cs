using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieTsunami.Core;

namespace ZombieTsunami.InteractableObjectsScripts
{
    public class KillZone : MonoBehaviour, IInteractable
    {
        public void Interact(Zombie zombie)
        {
            Events.OnZombieKilled?.Invoke(zombie);
        }
    }
}
