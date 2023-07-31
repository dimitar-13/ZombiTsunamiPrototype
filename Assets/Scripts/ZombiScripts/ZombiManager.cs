using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using ZombieTsunami.Core;

namespace ZombieTsunami.ZombiScripts
{
    [CreateAssetMenu(menuName = "ZombiManager")]
    public class ZombiManager : ScriptableObject
    {
        public List<Zombie> Zombies;

        private void OnDisable()
        {
            Zombies = null;
        }
    }
}
