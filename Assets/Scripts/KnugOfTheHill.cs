using UnityEngine;
using System.Collections;


public class KnugOfTheHill : MonoBehaviour {
    public float radius;
    
    
    private CircleCollider2D _collider;
    public GameObject _owner;
    
   
	// Use this for initialization
	void Start () {
        _owner = null;

	}
	
	// Update is called once per frame
	void Update () {

        
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("HEllo");
        if(_owner == null)
        {
            if(col.gameObject.name.Contains("Tonky"))
            {
                _owner = col.gameObject;
            }
        }
    }
}
