using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Enviroment
{
    public interface IGroundDependent
    {
        GameObject CurrrentGround { get; set;}
    }
}
