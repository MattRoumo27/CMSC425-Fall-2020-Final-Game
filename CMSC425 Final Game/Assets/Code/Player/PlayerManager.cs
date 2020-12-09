using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    private bool openedUI = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setUI(bool value)
    {
        openedUI = value;
    }

    public bool getUI()
    {
        return openedUI;
    }
}
