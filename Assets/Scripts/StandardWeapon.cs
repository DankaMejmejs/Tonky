using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StandardWeapon : Weapon {
    
    void Start () {
    }
	
	void Update () {
	}

    public override void holdFire() {
    }

    public override void releaseFire() {
        GameObject newG = Instantiate(projectilePrototype);
        newG.transform.position = transform.position;
        newG.GetComponent<Projectile>()._speed = transform.up * 10;
    }
}
