using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Assets.Scripts.SpritesHandler.BombSprite
{
    public class BombRockGenerator : MonoBehaviour
    {
        [SerializeField]
        private Sprite[] rocks;
        private CircleCollider2D boundaries;
        private float LastAngle =0f;

        private void Start()
        {
            boundaries = this.GetComponent<CircleCollider2D>();
            GenerateRocks();
        }

        private void GenerateRocks()
        {
            int numberOfRocksToGenerate = 10;
            var instances = new GameObject[numberOfRocksToGenerate];
            for (int i = 0; i < numberOfRocksToGenerate; i++)
            {
                instances[i] = new GameObject("Rcok"+i);
            }
            SetUpGameObjects(instances);
        }

        private void SetUpGameObjects(GameObject[] instances)
        {
            foreach (var instance in instances) 
            {
                PossitionGameObject(instance);
            
                instance.transform.SetParent(this.gameObject.transform);
            }
        }

        private void SetUpSprite(GameObject instance,bool IsSpriteBehind)
        {
                var spireRenderer = instance.AddComponent<SpriteRenderer>();
            if (IsSpriteBehind)
            {
                spireRenderer.sortingOrder = -1;
            }
            else
            {
                spireRenderer.sortingOrder = 3;
            }
                spireRenderer.sprite = rocks[Random.Range(1, rocks.Length)];  
        }

        private void PossitionGameObject(GameObject instance)
        {
            float YPos =0f,XPos =0f;
            int flip = Random.Range(0, 1) == 0 ? 1 : 1;
            
            float angle = Random.Range(0, 360);
            while((angle >= 45 && angle <= 135) && LastAngle == angle)
            {
                angle = Random.Range(0, 360);
            }
            LastAngle = angle;


            XPos += boundaries.bounds.center.x;
            YPos += boundaries.bounds.center.y;

            XPos += Mathf.Cos(angle) >= 0 ? Mathf.Cos(angle) + this.transform.localScale.x/2 : Mathf.Cos(angle) - this.transform.localScale.x / 2;
            YPos += Mathf.Sin(angle) >= 0 ? Mathf.Sin(angle)  + this.transform.localScale.y / 2 : Mathf.Sin(angle) - this.transform.localScale.y / 2;


            instance.transform.position = new Vector2(XPos, YPos);
            if((Mathf.Deg2Rad * angle > Mathf.PI /2 && Mathf.Deg2Rad * angle < Mathf.PI)
                || (Mathf.Deg2Rad * angle > 0 && Mathf.Deg2Rad * angle < Mathf.PI / 2))
            {
                SetUpSprite(instance,true);
            }
            else
            {
            SetUpSprite(instance,false);
            }

        }

    }
}
