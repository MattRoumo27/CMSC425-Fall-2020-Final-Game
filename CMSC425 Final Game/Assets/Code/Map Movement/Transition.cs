using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Animator transition;
    public Transform location;
    //-18,1,19
    //0,90,0

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(TransitionPlayer(0));
    }


    IEnumerator TransitionPlayer(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);
        Debug.Log(player.position);
        Vector3 path = location.position;
        for (int i = 0; i< 100; i++)
        {
            player.position = path;
            Debug.Log(player.position);
        }
        
        
        player.eulerAngles = new Vector3(0, 90, 0);

        transition.SetTrigger("End");


        yield return null;
    }

}
