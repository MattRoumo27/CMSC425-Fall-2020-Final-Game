using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        if (!player)
        {
            Debug.Log("DIDNT GET PLAYER");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
