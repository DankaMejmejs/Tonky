using UnityEngine;
using System.Collections;


public class KnugOfTheHill : MonoBehaviour {
    public float radius;
    public float _scoreTime;
    private float _timer;
    
    private CircleCollider2D _collider;
    public GameObject _owner;
    
   
	// Use this for initialization
	void Start () {
        _owner = null;

	}
	
	// Update is called once per frame
	void Update () {
        _timer += Time.deltaTime;
        if(_timer >= _scoreTime)
        {
            if(_owner != null)
            {
                ScoreTracker.Instance.AddScore(1, _owner.GetComponent<Tonky>()._playerId);
            }

            _timer = 0;
        }
        
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if(_owner == null)
        {
            if(col.gameObject.name.Contains("Tonky"))
            {
                _owner = col.gameObject;
                Debug.Log("HEllo");
            }
        }
    }
}
