
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

        private void Update()
        {
            float angle = Random.Range(0,360);
            this.gameObject.transform.position = new Vector2(Mathf.Cos(angle),Mathf.Sin(angle))*Time.deltaTime;
        }
    }
}
