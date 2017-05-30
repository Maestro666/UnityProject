using UnityEngine;

public class Collectable : MonoBehaviour {
	protected virtual void OnRabitHit(Rabbit rabit) {
	}
	void OnTriggerEnter2D(Collider2D collider) {
			Rabbit rabit = collider.GetComponent<Rabbit>();
			if(rabit != null) {
				this.OnRabitHit (rabit);
			}
	}
	public void CollectedHide() {
		Destroy(this.gameObject);
	}
}
