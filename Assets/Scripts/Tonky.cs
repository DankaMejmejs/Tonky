using UnityEngine;
using System.Collections;

public class Tonky : MonoBehaviour {

    public int _health;
    public int _maxHealth;

    public int _playerId;
    public string _playerName;

    public Vector2 _velocity;

    Rigidbody2D _rigidBody;

    Weapon _weapon;

	// Use this for initialization
	void Start () {
        _maxHealth = 100;
        _health = _maxHealth;

        _rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	    
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
