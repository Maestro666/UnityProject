using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour {

	public GreenOrc OrcScript;
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.GetComponent<Rabbit> () != null) 
		{
			OrcScript.Attack ();
		}
	}
}