using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pause_Button : MonoBehaviour {
    public GameObject Settings_Window;
    public Pause_Button aPause_Button;
    public UnityEvent signalOnClick = new UnityEvent();
    public void _onClick()
    {
        this.signalOnClick.Invoke();
    }
    // Use this for initialization
    void Start () {
        aPause_Button.signalOnClick.AddListener(this.onPlay);
    }

    void onPlay()
    {
        Settings_Window.SetActive(true);
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        Settings_Window.SetActive(false);
        Time.timeScale = 1;
    }
}
