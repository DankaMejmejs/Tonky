using UnityEngine;
using System.Collections;

public class crateScript : MonoBehaviour {
	private float size = 2f;


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
}
