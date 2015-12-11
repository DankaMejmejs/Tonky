using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour {

	void Start () {
	}
	
	void Update () {
	}

    public abstract void holdFire();
    public abstract void releaseFire();
}
