using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieTsunami.Core;

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
