using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera[] cameras;

    public Vector3 startPos;
    public Vector3 endPos;
    const int mainCamera = 0;
    const int bridgeCamera = 1;

    public bool isMoving = false;
    public bool canMovePlayer = true;
    public float moveTime = 5f;

    public AudioSource audioSource;
    public AudioClip bridgeMusic;

    // Start is called before the first frame update
    void Start()
    {
        cameras[mainCamera].enabled = true;
        cameras[bridgeCamera].enabled = false;
        startPos = new Vector3(73.05f, 1.7f, 98.27f);
        endPos = new Vector3(73.05f, 1.7f, 91.22f);
        
        cameras[1].transform.position = startPos;
    }

    public IEnumerator TranslateBridgeCamera()
    {
        audioSource.PlayOneShot(bridgeMusic);
        cameras[mainCamera].enabled = false;
        cameras[bridgeCamera].enabled = true;
        canMovePlayer = false;

        float interpolationParameter = 0;
        isMoving = true;

        while (isMoving)
        {
            interpolationParameter = interpolationParameter + Time.deltaTime / moveTime;

            if (interpolationParameter >= 1)
            {
                interpolationParameter = 1;
                isMoving = false;
            }

            cameras[bridgeCamera].transform.position = Vector3.Lerp(startPos, endPos, interpolationParameter);
            yield return null;
        }

        yield return new WaitForSeconds(2);

        cameras[bridgeCamera].enabled = false;
        cameras[mainCamera].enabled = true;
        canMovePlayer = true;
    }
}
