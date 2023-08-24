using System.Collections;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.SpritesHandler.ZombieSprites
{
    public class ZombieRunningSpriteGenerator : MonoBehaviour
    {
        [SerializeField]
        private Sprite[] runningSpriteSiquance;
        [SerializeField]
        private float AnimationSpeed = 0.10f;
        bool AnimationEnd = false;
        private SpriteRenderer spriteRenderer;
        private int CurrentAnimFrame = 0;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = runningSpriteSiquance.ElementAt(0);
            StartCoroutine(ChangeSpriteAtRunTime());
        }


        private void Update()
        {
            if (AnimationEnd)
            {
                AnimationEnd = false;
                StartCoroutine(ChangeSpriteAtRunTime());
            }
        }

        IEnumerator ChangeSpriteAtRunTime()
        {
            for (int CurrentAnimFrame = 0; CurrentAnimFrame < runningSpriteSiquance.Length; CurrentAnimFrame++)
            {
                spriteRenderer.sprite = runningSpriteSiquance.ElementAt(CurrentAnimFrame);
                yield return new WaitForSeconds(0.10f);
                yield return CurrentAnimFrame;
            }
            AnimationEnd = true;
        }

    }
}
