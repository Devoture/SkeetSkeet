using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDisksOnCollision : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "Player") {
			GameManager.Instance.ResetPlayerPosition();
		} else {
			Destroy(other.gameObject);
		}
	}
}
