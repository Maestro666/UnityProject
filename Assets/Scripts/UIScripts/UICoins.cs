using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICoins : MonoBehaviour {

	public UILabel coinsLabel;
	public static UICoins countCoins;

	// Use this for initialization
	void Awake () {
		countCoins = this;
        amountOfCoins(0);
	}
	
	// Update is called once per frame
	public void amountOfCoins (int coins) {
        coinsLabel.text = coins.ToString("0000");
	}
}
