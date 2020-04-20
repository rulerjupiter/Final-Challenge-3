using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickups : MonoBehaviour
{

    public float multiplier = -0.5f;
    public float duration = 2f;
    public GameObject pickupEffect;
  


    void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider player)

    {

        Instantiate(pickupEffect, transform.position, transform.rotation);
        player.transform.localScale *= multiplier;

        yield return new WaitForSeconds(duration);

        player.transform.localScale /= multiplier;

        Destroy(gameObject);
    }
}
     

