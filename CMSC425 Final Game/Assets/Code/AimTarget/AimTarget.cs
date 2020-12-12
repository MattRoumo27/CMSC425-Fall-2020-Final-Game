using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AimTarget", menuName = "AimTarget")]
public class AimTarget : ScriptableObject
{
    public int numberOfTargetsAlive;
    public int initialTargetsAlive;

    private GameObject bridge;
    private MeshRenderer bridgeRender;

    private void OnEnable() 
    {
        numberOfTargetsAlive = initialTargetsAlive;
        bridge = GameObject.FindGameObjectWithTag("Bridge");
        bridgeRender = bridge.GetComponent<MeshRenderer>();
    }

    public void TargetHit(AimTargetBehavior caller)
    {
        numberOfTargetsAlive--;
        Debug.Log(bridge.ToString());
        if (numberOfTargetsAlive <= 0)
        {
            bridge = GameObject.FindGameObjectWithTag("Bridge");
            bridgeRender = bridge.GetComponent<MeshRenderer>();
            // Set bridge down after all targets have been shot by the player
            if (bridgeRender != null) 
            {
                caller.StartCoroutine(caller.RaiseBridge());
                caller.AnimateCamera();
            }
            
        }
    }

}
