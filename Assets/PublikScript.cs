using UnityEngine;
using System.Collections;

public class PublikScript : MonoBehaviour {

	public Animator _animator;

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
	}

	public void cheer() {
		_animator.SetTrigger ("Celebrate");
	}
}
