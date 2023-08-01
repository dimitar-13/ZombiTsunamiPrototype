
using UnityEngine;
using UnityEngine.UI;

namespace ZombieTsunami.InteractableObjectsScripts
{
    public class VehicleUIManager : MonoBehaviour
    {
        [SerializeField]
        private Text display;
        [SerializeField]
        private int amountToBreak;
        private Car vehicleScript;
        private int zombieCount;

        // Start is called before the first frame update
        void Start()
        {
            vehicleScript = this.GetComponent<Car>();
            zombieCount = vehicleScript.ZombiesTouching;
            display.text = string.Format("{0}" + @"\" + "{1}", zombieCount, amountToBreak);
        }

        // Update is called once per frame
        void Update()
        {
            if (zombieCount != vehicleScript.ZombiesTouching)
            {
                display.text = string.Format("{0}" + @"\" + "{1}", zombieCount, amountToBreak);
            }
        }
    }
}
