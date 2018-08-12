using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disk : MonoBehaviour {

	public int scoreToGive = 10;

	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "Player") {
			GameManager.Instance.UpdateScore(scoreToGive);
			GameManager.Instance.ResetPlayerPosition();
			Destroy(this.gameObject);
		}
	}
}
