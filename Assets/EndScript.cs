using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    public Collider2D CanvasBox;
    public AudioSource source;
    public AudioClip Pidgeon;
    public GameObject objectsToActivate;

    private Animator anim;
    
    public PlayerMovement playermovement;

    // Start is called before the first frame update
    void Start()
    {
        anim = playermovement.GetComponent<Animator>();
        objectsToActivate.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other != CanvasBox)
        {
            Debug.Log("SpengiAccendi");

            objectsToActivate.SetActive(true);

            playermovement.canmove = false;

            playermovement.speed = 0f;
            playermovement.jumpspeed = 0f;
            playermovement.body.constraints = RigidbodyConstraints2D.FreezePositionX;
            playermovement.enabled = false;

            anim.SetBool("Grounded",true);

            anim.SetBool("Run", false);

            source.PlayOneShot(Pidgeon);
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        objectsToActivate.SetActive(false);
    }
}
