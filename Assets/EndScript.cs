using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    public Collider2D CanvasBox;

    public GameObject objectsToActivate;

    public PlayerMovement playermovement;

    // Start is called before the first frame update
    void Start()
    {
        objectsToActivate.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other != CanvasBox)
        {
            Debug.Log("SpengiAccendi");

            objectsToActivate.SetActive(true);

            playermovement.enabled = false;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        objectsToActivate.SetActive(false);
    }
}
