﻿using UnityEngine;
using System.Collections;

public class Tonky : MonoBehaviour {

   // Health
    public int _health;
    public int _maxHealth;

    // Identification
    public int _playerId;
    public string _playerName;
    
    // Physics
    private Rigidbody2D _rigidBody;

    // Sprite
    private SpriteRenderer _spriteRenderer;
    public Sprite[] _sprite;

    // Jesper, kodar vapen på Höga-Berget...
    public Weapon _weapon;

    public AnimationCurve _turnCurve;

	// Use this for initialization
	void Start () {
       // Health
        _maxHealth = 100;
        _health = _maxHealth;

        // Sprite
        _spriteRenderer = GetComponent<SpriteRenderer>();

        if (_spriteRenderer == null)
        {
            Debug.Log("No spriteRenderer");
        }
        
        if (_sprite == null)
        {
            Debug.Log("No sprite");
        }
        else 
        {
            _spriteRenderer.sprite = Game.Instance._playerSprites[_playerId];
        }

        // Physics
        _rigidBody = GetComponent<Rigidbody2D>();

        // Weeaboopon
        _weapon.tonky = transform.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        
       
        Vector3 vec = new Vector3(Input.GetAxis("Horizontal" + _playerId), -Input.GetAxis("Vertical" + _playerId),0);
        Debug.DrawRay(transform.position, transform.up);

        Vector3 delta = vec - transform.up;
        float magnitude = delta.magnitude;

        // Fucking fuck this shit
        //float d = ((magnitude) / Mathf.PI);
        //transform.up = Vector3.Lerp(transform.up, vec, _turnCurve.Evaluate(1 - ((magnitude) / Mathf.PI)) * 0.1f);
        transform.up = Vector3.Lerp(transform.up, vec, 0.01f);

        if (magnitude < 1f)
        {
            _rigidBody.AddForce((transform.up * 2f ) * vec.magnitude * (1.0f - magnitude));
        }

        //transform.Rotate(0, 0, Input.GetAxis("Horizontal" + _playerId));

        //_rigidBody.AddForce(transform.up * Input.GetAxis("Vertical" + _playerId));

        if (Input.GetButton("Fire1"))
        {
            _weapon.holdFire();
        }

        else if (Input.GetButtonUp("Fire1"))
        {
            _weapon.transform.position = transform.position;
            _weapon.transform.up = transform.up;
            _weapon.releaseFire();
        }
	}

    public void Damage(int damageAmount_, string damagingPlayerName_)
    {
        _health -= damageAmount_;

        // Skriv ut damage eller någon skit

        if (_health <= 0)
        {
            Die(damagingPlayerName_);
        }
    }

    public void Nudge(Vector2 nudgeAmount_)
    {
        _rigidBody.velocity += nudgeAmount_;
    }

    public void Heal(int healAmount_)
    {
        _health += healAmount_;

        // Skriv ut heal eller någon skit

        if (_health > _maxHealth)
        {
            RestoreMaxHealth();
        }
    }

    public void RestoreMaxHealth()
    {
        _health = _maxHealth;
    }

    void Die(string playerName_)
    {
        // Skriv skit på skärm'n för fan
    }
}
