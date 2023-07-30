using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Events 
{
    public static Action OnHumanEaten;
    public static Action<Zombie> OnZombieKilled;
    public static Action<Coin> OnCoinPickup;
}
