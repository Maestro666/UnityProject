using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour {
    public IMusicToggle musicController;

    public void switchMusic()
    {
        if (MusicManager.Instance.isMusicOn())
        {
            MusicManager.Instance.setMusicOn(false);
            musicController.setMusic(false);
        }
        else
        {
            MusicManager.Instance.setMusicOn(true);
            musicController.setMusic(true);
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
