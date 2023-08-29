using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalShroom : MonoBehaviour
{
    public Collider2D shroomcollider; // Reference to the player's collider
    public GameObject objectsToActivate;
    public GameObject objectsToDeactivate;
    public GameObject Self;
    public GameObject OtherShroom;
    public AudioSource source;
    public AudioClip Shroms;
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player entered trigger.");

        if (other != shroomcollider)
        {
            Debug.Log("SpengiAccendi");

            objectsToActivate.SetActive(true);

            objectsToDeactivate.SetActive(false);

            Self.SetActive(false);

            source.PlayOneShot(Shroms);

            OtherShroom.SetActive(true);
        }
    }
}