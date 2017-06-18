using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICoins : MonoBehaviour {

	UILabel coinsLabel;
	public static UICoins countCoins;

	// Use this for initialization
	void Start () {
		this.coinsLabel = this.transform.GetComponent<UILabel>();
		countCoins = this;
	}
	
	// Update is called once per frame
	public void amountOfCoins (int coins) {
		
		
	}
}
