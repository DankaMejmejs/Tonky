using UnityEngine;
using System.Collections;

public class StandardProjectile : Projectile {
    
	void Start () {
	}
	
	void Update () {
        //transform.position += new Vector3(_speed.x, _speed.y, 0) * Time.deltaTime;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Tonky tonky = collision.gameObject.GetComponent<Tonky>();

        if (tonky != null)
        {
            tonky.GetComponent<Rigidbody2D>().AddForce(_speed * _speed.magnitude * 2);
            Destroy(gameObject);
        }
    }
}
