using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CrowdScript : MonoBehaviour {

	public List<GameObject> crowd;

	int currentIndex = 0;

	float timer = 0.5f;

	private bool cheering = false;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < transform.childCount; i++) {
			crowd.Add(transform.GetChild(i).gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {



		if (!cheering)
			return;
		if (timer <= 0) {
			crowd [currentIndex].GetComponent<PublikScript> ().cheer ();
			currentIndex++;
			timer = 0.5f;

			if (currentIndex > crowd.Count) {
				currentIndex = 0;
				cheering = false;
			}
		} else {
			timer -= Time.deltaTime;
		}
	}

	public void startCheering() {
		if (cheering)
			return;

		cheering = true;
	}
}
