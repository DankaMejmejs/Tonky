using UnityEngine;
using System.Collections;

public class KonfettiScript : MonoBehaviour {

	float r,g,b;


	// Use this for initialization
	void Start () {
		r = Random.Range (0.0f, 1.0f); 
		g = Random.Range (0.0f, 1.0f); 
		b = Random.Range (0.0f, 1.0f); 

		this.GetComponent<ParticleSystem>().startColor = new Color(r, g, b, 1.0f);
		this.GetComponent<ParticleSystem> ().loop = false;
	}
	
	// Update is called once per frame
	void Update () {

		r = Random.Range (0.0f, 1.0f); 
		g = Random.Range (0.0f, 1.0f); 
		b = Random.Range (0.0f, 1.0f); 
		
		this.GetComponent<ParticleSystem>().startColor = new Color(r, g, b, 1.0f);	
	}
}
