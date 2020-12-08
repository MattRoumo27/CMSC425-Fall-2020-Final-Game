using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayedDestroyed());
        transform.position += new Vector3(0, .5f, 0);
    }

    IEnumerator DelayedDestroyed()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

}
