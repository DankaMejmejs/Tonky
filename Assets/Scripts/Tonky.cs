﻿using UnityEngine;
using System.Collections;

public class Tonky : MonoBehaviour {

   // Health
    public int _health;
    public int _maxHealth;

    // Identification
    public int _playerId;
    
    // Physics
    private Rigidbody2D _rigidBody;

    // Sprite
    private SpriteRenderer _spriteRenderer;
    public Sprite[] _sprite;

    // Jesper, kodar vapen på Höga-Berget...
    public Weapon _weapon;

    public AnimationCurve _turnCurve;

    private Material _material;

	// Use this for initialization
	void Start () {
        instantiateMaterial();
        setColor(Color.white);

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
        _weapon = Instantiate(_weapon);
        _weapon.tonky = transform.gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        
       
        Vector3 vec = new Vector3(Input.GetAxis("Horizontal" + _playerId), -Input.GetAxis("Vertical" + _playerId),0);
        Debug.DrawRay(transform.position, transform.up);
        Debug.DrawRay(transform.position, vec, Color.red);

        Vector3 delta = vec - transform.up;
        float magnitude = delta.magnitude;

        float a1 = Mathf.Atan2(vec.y, vec.x);
        float a2 = Mathf.Atan2(transform.up.y, transform.up.x);
        /*
        float a = 0;
        if (vec.sqrMagnitude > 0) {
            a = (((a1 - a2) + 180) % 360 - 180);
            transform.Rotate(new Vector3(0, 0, 1), Mathf.Sign(a) * 1);
            Debug.Log(Mathf.Sign(a));
        }
        */

        float a = Mathf.Atan2(Mathf.Sin(a1 - a2), Mathf.Cos(a1 - a2));
        if (vec.sqrMagnitude > 0)
            transform.Rotate(new Vector3(0, 0, 1), Mathf.Sign(a) * _turnCurve.Evaluate(1 - (Mathf.Abs(a) / 2 * Mathf.PI)));


        // §ucking fuck this shit
        //float d = ((magnitude) / Mathf.PI);
        //transform.up = Vector3.Lerp(transform.up, vec, _turnCurve.Evaluate(1 - ((magnitude) / Mathf.PI)) * 0.1f);
        //transform.up = Vector3.Lerp(transform.up, vec, 0.01f);

        if (magnitude < 1f)
        {
            _rigidBody.AddForce((transform.up * 5f ) * vec.magnitude * (1.0f - magnitude));
        }

        //transform.Rotate(0, 0, Input.GetAxis("Horizontal" + _playerId));

        //_rigidBody.AddForce(transform.up * Input.GetAxis("Vertical" + _playerId));

        _weapon.transform.position = transform.position + transform.up * 0.4f;

        if (Input.GetButton("Fire" + _playerId))
        {
            _weapon.holdFire();
        }

        else if (Input.GetButtonUp("Fire" + _playerId))
        {
            _weapon.transform.up = transform.up;
            _weapon.releaseFire();
        }
	}

    public void Damage(int damageAmount_, GameObject damagingPlayer_)
    {
        _health -= damageAmount_;

        Debug.Log(damageAmount_);

        // Skriv ut damage eller någon skit

        if (_health <= 0)
        {
            Die(damagingPlayer_);
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

    void Die(GameObject damagingPlayer_)
    {
        // Skriv skit på skärm'n för fan
        Debug.Log("Ded");
    }

    private void instantiateMaterial() {
        _material = Instantiate(transform.GetComponent<SpriteRenderer>().material);
        transform.GetComponent<SpriteRenderer>().material = _material;
    }

    public void setColor(Color color) {
        _material.SetColor("_Color", color);
    }
}
