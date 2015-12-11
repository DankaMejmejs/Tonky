using UnityEngine;
using System.Collections;

public class StandardProjectile : Projectile {
    
	void Start () {
	}
	
	void Update () {
        transform.position += new Vector3(_speed.x, _speed.y, 0);
	}
}
