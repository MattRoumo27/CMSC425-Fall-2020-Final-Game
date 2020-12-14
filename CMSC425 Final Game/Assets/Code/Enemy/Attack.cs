using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    GameObject player;
    public AudioClip zombieHitPlayerSound;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        if (!player)
        {
            Debug.Log("DIDNT GET PLAYER");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(10);
            collision.gameObject.GetComponent<AudioSource>().PlayOneShot(zombieHitPlayerSound);
        }
    }
}
