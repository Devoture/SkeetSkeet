using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager Instance { get { return instance; }}
	public GameObject player;
	public Text scoreText;

	private static GameManager instance;
	private int score = 0;
	private Vector2 playerStartPos;

	void Awake() {
		if (instance == null) {
            instance = this;
		} else if (instance != this) {
            Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
	}

	void Start() {
		playerStartPos = player.transform.position;
	}

	public void ResetPlayerPosition() {
		player.transform.position = playerStartPos;
		player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
	}

	public void UpdateScore(int amount) {
		score += amount;
		Debug.Log(score);
		UpdateHUD();
	}

	void UpdateHUD() {
		scoreText.text = "Score: " + score.ToString();
	}
}
