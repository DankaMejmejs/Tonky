using UnityEngine;
using System.Collections;

public class StandardProjectile : Projectile {

    private float _lifeTimer = 0;
    private int _bounceCounter = 0;

    public float _despawnTimer = 3;

    public GameObject _theBay;

    void Start () {
	}
	
	void Update () {
        _lifeTimer += Time.deltaTime;

        if (_lifeTimer >= _despawnTimer)
        {
            Explode();
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Tonky tonky = collision.gameObject.GetComponent<Tonky>();
        Projectile projectile = collision.gameObject.GetComponent<Projectile>();

        if (tonky != null)
        {
            tonky.Damage(Mathf.FloorToInt(Mathf.FloorToInt(GetComponent<Rigidbody2D>().velocity.magnitude)), _owner);
            Explode();
        }

        else if(projectile != null)
        {
            // Göra skit?
        }

        else
        {
            _bounceCounter++;

            if (_bounceCounter >= 3)
            {
                Explode();
            }
        }
    }

    public void Explode()
    {
        Instantiate(_theBay, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}