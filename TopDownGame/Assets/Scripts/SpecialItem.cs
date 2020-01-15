using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zombies.pickups
{
    public class SpecialItem : MonoBehaviour
    {
        public ItemType currentType;

        private void Start()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Player")
            {
                Globals<ItemType>.OnItemPickUpCaller(currentType);
                Destroy(gameObject, 0.1f);
            }
        }
            
    }
}
