using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenuUI;
    private bool isPaused = false;

    [SerializeField] private GameObject deathMenuUI;

    public Gun primaryGun;
    public Gun secondaryGun;
    public AimTarget targets;
    public AudioSource playerSource;
    public AudioClip deathSound;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isPaused)
                DeactivateMenu();
            else
                ActivateMenu();
        }
    }

   public void ActivateMenu()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true;
        Cursor.lockState = CursorLockMode.None;
        primaryGun.isPaused = true;
        secondaryGun.isPaused = true;
        isPaused = true;
        
    }

   public void DeactivateMenu()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
        Cursor.lockState = CursorLockMode.Locked;
        primaryGun.isPaused = false;
        secondaryGun.isPaused = false;
        isPaused = false;

        StartCoroutine(WaitBeforeFiring());
    }

    public void Restart() {
        targets.numberOfTargetsAlive = targets.initialTargetsAlive;

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        DeactivateMenu();
    }

    IEnumerator WaitBeforeFiring()
    {

        yield return new WaitForSeconds(.1f);
        primaryGun.isPaused = false;
        secondaryGun.isPaused = false;
    }

    public IEnumerator OnDeath()
    {
        deathMenuUI.SetActive(true);
        Time.timeScale = 0;
        playerSource.PlayOneShot(deathSound);
        Cursor.lockState = CursorLockMode.None;
        primaryGun.isPaused = true;
        secondaryGun.isPaused = true;
        isPaused = true;
        yield return new WaitForSeconds(1);
        AudioListener.pause = true;
    }
}
