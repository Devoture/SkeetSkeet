using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskSpawner : MonoBehaviour {

	public GameObject[] spawnLocations;
	public GameObject[] disks;
	public float speed = 5.0f;
	public float timeBetweenDisks = 1.0f;

	private bool canSpawn = true;
	private int randomSpawn;
	private int prevDiskSpawnIndex;
	private int randomDisk;
	private int prevDiskIndex;

	void Update() {
		if(canSpawn) {
			StartCoroutine(SpawnDisk(timeBetweenDisks));
		}
	}

	void Spawn() {
		randomSpawn = Random.Range(0, spawnLocations.Length);
		randomDisk = Random.Range(0, disks.Length);
		while(randomSpawn == prevDiskSpawnIndex || randomDisk == prevDiskIndex) {
			if(randomSpawn == prevDiskSpawnIndex) {
				randomSpawn = Random.Range(0, spawnLocations.Length);
			}
			if(randomDisk == prevDiskIndex) {
				randomDisk = Random.Range(0, disks.Length);
			}
		}
		prevDiskSpawnIndex = randomSpawn;
		prevDiskIndex = randomDisk;
		GameObject disk = Instantiate(disks[prevDiskIndex], spawnLocations[prevDiskSpawnIndex].transform.position, Quaternion.identity);
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
