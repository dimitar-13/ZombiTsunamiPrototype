using UnityEngine;
using Assets.Scripts.Core;
using System;
using System.ComponentModel;

namespace ZombieTsunami.InteractableObjectsScripts
{
    public class VehicleManager : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private int amountToBreak;
        public int AmountToBreak { get => amountToBreak; private set => value = amountToBreak; }
        [SerializeField]
        private int zombiesTouching;
        [SerializeField]
        private VehicleUICommunication communication;

        public int ZombiesTouching 
        { 
            get
            {
                return zombiesTouching;
            }
            set
            {
                communication.OnCurrentZombieNumberChanged?.Invoke(zombiesTouching);
                zombiesTouching = value; 
            }
        }
        public Action<int> OnCurrentCountChanged;

        public void Interact(Zombie zombie = null)
        {
            if (IsZombieInfront(zombie.gameObject))
            {
                ZombiesTouching++;
            }

            if (IsAmountMet())
            {
                //Play break animation
                Destroy(this.gameObject);
            }
        }

        public void OnZombieLeave()
        {
            ZombiesTouching--;
        }

        private bool IsZombieInfront(GameObject zombie)
        {
           BoxCollider2D colider =  this.gameObject.GetComponent<BoxCollider2D>();             
                return zombie.transform.position.y < colider.bounds.max.y;
        }

        private bool IsAmountMet()
        {
            return ZombiesTouching >= amountToBreak;
        }
    }
}

