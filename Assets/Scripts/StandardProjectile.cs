using UnityEngine;
using System.Collections;

public class StandardProjectile : Projectile {
    
	void Start () {
	}
	
	void Update () {

	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Tonky tonky = collision.gameObject.GetComponent<Tonky>();

        if (tonky != null)
        {
            tonky.Damage(Mathf.FloorToInt(Mathf.FloorToInt(GetComponent<Rigidbody2D>().velocity.magnitude / 4)), _owner);
            Destroy(gameObject);
        }
    }
}
