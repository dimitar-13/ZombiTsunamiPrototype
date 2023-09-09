using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.SpritesHandler
{
    public class BombPulsing:MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer outerPulseSprite;
        [SerializeField]
        private SpriteRenderer innerPulseSprite;
        [SerializeField]
        private SpriteRenderer innerGlassPart;
        float Pulse = 0f;

        private void Start()
        {
            outerPulseSprite.color =new Color(outerPulseSprite.color.r, outerPulseSprite.color.g, outerPulseSprite.color.b, 0f);
            innerPulseSprite.color = new Color(innerPulseSprite.color.r, innerPulseSprite.color.g, innerPulseSprite.color.b, 0f);
            StartCoroutine(BombAnimation());
        }

        //private void Update()
        //{
        //    //Pulse = MathF.Sin(Time.deltaTime);
        //    outerPulseSprite.color = new Color(outerPulseSprite.color.r, outerPulseSprite.color.g, outerPulseSprite.color.b, MathF.Sin(Pulse));
        //    innerPulseSprite.color = new Color(innerPulseSprite.color.r, innerPulseSprite.color.g, innerPulseSprite.color.b, MathF.Sin(Pulse));

        //    Pulse+=Time.deltaTime;
        //}

        IEnumerator BombAnimation()
        {
            while(innerGlassPart.color.a > 0f)
            {
                innerGlassPart.color = new Color(innerGlassPart.color.r, innerGlassPart.color.g, innerGlassPart.color.b, innerGlassPart.color.a - 0.01f);
                yield return innerGlassPart;
            }
            while(innerPulseSprite.color.a < 1f)
            {
                innerPulseSprite.color = new Color(innerPulseSprite.color.r, innerPulseSprite.color.g, innerPulseSprite.color.b, innerPulseSprite.color.a + 0.02f);
                yield return innerPulseSprite;
            }

            yield return new WaitForSeconds(1);

            while (innerPulseSprite.color.a > 0f)
            {
                innerPulseSprite.color = new Color(innerPulseSprite.color.r, innerPulseSprite.color.g, innerPulseSprite.color.b, innerPulseSprite.color.a - 0.01f);
                yield return innerPulseSprite;
            }
            while (innerGlassPart.color.a < 1f)
            {
                innerGlassPart.color = new Color(innerGlassPart.color.r, innerGlassPart.color.g, innerGlassPart.color.b, innerGlassPart.color.a + 0.01f);
                yield return innerGlassPart;
            }
        }


    }
}
