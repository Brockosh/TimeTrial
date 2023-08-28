using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuEvents : MonoBehaviour
{
    public event Action OnPlayerPressedSettings;
    public event Action OnPlayerPressedMainMenu;

    public void CallPlayerPressedSetting()
    {
        OnPlayerPressedSettings?.Invoke();
    }

    public void CallPlayerPressedMainMenu()
    {
        OnPlayerPressedMainMenu?.Invoke();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
