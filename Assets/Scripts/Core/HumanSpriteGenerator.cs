
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

namespace Assets.Scripts.Core
{
    struct Human
    {
        public Gedner gender;
        public bool hasSuit;

    }

   
    public class HumanSpriteGenerator :MonoBehaviour
    {
        [SerializeField]
        private Sprite[] heads;
        [SerializeField]
        private Sprite[] mouth;
        [SerializeField]
        private Sprite[] eyes;
        [SerializeField]
        private Sprite[] pupils;
        [SerializeField]
        private Sprite[] bodies;
        [SerializeField]
        private Sprite[] noses;
        [SerializeField]
        private List<SpriteRenderer> blueprint;

        float timePassed = 0;
        private void Start()
        {
           
        }

        private void Update()
        {
            timePassed += Time.deltaTime;
            if (timePassed > 5)
            {
                GenerateCustomHumanSprite();
                timePassed = 0;
            }
        }
        private void GenerateCustomHumanSprite()
        {
            bool isMale = Random.Range(0, 1) == 1 ? true : false;
            if(isMale)
            {
                blueprint[0].sprite = heads[Random.Range(0,heads.Length)];
                blueprint[1].sprite = noses[Random.Range(0, noses.Length)];

                blueprint[2].sprite = bodies[Random.Range(0, bodies.Length)];

            }
            else
            {
                blueprint[0].sprite = heads[Random.Range(0, heads.Length)];
                blueprint[1].sprite = noses[Random.Range(0, noses.Length)];

                blueprint[2].sprite = bodies[Random.Range(0, bodies.Length)];

            }


        }
    }

enum Gedner
    {
        Male,
        Female
    }
}

