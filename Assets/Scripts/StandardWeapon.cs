﻿using UnityEngine;
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
        newG.GetComponent<Projectile>()._speed = transform.up * ((holdTimer * holdTimer * 10) + 1);
        newG.GetComponent<Projectile>()._owner = tonky;

        //Add force to tank
        tonky.GetComponent<Rigidbody2D>().AddForce(-tonky.transform.up * ((holdTimer * holdTimer * 500) + 1));
        holdTimer = 0;
    }
}
