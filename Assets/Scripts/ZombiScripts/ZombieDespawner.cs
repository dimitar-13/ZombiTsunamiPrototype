using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Core;

namespace ZombieTsunami.ZombiScripts
{
    public class ZombieDespawner : MonoBehaviour
    {
        [SerializeField]
        public ZombiManager zombiManager;

        private void Start()
        {
            Events.OnZombieKilled += DespawnZombie;
        }

        public void DespawnZombie(Zombie zombie)
        {
            zombiManager.Zombies.Remove(zombie);
            Destroy(zombie.gameObject);
        }

    }
}
