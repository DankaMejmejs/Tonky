using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CrowdScript : MonoBehaviour {

	public List<GameObject> crowd;

	int currentIndex = 0;
    int startIndex = 0;
    int direction = 0;

	float timer = 0f;

	private bool cheering = false;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < transform.childCount; i++) {
			crowd.Add(transform.GetChild(i).gameObject);
		}

        startCheering();
    }
	
	// Update is called once per frame
	void Update () {
		if (!cheering)
			return;
		if (timer <= 0) {
			crowd [currentIndex].GetComponent<PublikScript> ().cheer();
			currentIndex += direction;
            currentIndex %= crowd.Count;
            if (currentIndex < 0)
                currentIndex = crowd.Count - 1;

            timer = 0f;

			if (currentIndex == startIndex) {
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

        currentIndex = Random.Range(0, crowd.Count);
        direction = Random.Range(-1, 1);
        if (direction < 0)
            direction = -1;
        else
            direction = 1;

        startIndex = currentIndex;
		cheering = true;
        FMOD_StudioSystem.instance.PlayOneShot("event:/Cheer_Short", Vector3.zero);
    }
}
