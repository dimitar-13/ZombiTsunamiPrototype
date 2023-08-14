using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using ZombieTsunami.Core;

namespace ZombieTsunami.InteractableObjectsScripts
{
    public class Item : IInteractable
    {
        public PickupPower currentItemPickupPower;


        public void Interact(Zombie zombie)
        {
            Debug.Log(currentItemPickupPower.ToString());
        }

    }

    public enum PickupPower
    {
        DragonPower,
        UfoPower,
        NinjaPower
    }
}