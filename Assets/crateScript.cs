using UnityEngine;
using System.Collections;

public class crateScript : MonoBehaviour {
	private float size = 2f;

    public GameObject explosionPrefab;

    public float _damageFactor = 2;
    public float _explosionDamage = 5;

	// Use this for initialization
	void Start () {

		GetComponent<BoxCollider2D> ().enabled = false;
		Vector3 newScale;
		newScale.z = 1;
		newScale.x = size;
		newScale.y = size;

		transform.localScale = newScale;
	}
	
	// Update is called once per frame
	void Update () {
		if (size > 1) {
			size -= Time.deltaTime;
			if(size <= 1)
			{
				GetComponent<BoxCollider2D> ().enabled = true;
			}
			Vector3 newSize;
			newSize.z = 1;
			newSize.x = size;
			newSize.y = size;

			transform.localScale = newSize;
		}
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        FMOD.Studio.EventInstance e = FMOD_StudioSystem.instance.GetEvent("event:/Crate_Impact");
        e.setPitch(Random.Range(0.75f, 1.25f));
        e.start();

        //FMOD_StudioSystem.instance.PlayOneShot("event:/Crate_Impact", Vector3.zero);

        Tonky tonky = collision.gameObject.GetComponent<Tonky>();

        if (tonky != null)
        {
            GameObject g = Instantiate(explosionPrefab);
            g.transform.position = transform.position;
            tonky.Damage(Mathf.FloorToInt(Mathf.FloorToInt(GetComponent<Rigidbody2D>().velocity.magnitude) * _damageFactor), null);
            tonky.Damage(Mathf.FloorToInt(_explosionDamage), null);
            Destroy(gameObject);
        }
    }
}
