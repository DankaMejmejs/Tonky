using UnityEngine;
using System.Collections;

public class CrateSpawner : MonoBehaviour {
	
	public GameObject Crate;
	private bool Spawn = false;
	private bool changeThisFrame = false;
	private float SpawnTimer = 0;
	public float maxSpawnTimer = 2f;

	//void OnCollisionEnter2D (Collider2D other)
	/*void OnTrigger2D (Collider2D other)
	{
		Tonky _tonky = other.GetComponent<Tonky> ();
		if (_tonky == null) {

		} else {
			changeThisFrame = true;
		}
	}*/

	void OnTriggerEnter2D (Collider2D other)
	{
		Tonky _tonky = other.GetComponent<Tonky> ();
		if (_tonky == null) {
			
		} else {
			//changeThisFrame = true;
			SpawnCrate();
		}
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		/*if (changeThisFrame = true) {
			changeThisFrame = false;
			Spawn = true;

		} else {
			Spawn = false;
			SpawnTimer = 0;
		}

		if (Spawn == true) {
			SpawnTimer += Time.deltaTime;

			if(SpawnTimer >= maxSpawnTimer)
			{
				SpawnCrate ();
				SpawnTimer -= maxSpawnTimer;
			}
		}

		Debug.Log (SpawnTimer);*/
	}

	void SpawnCrate()
	{
		FMOD_StudioSystem.instance.PlayOneShot("event:/Ui_Crate_Spawn", Vector3.zero);
		float maxSpawnLength = 1.0f;
		float spawnDegree = Random.Range (0f, 360f);
		Vector3 spawnPos = transform.position;
		spawnPos.z = 0;
		spawnPos.x += maxSpawnLength * Mathf.Cos (spawnDegree);
		spawnPos.y += -maxSpawnLength * Mathf.Sin (spawnDegree);
		Instantiate (Crate, (spawnPos), Quaternion.identity);
	}
}
