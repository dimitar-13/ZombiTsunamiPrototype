using Assets.Scripts.Core;
using UnityEngine;


namespace ZombieTsunami.InteractableObjectsScripts
{
    public class Human : MonoBehaviour, IInteractable
    {
        private float AnimationSpeed = 2f;

        //public void Animate()
        //{
        //    this.transform.position.y =  Vector2.up * (Mathf.Sin(Time.deltaTime)* AnimationSpeed);
        //}

        //private void Update()
        //{
        //    Animate();
        //}


        public void Interact(Zombie zombie)
        {
            Events.OnHumanEaten?.Invoke();
            Destroy(gameObject);
        }
    }

}