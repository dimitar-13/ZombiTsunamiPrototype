using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.SpritesHandler
{
    public class Test:MonoBehaviour
    {
    public SpriteContainer container;


        private void Start()
        {
            container.PullSprites();
        }
    }
}
