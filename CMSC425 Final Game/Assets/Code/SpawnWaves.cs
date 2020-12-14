using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWaves : MonoBehaviour
{
    bool waiting_to_start = true;

    public GameObject zombie;
    Vector3[] SpawnPoints = new Vector3[8];

    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;
    public Transform spawn4;
    public Transform spawn5;
    public Transform spawn6;
    public Transform spawn7;
    public Transform spawn8;


    // Start is called before the first frame update
    void Start()
    {
        // zone 1 test points
        //SpawnPoints[0] = new Vector3(-2, 1, 20);
        //SpawnPoints[1] = new Vector3(-2, 1, 38);
        //SpawnPoints[2] = new Vector3(10, 1, 30);

        //zone 3 spawn points
        //SpawnPoints[0] = new Vector3(99.5f, 1, 5.94f);
        //SpawnPoints[1] = new Vector3(108, 1, 5.26f);
        //SpawnPoints[2] = new Vector3(117, 1, 5.97f);
        //SpawnPoints[3] = new Vector3(124, 1, 16.93f);
        //SpawnPoints[4] = new Vector3(124.1f, 1, 26.279f);
        //SpawnPoints[5] = new Vector3(123.4f, 1, 32.5f);
        //SpawnPoints[6] = new Vector3(111, 1, 32.5f);
        //SpawnPoints[7] = new Vector3(101.81f, 1, 33.73f);
        SpawnPoints[0] = new Vector3(spawn1.position.x, spawn1.position.y, spawn1.position.z);
        SpawnPoints[1] = new Vector3(spawn2.position.x, spawn2.position.y, spawn2.position.z);
        SpawnPoints[2] = new Vector3(spawn3.position.x, spawn3.position.y, spawn3.position.z);
        SpawnPoints[3] = new Vector3(spawn4.position.x, spawn4.position.y, spawn4.position.z);
        SpawnPoints[4] = new Vector3(spawn5.position.x, spawn5.position.y, spawn5.position.z);
        SpawnPoints[5] = new Vector3(spawn6.position.x, spawn6.position.y, spawn6.position.z);
        SpawnPoints[6] = new Vector3(spawn7.position.x, spawn7.position.y, spawn7.position.z);
        SpawnPoints[7] = new Vector3(spawn8.position.x, spawn8.position.y, spawn8.position.z);


    }

    private void OnMouseDown()
    {
        if (waiting_to_start)
        {
            waiting_to_start = false;
            StartCoroutine(ReleaseTheHorde());
        }

    }

    IEnumerator ReleaseTheHorde()
    {
        float wait_time = 3f;

        for (int t = 0; t < 30; t++)
        {
            yield return new WaitForSeconds(wait_time);
            int i = Random.Range(0, 8);
            GameObject zombie1 = Instantiate(zombie, SpawnPoints[i], Quaternion.identity);
            zombie1.GetComponent<EnemyHealth>().zone = 3;
            if (t == 5)
            {
                wait_time = 2.0f;
            }
            if (t == 10)
            {
                wait_time = 1.5f;
            }
            if (t == 15)
            {
                wait_time = 1.0f;
            }
            if (t == 20)
            {
                wait_time = .5f;
            }
        }

        //int i = Random.Range(0, 3);
        //Instantiate(zombie, SpawnPoints[i], Quaternion.identity);



        yield break;
    }
}

// -2, 1, 20