using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWaves : MonoBehaviour
{
    public GameObject zombie;
    Vector3[] SpawnPoints = new Vector3[3];


    // Start is called before the first frame update
    void Start()
    {

        SpawnPoints[0] = new Vector3(-2, 1, 20);
        SpawnPoints[1] = new Vector3(-2, 1, 38);
        SpawnPoints[2] = new Vector3(10, 1, 30);
    }

    private void OnMouseDown()
    {
        StartCoroutine(ReleaseTheHorde());
    }

    IEnumerator ReleaseTheHorde()
    {

        for (int t = 0; t < 5; t++)
        {
            yield return new WaitForSeconds(3);
            int i = Random.Range(0, 3);
            Instantiate(zombie, SpawnPoints[i], Quaternion.identity);
        }

        //int i = Random.Range(0, 3);
        //Instantiate(zombie, SpawnPoints[i], Quaternion.identity);



        yield break;
    }
}

// -2, 1, 20