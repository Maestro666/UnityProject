using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILifes : MonoBehaviour {
    public static UILifes current;
    public List<GameObject> fullHPIcons;
    private int currentLifeIcon;

	// Use this for initialization
	void Awake () {
        currentLifeIcon = fullHPIcons.Count - 1;
        current = this;
	}

    public void decreaseHP()
    {
        if (currentLifeIcon < 0) return;
        fullHPIcons[currentLifeIcon].SetActive(false);
        currentLifeIcon--;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
