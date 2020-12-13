using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChest : Interactable
{
    public float angleOpened = 110; // X-axis Euler angle when opened.
    public float angleClosed = 0;   // X-axis Euler angle when closed.

    public float openTime = 1.413f;
    public float closeTime = 0.603f;

    Quaternion rotOpened; // Rotation when fully opened.
    Quaternion rotClosed; // Rotation when full closed.

    bool isFlapping = false; // Animate and lockout while true.
    bool isClosed = true; // Track open/closed state.

    // Set this according to whether we are going from zero
    // to one, or from one to zero.
    float changeSign;

    AudioSource audioSource;
    public AudioClip chestOpenSound;
    public AudioClip chestCloseSound;

    private void Start()
    {
        // Create and remember the open/closed quaternions.
        rotOpened = Quaternion.Euler(angleOpened, 0, 0);
        rotClosed = Quaternion.Euler(angleClosed, 0, 0);
        audioSource = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        base.Interact();

        StartCoroutine(OpenLid());
    }

    public IEnumerator OpenLid()
    {
        // Lockout any attempt to start another FlapLid while
        // one is already running.

        if (isFlapping)
        {
            changeSign = -changeSign;
            isClosed = !isClosed;
            yield break;
        }

        // Start the animation and lockout others.

        isFlapping = true;

        // Vary this from zero to one, or from one to zero,
        // to interpolate between our quaternions.

        float interpolationParameter;
        float duration;


        // Set lerp parameter to match our state, and the sign
        // of the change to either increase or decrease the
        // lerp parameter during animation.

        if (isClosed)
        {
            interpolationParameter = 0;
            changeSign = 1;
            duration = openTime;
            audioSource.PlayOneShot(chestOpenSound);
        }
        else
        {
            interpolationParameter = 1;
            changeSign = -1;
            duration = closeTime;
            audioSource.PlayOneShot(chestCloseSound);
        }

        while (isFlapping)
        {
            // Change our "lerp" parameter according to speed and time,
            // and according to whether we are opening or closing.
            interpolationParameter = interpolationParameter + changeSign * Time.deltaTime / duration;

            // At or past either end of the lerp parameter's range means
            // we are on our last step.

            if (interpolationParameter >= 1 || interpolationParameter <= 0)
            {
                // Clamp the lerp parameter.

                interpolationParameter = Mathf.Clamp(interpolationParameter, 0, 1);

                isFlapping = false; // Signal the loop to stop after this.
            }

            // Set the X angle to however much rotation is done so far.

            transform.localRotation = Quaternion.Lerp(rotClosed, rotOpened, interpolationParameter);

            // Tell Unity to start us up again at some future time.

            yield return null;
        }

        // Toggle our open/closed state.

        isClosed = !isClosed;
    }
}
