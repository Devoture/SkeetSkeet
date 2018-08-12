using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager Instance { get { return instance; }}
	public GameObject player;
	public GameObject diskSpawner;
	public Text scoreText;
	public Text timerText;
	public int gameLength = 30;

	private static GameManager instance;
	private int score = 0;
	private Vector2 playerStartPos;
	private int currentTime;

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
		timerText.text = "Time: " + gameLength.ToString();
		currentTime = gameLength;
		StartCoroutine(Timer());
	}

	public void ResetPlayerPosition() {
		player.transform.position = playerStartPos;
		player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
	}

	public void UpdateScore(int amount) {
		score += amount;
		if(score <= 0) {
			score = 0;
		}
		UpdateHUD();
	}

	void UpdateHUD() {
		scoreText.text = "Score: " + score.ToString();
	}

	IEnumerator Timer() {
		yield return new WaitForSeconds(1);
		currentTime -= 1;
		if(currentTime >= 0) {
			timerText.text = "Timer: " + currentTime.ToString();
			StartCoroutine(Timer());
			if(currentTime == 0) {
				GameOver();
			}
		}	
	}

	private void GameOver() {
		Debug.Log("GameOver");
		diskSpawner.SetActive(false);
	}
}
