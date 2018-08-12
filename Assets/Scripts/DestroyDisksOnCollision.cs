using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDisksOnCollision : MonoBehaviour {

	public int scoreDecrement = -10;

	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "Player") {
			GameManager.Instance.ResetPlayerPosition();
			GameManager.Instance.UpdateScore(scoreDecrement);
		} else {
			Destroy(other.gameObject);
		}
	}
}
