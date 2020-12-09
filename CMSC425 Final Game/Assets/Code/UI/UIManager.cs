using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject inventoryUI;
    public GameObject equipmentUI;
    public PlayerManager playerManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryUI.activeSelf == false)
            {
                equipmentUI.SetActive(false);
                inventoryUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                playerManager.setUI(true);
            }
            else
            {
                inventoryUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                playerManager.setUI(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            if (equipmentUI.activeSelf == false)
            {
                equipmentUI.SetActive(true);
                inventoryUI.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                playerManager.setUI(true);
            }
            else
            {
                equipmentUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                playerManager.setUI(false);
            }
        }
    }
}
