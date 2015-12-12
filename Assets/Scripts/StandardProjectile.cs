using UnityEngine;
using System.Collections;

public class StandardProjectile : Projectile {
    
	void Start () {
	}
	
	void Update () {
        transform.position += new Vector3(_speed.x, _speed.y, 0) * Time.deltaTime;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Swag");

        Tonky tonky = collision.gameObject.GetComponent<Tonky>();

        if (tonky != null)
        {
            tonky.GetComponent<Rigidbody2D>().AddForce(-tonky.transform.up * _speed.magnitude * _speed.magnitude * 100);
            Destroy(this.gameObject);
        }
    }
}
