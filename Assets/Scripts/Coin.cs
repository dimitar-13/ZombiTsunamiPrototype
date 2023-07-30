using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour,IInteractable
{

    public void Interact(Zombie zombie = null)
    {
        Events.OnCoinPickup?.Invoke(this);
        Destroy(this);
    }

}
