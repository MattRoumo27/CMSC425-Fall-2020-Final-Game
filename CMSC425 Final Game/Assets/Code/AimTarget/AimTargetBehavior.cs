using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTargetBehavior : MonoBehaviour
{
    public AimTarget target;
    public GameObject bridge;

    private void Start() 
    {
        MeshRenderer mesh = bridge.GetComponent<MeshRenderer>();
        mesh.enabled = false;
    }

    public void killAimTarget()
    {
        Destroy(gameObject);
        target.TargetHit();
    }
}
