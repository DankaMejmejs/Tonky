using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArmadilloScript : MonoBehaviour {

	public float _moveSpeed = 0f;
	public Vector3 _dest;
	public float _dir;
	public Animator _animation;
	private float _maxX = 7.7f;
	private float _minX = -7.7f;
	private float _maxY = 3.5f;
	private float _minY = -3.5f;

	// Use this for initialization
	void Start () {
		_animation = GetComponent<Animator> ();
		randomDest ();
	}
	
	// Update is called once per frame
	void Update () {
		while (Vector3.Distance (_dest, transform.position) < 0.5f) {
			randomDest ();
		}
		move ();

		if (GetComponent<Rigidbody2D> ().velocity.magnitude > 2) {
			_animation.SetBool ("Rolling", true);	
			_animation.SetBool ("Walking", false);
		} else {
			_animation.SetBool ("Rolling", false);	
			_animation.SetBool ("Walking", true);
		}
	}

	void randomDest()
	{
		_dest.x = Random.Range (_minX, _maxX);
		_dest.y = Random.Range (_minY, _maxY);

		_dir = Vector3.Angle (transform.position, _dest);
		//transform.rotation = Quaternion.Euler(new Vector3(0,0,_dir + 90));
		GetComponent<Rigidbody2D>().AddTorque(Random.Range(-100, 100));
	}

	void move(){
		GetComponent<Rigidbody2D>().AddForce(transform.up * (_moveSpeed * Time.deltaTime));
	}

	void OnCollisionEnter2D(Collision2D collision) {
		GetComponent<Rigidbody2D>().AddTorque(Random.Range(-100, 100));
	}

}
