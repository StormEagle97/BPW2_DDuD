using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Zombies.pickups
{
    public class PickUpReceiver : MonoBehaviour
    {
        public ItemType incomingPickUpType;
        // Start is called before the first frame update
        void Start()
        {
            Globals<ItemType>.OnItemPickUpCaller += ReceiveItemType;
        }

        public void ReceiveItemType(ItemType type)
        {
            incomingPickUpType = type;
            ActivatePickUp();
        }

        private void ActivatePickUp()
        {
            BulletController cmp = gameObject.transform.GetChild(0).GetComponent<BulletController>();

            switch (incomingPickUpType)
            {
                case ItemType.instakill:
                    cmp.damageToGive = 10000;
                    StartCoroutine(SetBack(false, cmp));
                    break;
                case ItemType.dubbleTap:
                    cmp.bulletSpeed *= 2;
                    StartCoroutine(SetBack(true, cmp));
                    break;
                case ItemType.movementSpeed:
                    gameObject.GetComponent<PlayerController>().moveSpeed *= 2;
                    break;
                case ItemType.dubblePoints:
                    gameObject.GetComponent<PointScript>().Score += 400;
                    break;
                default:
                    break;
                
            
            }
        }

        private IEnumerator SetBack(bool fl, BulletController input)
        {
            yield return new WaitForSeconds(5f);

            if (fl) input.bulletSpeed /= 2;
            else input.damageToGive = 25;

        }

        // Update is called once per frame
        void Update()
        {

        }

}
}

