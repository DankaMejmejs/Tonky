using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    public GameObject _tonky;
    public Sprite[] _playerSprites;
    private int _players;

    private static Game _instance = null;

    public static Game Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.Find("Game").GetComponent<Game>();
                return _instance;
            }
            else 
            {
                return _instance;
            }
        }
    }

	// Use this for initialization
	void Start () {
        _players = 0;
        for (int i = 0; i < 3; i++)
        {
            GameObject go = Instantiate(_tonky);
            go.GetComponent<Tonky>()._playerId = _players;
            _players++;
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
