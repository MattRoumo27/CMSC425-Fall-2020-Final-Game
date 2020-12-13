using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public Transform player;
    public Animator transition;
    public Transform location;
    public GameObject zombie;
    public GameObject currIsland;
    public GameObject nextIsland;
    public AudioSource audioSource;
    public AudioClip warpSound;
    public CameraManager cameraManager;
    public int stopMovementDuration = 3;
    //-18,1,19
    //0,90,0

    private void Start() 
    {
       //audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hello");
        StartCoroutine(TransitionPlayer());
    }


    IEnumerator TransitionPlayer()
    {
        Debug.Log("Fading out...");
        transition.SetTrigger("Start");

        StartCoroutine(cameraManager.LockMovement(stopMovementDuration));
        

        nextIsland.SetActive(true);
        

        yield return new WaitForSeconds(1);
        Debug.Log(player.position);
        audioSource.PlayOneShot(warpSound);
        
        yield return new WaitForSeconds(3);
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
            GameObject zombie1 = Instantiate(zombie, new Vector3(65, .82f, 71), Quaternion.identity);
            GameObject zombie2 = Instantiate(zombie, new Vector3(47, .82f, 70), Quaternion.identity);
            GameObject zombie3 = Instantiate(zombie, new Vector3(64, .82f, 65), Quaternion.identity);

            zombie1.GetComponent<EnemyHealth>().zone = 2;
            zombie2.GetComponent<EnemyHealth>().zone = 2;
            zombie3.GetComponent<EnemyHealth>().zone = 2;
        }

        player.eulerAngles = new Vector3(0, 90, 0);

        Debug.Log("Fading in...");
        transition.SetTrigger("End");

      
        currIsland.SetActive(false);
  


        yield return null;
    }

}
