using UnityEngine;
using System.Collections;

public class AnimationDestroy : MonoBehaviour {

    public float _destroyTime;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, _destroyTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
