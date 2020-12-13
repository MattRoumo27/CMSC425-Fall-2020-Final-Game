using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public Transform player;
    public Animator transition;
    public Transform location;
    AudioSource audioSource;
    public AudioClip warpSound;
    //-18,1,19
    //0,90,0

    private void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(TransitionPlayer(0));
    }


    IEnumerator TransitionPlayer(int levelIndex)
    {
        transition.SetTrigger("Start");
        audioSource.PlayOneShot(warpSound);

        yield return new WaitForSeconds(3);
        Debug.Log(player.position);
        
        Vector3 path = location.position;
        for (int i = 0; i< 1000; i++)
        {
            player.position = path;
            Debug.Log(player.position);
        }
        
        
        player.eulerAngles = new Vector3(0, 90, 0);

        transition.SetTrigger("End");


        yield return null;
    }

}
