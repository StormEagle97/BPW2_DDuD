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

        private void OnCollisionEnter(Collision other)
        {
            if(other.gameObject.tag == "Player")
            {
                Globals<ItemType>.OnItemPickUpCaller(currentType);
                Destroy(this, 1f);
            }
        }
            
    }
}
