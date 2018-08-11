using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskSpawner : MonoBehaviour {

	public GameObject[] spawnLocations;
	public GameObject[] disks;
	public float speed = 5.0f;
	public float timeBetweenDisks = 1.0f;

	private bool canSpawn = true;
	private int random;
	private int prevDiskIndex;

	void Update() {
		if(canSpawn) {
			StartCoroutine(SpawnDisk(timeBetweenDisks));
		}
	}

	void Spawn() {
		random = Random.Range(0, spawnLocations.Length);
		while(random == prevDiskIndex) {
			random = Random.Range(0, spawnLocations.Length);
		}
		prevDiskIndex = random;
		GameObject disk = Instantiate(disks[0], spawnLocations[prevDiskIndex].transform.position, Quaternion.identity);
		if(disk.transform.position.x > 0) {
			disk.GetComponent<Rigidbody2D>().AddForce(Vector3.left * speed);
		} else {
			disk.GetComponent<Rigidbody2D>().AddForce(Vector3.right * speed);
		}
	}

	IEnumerator SpawnDisk(float waitTime) {
		Spawn();
		canSpawn = false;
		yield return new WaitForSeconds(waitTime);
		canSpawn = true;
	}
}
