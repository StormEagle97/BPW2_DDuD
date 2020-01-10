using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zombies.pickups
{
    public enum ItemType
    {
        instakill = 0,
        nuke = 1,
        dubblePoints = 2,
        movementSpeed = 3,
        dubbleTap = 4
    }

    [System.Serializable]
    public class PickUpItem
    {
        [SerializeField]
        public GameObject Prefab;
        [SerializeField]
        public ItemType ItemType;

    }


    public class PickUpHandler : MonoBehaviour
    {
        public List<Transform> PickUpSpawns;
        public List<PickUpItem> Items;
        public float SpawnTimeBetween;
        private void Start()
        {
            InvokeRepeating("SpawnRandomPickUp", 1f, SpawnTimeBetween);
        }

        private IEnumerator SpawnRandomPickUp()
        {
            int randomNumm = Random.Range(0, Items.Count);
            SpawnGameObject(Items[randomNumm].Prefab);
            yield return new WaitForSeconds(SpawnTimeBetween);
        }

        private void SpawnGameObject(GameObject prefab)
        {
            int randomSpawn = Random.Range(0, PickUpSpawns.Count);
            GameObject obj = GameObject.Instantiate(prefab, PickUpSpawns[randomSpawn]);
            //Globals<GameObject>.OnItemPickUpCaller(obj);
        }
    }
}
