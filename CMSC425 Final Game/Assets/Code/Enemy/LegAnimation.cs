using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegAnimation : MonoBehaviour
{
    public float frequency = 1;
    public float degrees = 60;
    public float phase = 0;

    Quaternion baseRot;
    float start;

    // Start is called before the first frame update
    void Start()
    {
        baseRot = transform.localRotation;
        start = degrees * Mathf.Sin(phase * 2 * Mathf.PI);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = baseRot * Quaternion.Euler(
            degrees * Mathf.Sin((phase + frequency * Time.time) * 2 * Mathf.PI) - start, 0, 0);
    }
}
