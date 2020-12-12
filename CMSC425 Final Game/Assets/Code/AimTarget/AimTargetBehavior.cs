using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTargetBehavior : MonoBehaviour
{
    public AimTarget target;
    public Transform bridge;
    public Vector3 startPos;
    public Vector3 endPos;
    public CameraManager cameraManager;

    public float raiseTime = 5;

    public bool isRaising = false;

    private void Start() 
    {
        startPos = bridge.localPosition;
        endPos = new Vector3(0.4524f, 0.053f, 0.984f);
    }

    public void killAimTarget()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        target.TargetHit(this);
    }

    public IEnumerator RaiseBridge()
    {
        if (isRaising)
        {
            yield break;
        }

        float interpolationParameter = 0;
        isRaising = true;

        while (isRaising)
        {
            interpolationParameter = interpolationParameter + 1 * Time.deltaTime / raiseTime;
            if (interpolationParameter >= 1)
            {
                // Clamp the lerp parameter
                interpolationParameter = Mathf.Clamp(interpolationParameter, 0, 1);
                isRaising = false;
            }

            bridge.localPosition = Vector3.Lerp(startPos, endPos, interpolationParameter); 
            yield return null;
        }
    }

    public void AnimateCamera()
    {
        StartCoroutine(cameraManager.TranslateBridgeCamera());
    }
}
