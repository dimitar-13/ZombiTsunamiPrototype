using Assets.Scripts.Core;
using UnityEngine;


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