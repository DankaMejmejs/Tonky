using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StandardWeapon : Weapon {

    float holdTimer = 0;

    void Start () {
    }
	
	void Update () {
	}

    public override void holdFire() {
        holdTimer += Time.deltaTime;
    }

    public override void releaseFire() {
        GameObject newG = Instantiate(projectilePrototype);
        newG.transform.position = transform.position;
        newG.GetComponent<Projectile>()._speed = transform.up * (holdTimer + 1) * 0.5f;
        holdTimer = 0;

        //Add force to tank
        tonky.GetComponent<Rigidbody2D>().AddForce(-tonky.transform.up * (holdTimer + 1) * 0.5f);
        newG.GetComponent<Projectile>()._owner = tonky;
    }
}
