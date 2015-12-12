using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KnugCircle : MonoBehaviour {
    public float _timer;
    private float radius;
    private float _currentTime;
    private int _currentPos;
    public int dots;
    public List<Vector2> _circlepos;

	// Use this for initialization
	void Start () {
        radius = GetComponentInParent<KnugOfTheHill>().radius;
        /*Calculate step count and circle*/
        float step = (2 * Mathf.PI) / dots;
        for (int i = 0; i < dots; i++)
        {
            _circlepos.Add(new Vector2(radius * Mathf.Cos(step * i) + transform.position.x, radius * Mathf.Sin(step * i) + transform.position.y));
        }
        _currentPos = 0;
	}
	
	// Update is called once per frame
	void Update () {
        /*Update trailrenderer*/
        _currentTime += Time.deltaTime;
        if (_currentTime >= _timer)
        {
            _currentTime = 0f;
            transform.position = _circlepos[_currentPos];
            _currentPos++;
            if (_currentPos == _circlepos.Count - 1)
            {
                _currentPos = 0;
            }
        }
	}
}
