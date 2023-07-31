using UnityEngine;

namespace ZombieTsunami.Core
{
    public class Zombie : MonoBehaviour
    {
        public bool isAlive = true;
        public bool isOnGround = false;
        public Rigidbody2D ZombieRigidBody;


        // Start is called before the first frame update
        void Start()
        {
            ZombieRigidBody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                interactable.Interact(this);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            isOnGround = true;
            if (collision.gameObject.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                interactable.Interact(this);
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.transform.tag == this.transform.tag)
            {
                Physics2D.IgnoreCollision(collision.collider, this.GetComponent<BoxCollider2D>());
            }
            else if (collision.gameObject.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                //if (interactable is Car car)
                //{
                //    var Car = (Car)interactable;
                //    Car.OnZombieLeave();
                //}

            }
            else
            {
                isOnGround = false;
            }
        }

    }
}
