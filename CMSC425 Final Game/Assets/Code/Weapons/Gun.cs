using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 15f;

    public int maxAmmo = 10;
    public int currentAmmo;
    public float reloadTime = 1f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public ParticleSystem sparkFlash;
    public GameObject impactEffect;

    public PlayerManager playerManager;

    private float nextTimeToFire = 0f;

    public Animator animator;
    AudioSource audioSource;
    public AudioClip gunShot;
    public AudioClip reloadSound;
    public AudioClip emptyClipReload;

    // Reloading Animation Vars
    public GameObject gunMagazine;
    bool isAnimating = false;
    private bool isReloading = false;
    Vector3 magazineInitialPos;
    float changeSign;

    public bool isPaused = false;

    private void Start() 
    {
        currentAmmo = maxAmmo; 
        audioSource = GetComponent<AudioSource>();
        magazineInitialPos = gunMagazine.transform.localPosition;

        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
    }

    void OnEnable() 
    {
        isReloading = false;
        isAnimating = false;
        animator.SetBool("Reloading", false);
    }

    private void OnDisable() 
    {
        gunMagazine.transform.localPosition = magazineInitialPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading) 
        {
            return;
        }
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        //Only shoot or reload if the UI is not opened
        if (playerManager.getUI() == false)
        {
            if (!isPaused)
            {
                if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
                {
                    nextTimeToFire = Time.time + 1f / fireRate;
                    Shoot();
                }

                if (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo)
                {
                    StartCoroutine(Reload());
                }
            }
        }
    }

    IEnumerator Reload()
    {
        if (isAnimating || isReloading) 
        {
            yield break;
        }
        isAnimating = true;
        isReloading = true;

        float interpolationParameter = 1;
        Debug.Log("Reloading...");
        audioSource.PlayOneShot(reloadSound);
        Vector3 newPosition = gunMagazine.transform.localPosition - new Vector3(0, 0.15f, 0);

        while (isAnimating)
        {
            interpolationParameter = interpolationParameter - 1 * Time.deltaTime / reloadTime * 2;

            // Clamp the interpolation parameter when it goes below 0 to finish animation
            if (interpolationParameter <= 0)
            {
                interpolationParameter = 0;
                isAnimating = false;
            }

            // Interpolate translation and rotation using retrospective Lerp
            gunMagazine.transform.localPosition = Vector3.Lerp(newPosition, gunMagazine.transform.localPosition, interpolationParameter);
        
            yield return null;
        }

        Vector3 originalPosition = magazineInitialPos;
        isAnimating = true;
        while (isAnimating)
        {
            interpolationParameter = interpolationParameter + 1 * Time.deltaTime / reloadTime * 2;
            
            // Clamp the interpolation parameter when it goes above 1 to finish animation
            if (interpolationParameter >= 1)
            {
                interpolationParameter = 1;
                isAnimating = false;
            }

            // Interpolate translation using Lerp
            gunMagazine.transform.localPosition = Vector3.Lerp(gunMagazine.transform.localPosition, originalPosition, interpolationParameter);

            yield return null;
        }

        currentAmmo = maxAmmo;
        isReloading = false;
    }

    void Shoot()
    {
        muzzleFlash.Play();
        sparkFlash.Play();
        audioSource.PlayOneShot(gunShot);

        currentAmmo--;

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            AimTargetBehavior aimTarget = hit.transform.GetComponent<AimTargetBehavior>();
            if (aimTarget != null)
            {
                aimTarget.killAimTarget();
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
