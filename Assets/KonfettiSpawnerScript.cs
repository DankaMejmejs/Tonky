using UnityEngine;
using System.Collections;

public class KonfettiSpawnerScript : MonoBehaviour {

	float _lifeTime;
	float _maxLifeTime = 2.0f;

	// Use this for initialization
	void Start () {

		_lifeTime = _maxLifeTime;
	
	}
	
	// Update is called once per frame
	void Update () {

		_lifeTime -= Time.deltaTime;

		if (_lifeTime <= 0) {
			Destroy(this.gameObject);
		}
	
	}
}
