using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEffectDespawner : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ImageResetter());
    }
  
    IEnumerator ImageResetter()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }


}
