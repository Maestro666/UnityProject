using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : IMusicToggle {
    public AudioSource music;
    public override void setMusic(bool state)
    {
        if (state)
        {
            music.Play();
        }
        else
        {
            music.Stop();
        }
    }
	// Use this for initialization
	void Start () {
        if (MusicManager.Instance.isMusicOn())
        {
            setMusic(true);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
