using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFruits : MonoBehaviour {

    public UILabel countOfFruits;
    public static UIFruits current;

	// Use this for initialization
	void Awake () {
        current = this;
	}

    public void FruitsCount(int amount) {
        countOfFruits.text = amount + "/" + LevelController.current.maxFruit;
    }

}
