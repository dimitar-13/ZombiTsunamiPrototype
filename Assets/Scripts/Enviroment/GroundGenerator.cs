using UnityEngine;

namespace ZombieTsunami.Enviroment
{
    [CreateAssetMenu(menuName = "GroundGenerator")]
    public class GroundGenerator : ScriptableObject
    {
        private float Lenght;
        [SerializeField]
        private Sprite squareSprite;
        public GameObject GenerateGround()
        {
            GameObject ground = new GameObject("Ground");

            float tempLenght = Random.Range(10f, 60f);
            if (Lenght == tempLenght)
            {
                tempLenght = Random.Range(10f, 60f);
            }
            ground.gameObject.transform.localScale = new Vector3(Lenght, 10f, 1f);
            SpriteRenderer squreSpriteRenderer;
            squreSpriteRenderer = ground.gameObject.AddComponent<SpriteRenderer>();
            squreSpriteRenderer.sprite = squareSprite;
            ground.gameObject.AddComponent<BoxCollider2D>();

            ground.gameObject.AddComponent<EnviromentMovementScript>();

            ground.layer = 6;
            Lenght = tempLenght;
            return ground;
        }
    }
}
