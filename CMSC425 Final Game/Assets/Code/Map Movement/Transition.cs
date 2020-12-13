﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Animator transition;
    public Transform location;
    public GameObject zombie;
    public GameObject currIsland;
    public GameObject nextIsland;
    //-18,1,19
    //0,90,0

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(TransitionPlayer());
    }


    IEnumerator TransitionPlayer()
    {
        Debug.Log("Fading out...");
        transition.SetTrigger("Start");

      
        
        nextIsland.SetActive(true);
        

        yield return new WaitForSeconds(1);
        Debug.Log(player.position);
        Vector3 path = location.position;

        for (int i = 0; i< 1000; i++)
        {
            player.position = path;
            Debug.Log(player.position);
        }

        //spawn enemies for zone1
        if (location.name == "Landing1")
        {
            Instantiate(zombie, new Vector3(65, .82f, 71), Quaternion.identity);
            Instantiate(zombie, new Vector3(47, .82f, 70), Quaternion.identity);
            Instantiate(zombie, new Vector3(64, .82f, 65), Quaternion.identity);
        }

        player.eulerAngles = new Vector3(0, 90, 0);

        Debug.Log("Fading in...");
        transition.SetTrigger("End");

      
        currIsland.SetActive(false);
  


        yield return null;
    }

}
