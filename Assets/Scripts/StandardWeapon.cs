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
        newG.GetComponent<Rigidbody2D>().AddForce(transform.up * ((holdTimer * holdTimer * 10) + 1) * 100);
        newG.GetComponent<Projectile>()._owner = tonky;
        newG.transform.up = transform.up;

        FMOD_StudioSystem.instance.PlayOneShot("event:/Tank_Shot", Vector3.zero);

        //Add force to tank
        tonky.GetComponent<Rigidbody2D>().AddForce(-transform.up * ((holdTimer * holdTimer * 500) + 1));
        holdTimer = 0;
    }
}
