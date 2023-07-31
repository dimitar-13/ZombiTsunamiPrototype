using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieTsunami.Core;

namespace ZombieTsunami.Core
{
    public interface IInteractable
    {
        public void Interact(Zombie zombie = null);
    }
}
