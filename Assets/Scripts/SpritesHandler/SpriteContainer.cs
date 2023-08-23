using Assets.Scripts.Core;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.TextCore.Text;

[CreateAssetMenu(menuName = "SpriteContainer")]
public class SpriteContainer : ScriptableObject
{
    [SerializeField]
    private Sprite[] zombieHeads;

    public Sprite[] ZombieHeads { get { return zombieHeads; } private set { value = zombieHeads; } }

    [SerializeField]
    private Sprite[] zombieTorso;

    public Sprite[] ZombieTorso { get { return zombieTorso; } private set { value = zombieTorso; } }


    [SerializeField]
    private Sprite[] zombieEyes;

    public Sprite[] ZombieEyes { get { return zombieEyes; } private set { value = zombieEyes; } }


    [SerializeField]
    private Sprite[] zombieEyesWhitePart;

    public Sprite[] ZombieEyesWhitePart { get { return zombieEyesWhitePart; } private set { value = zombieEyesWhitePart; } }

    public void PullSprites()
    {
     //   string fileContents = LoadMetaFileContents(Application.dataPath + "/Scripts/SpritesHandler/Sprites/SpriteSheets/SpawnableObjects/Mobile - Zombie Tsunami - Characters.png");
        //var test = Resources.Load<Texture2D>(Application.dataPath + "/Scripts/SpritesHandler/Sprites/SpriteSheets/SpawnableObjects/Mobile - Zombie Tsunami - Characters.png");

        Load("/SpriteSheets/SpawnableObjects", "Zombie_Head47");
        
  

        //else
        //{
        //    Debug.LogError("Meta file path is not provided.");
        //}
    }

    Sprite Load(string imageName, string spriteName)
    {
        Sprite[] all = Resources.LoadAll<Sprite>("SpriteSheets/SpawnableObjects/Characters") ;
        List<Sprite> temp = new List<Sprite>();
        List<Sprite> tempEye = new List<Sprite>();

        foreach (var s in all)
        {
            if (s.name.Contains("Zombie_Head"))
            {
                temp.Add(s);
            
            }
            if (s.name.Contains("Eye_"))
            {
                tempEye.Add(s);

            }
        }
        zombieHeads = temp.ToArray();
        zombieEyes = tempEye.ToArray();
        return null;
    }

    void AddSpriteToList(ref Sprite[] sprites,Sprite spriteToAdd)
    {
       int itterator = sprites.Length;
        sprites[itterator] = spriteToAdd;
    }

  

}
