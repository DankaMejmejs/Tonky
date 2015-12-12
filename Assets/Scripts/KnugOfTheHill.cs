using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class KnugOfTheHill : MonoBehaviour {
    public float radius;
    public float _scoreTime;
    private float _timer;
    
    private CircleCollider2D _collider;
    public GameObject _owner;
    public List<GameObject> _inside;
    public GameObject _crown;
   
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

        if (col.gameObject.name.Contains("Tonky"))
        {
            if (_owner == null)
            {
                _owner = col.gameObject;
                GameObject go = Instantiate(_crown, new Vector3(), _owner.transform.rotation) as GameObject;
                Debug.Log(go.transform.position + " " + _owner.transform.up);
                go.transform.parent = _owner.transform;

                go.transform.localPosition = new Vector3(0, 1, 0);
                Debug.Log(go.transform.position);

            }
            _inside.Add(col.gameObject);
        }
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("Tonky"))
        {
            _inside.Remove(col.gameObject);
            if (col.gameObject == _owner)
            {
                Destroy(_owner.GetComponentsInChildren<Transform>().FirstOrDefault(x => x.name.Contains("KnugCrown")).gameObject);
                if (_inside.Count > 1)
                {
                    _owner = _inside[Random.Range(0, _inside.Count + 1)];
                }
                else
                {
                    _owner = null;
                }
                    
            }
        }
        
       
    }
}
