using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    public Transform player;
    public Animator transition;
    public Transform location;
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Reset());
    }

    IEnumerator Reset()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);
        Debug.Log(player.position);
        Vector3 path = location.position;
        for (int i = 0; i < 100; i++)
        {
            player.position = path;
            Debug.Log(player.position);
        }

        player.eulerAngles = new Vector3(0, 90, 0);

        transition.SetTrigger("End");

        yield return null;
    }
}
