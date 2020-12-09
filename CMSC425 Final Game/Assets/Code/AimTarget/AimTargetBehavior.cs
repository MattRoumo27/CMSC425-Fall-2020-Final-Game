using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTargetBehavior : MonoBehaviour
{
    public AimTarget target;

    public void killAimTarget()
    {
        target.TargetHit();
        Destroy(gameObject);
    }
}
