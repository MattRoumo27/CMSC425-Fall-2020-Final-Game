using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLever : Interactable
{
    #region Lever Vars
    public float switchAngleOff = -29f;
    public float switchAngleOn = 29f;

    Quaternion rotOff;
    Quaternion rotOn;

    bool isOff = true;
    bool isAnimatingSwitch = false;
    float changeSwitchSign;
    AudioSource switchAudioSource;
    public AudioClip clickSound;
    #endregion 

    public float switchAnimationTime = 1f;
    public float bridgeAnimationTime = 2f;
    public GameObject wall;

    #region Bridge Vars
    public GameObject bridge;
    Transform bridgeTransform;
    public float bridgeYRaised = -0.2f;
    public float bridgeYLowered = -2.6f;

    Vector3 posRaised;
    Vector3 posLowered;

    bool isBridgeLowered = true;
    bool isAnimatingBridge = false;
    float changeBridgeSign;
    AudioSource bridgeAudioSource;
    public AudioClip bridgeMovingSound;
    #endregion


    // Start is called before the first frame update
    private void Start()
    {
        bridgeTransform = bridge.GetComponent<Transform>();
        // Set Initial values for switch
        rotOff = Quaternion.Euler(switchAngleOff, 0, 0);
        rotOn = Quaternion.Euler(switchAngleOn, 0, 0);

        // Set initial values for bridge
        posLowered = new Vector3(-0.807f, bridgeYLowered, 0);
        posRaised = new Vector3(-0.807f, bridgeYRaised, 0);

        // Set audio components
        switchAudioSource = GetComponent<AudioSource>();
        bridgeAudioSource = bridge.GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        base.Interact();
        StartCoroutine(SwitchOnOff());
        wall.SetActive(!wall.activeSelf);
    }

    public IEnumerator SwitchOnOff()
    {
        StartCoroutine(LowerOrRaiseBridge());

        if (isAnimatingSwitch)
        {
            changeSwitchSign = -changeSwitchSign;
            isOff = !isOff;
            switchAudioSource.PlayOneShot(clickSound);
            yield break;
        }

        isAnimatingSwitch = true;
        
        float interpolationParameter;

        if (isOff)
        {
            interpolationParameter = 0;
            changeSwitchSign = 1;
        } 
        else 
        {
            interpolationParameter = 1;
            changeSwitchSign = -1;
        }

        switchAudioSource.PlayOneShot(clickSound);

        while (isAnimatingSwitch)
        {
            interpolationParameter = interpolationParameter + changeSwitchSign * Time.deltaTime / switchAnimationTime;

            // Clamp the interpolation parameter
            if (interpolationParameter >= 1 || interpolationParameter <= 0)
            {
                interpolationParameter = Mathf.Clamp(interpolationParameter, 0, 1);
                isAnimatingSwitch = false;
            }

            // Set the X angle to however much rotation is done so far
            transform.localRotation = Quaternion.Lerp(rotOff, rotOn, interpolationParameter);

            // Tell unity to start from here at next frame
            yield return null;
        }

        // Toggle on/off state
        isOff = !isOff;

    }

    public IEnumerator LowerOrRaiseBridge()
    {
        if (isAnimatingBridge)
        {
            changeBridgeSign = -changeBridgeSign;
            isBridgeLowered = !isBridgeLowered;
            bridgeAudioSource.PlayOneShot(bridgeMovingSound);
            yield break;
        }

        isAnimatingBridge = true;

        float interpolationParameter;

        if (isBridgeLowered)
        {
            interpolationParameter = 0;
            changeBridgeSign = 1;
        }
        else 
        {
            interpolationParameter = 1;
            changeBridgeSign = -1;
        }

        bridgeAudioSource.PlayOneShot(bridgeMovingSound);
        while (isAnimatingBridge)
        {
            interpolationParameter = interpolationParameter + changeBridgeSign * Time.deltaTime / bridgeAnimationTime;

            if (interpolationParameter >= 1 || interpolationParameter <= 0)
            {
                interpolationParameter = Mathf.Clamp(interpolationParameter, 0, 1);
                isAnimatingBridge = false;
            }

            bridgeTransform.localPosition = Vector3.Lerp(posLowered, posRaised, interpolationParameter);
            yield return null;
        }

        isBridgeLowered = !isBridgeLowered;
    }

}
