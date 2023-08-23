using Assets.Scripts.Core;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Core
{

    [CreateAssetMenu(menuName = "ZombiManager")]
    public class ZombiManager : ScriptableObject
    {
        public List<Zombie> Zombies;

        private void OnDisable()
        {
            Zombies = null;
        }
        private void ZombieCollision()
        {

        }

    }
}
