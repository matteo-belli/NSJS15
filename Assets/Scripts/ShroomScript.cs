using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomScript : MonoBehaviour
{
    public Collider2D shroomcollider; // Reference to the player's collider
    public GameObject objectsToActivate;
    public GameObject objectsToDeactivate;
    public GameObject Self;

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player entered trigger.");

        if (other != shroomcollider)
        {
            Debug.Log("SpengiAccendi");

                objectsToActivate.SetActive(true);
            Self.SetActive(false);
                objectsToDeactivate.SetActive(false);

            
        }
    }
}