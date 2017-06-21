using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {
	public static LevelController current;
	Vector3 startingPosition;
    private int countCoins;
    private int currentFruitAmount;
    public int maxFruit;

	void Awake() {
		current = this;
	}

    public void collectGem(int gemIndex) {
        UIGems.current.activateGem(gemIndex);
    }


    public void addCoins(int amount)
    {
        countCoins += amount;
        UICoins.countCoins.amountOfCoins(countCoins);
    }

    public void addFruit(int amount) {
        currentFruitAmount += amount;
        UIFruits.current.FruitsCount(currentFruitAmount);
    }

    public void setStartPosition(Vector3 pos) {
		this.startingPosition = pos;
	}
	public void onRabitDeath(Rabbit rabit) {
		//При смерті кролика повертаємо на початкову позицію
		rabit.transform.position = this.startingPosition;
        UILifes.current.decreaseHP();
        Rabbit.current.currentHealth--;
        if (Rabbit.current.currentHealth == 0)
        {
            SceneManager.LoadScene("ChooseLevel");
        }
    }
}