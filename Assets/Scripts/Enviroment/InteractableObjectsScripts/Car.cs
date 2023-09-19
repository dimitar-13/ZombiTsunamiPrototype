using UnityEngine;
using Assets.Scripts.Core;

namespace ZombieTsunami.InteractableObjectsScripts
{
    public class Car : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private int amountToBreak;
        [SerializeField]
        private int zombiesTouching;
        
        public int ZombiesTouching { get => zombiesTouching; }

        public void Interact(Zombie zombie = null)
        {
            if (IsZombieInfront(zombie.gameObject))
            {
                zombiesTouching++;
            }

            if (IsAmountMet())
            {
                Destroy(this.gameObject);
            }
        }

        public void OnZombieLeave()
        {
            zombiesTouching--;
        }

        private bool IsZombieInfront(GameObject zombie)
        {
            if (zombie.TryGetComponent<BoxCollider2D>(out BoxCollider2D boxCollider2D))
            {
                float ZombiMinPossition = boxCollider2D.bounds.min.y;
                return ZombiMinPossition < this.transform.position.y;
            }
            return false;
        }

        private bool IsAmountMet()
        {
            return zombiesTouching >= amountToBreak;
        }
    }
}

