using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AimTarget", menuName = "AimTarget")]
public class AimTarget : ScriptableObject
{
    public int numberOfTargetsAlive;
    public int initialTargetsAlive;

    private void OnEnable() 
    {
        numberOfTargetsAlive = initialTargetsAlive;
    }

    public void TargetHit()
    {
        numberOfTargetsAlive--;
        if (numberOfTargetsAlive == 0)
        {
            // Set bridge down after all targets have been shot by the player
            
        }
    }
}
