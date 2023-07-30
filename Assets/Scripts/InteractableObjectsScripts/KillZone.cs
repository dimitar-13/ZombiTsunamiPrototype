using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour, IInteractable
{
    public void Interact(Zombie zombie)
    {
        Events.OnZombieKilled?.Invoke(zombie);
    }
}
