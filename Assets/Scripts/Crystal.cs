using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : Collectable {
    public int crystalIndex;
	protected override void OnRabitHit (Rabbit rabit)
	{
        LevelController.current.collectGem(crystalIndex);
		this.CollectedHide ();
	}

    
}
