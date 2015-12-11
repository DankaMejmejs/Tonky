using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    public GameObject _tonky;
    private int _players;
	// Use this for initialization
	void Start () {
        _players = 0;
        GameObject go = Instantiate(_tonky);
        go.GetComponent<Tonky>()._playerId = _players;
        _players++;
       
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
