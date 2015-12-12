﻿using UnityEngine;
using System.Collections;

public class ShooterScript : MonoBehaviour {

    public GameObject weapon;

	void Start () {
        weapon = Instantiate(weapon);
        weapon.GetComponent<Weapon>().tonky = transform.gameObject;
    }
	
	void Update () {
	    if (Input.GetKey("s")) {
            weapon.GetComponent<Weapon>().holdFire();
        }
        if (Input.GetKeyUp("s")) {
            weapon.GetComponent<Weapon>().releaseFire();
        }

        weapon.transform.position = transform.position;
        weapon.transform.up = new Vector3(0, -1, 0);
	}
}
