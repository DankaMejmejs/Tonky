using UnityEngine;
using System.Collections;

public class StandardProjectile : Projectile {

    private float _lifeTimer = 0;
    private int _bounceCounter = 0;

	void Start () {
	}
	
	void Update () {
        _lifeTimer += Time.deltaTime;

        if (_lifeTimer >= 2)
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        _bounceCounter++;

        if (_bounceCounter >= 3)
        {
            Destroy(gameObject);
        }

        Tonky tonky = collision.gameObject.GetComponent<Tonky>();

        if (tonky != null)
        {
            tonky.Damage(Mathf.FloorToInt(Mathf.FloorToInt(GetComponent<Rigidbody2D>().velocity.magnitude / 4)), _owner);
            Destroy(gameObject);
        }
    }
}
