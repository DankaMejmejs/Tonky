using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
public class Game : MonoBehaviour {

    public GameObject _tonky;
    public GameObject _hud;
    public GameObject _knug;
    public GameObject[] _spawnpoints;
    public Sprite[] _playerSprites;
    public GameObject _pausemenu;
    
    private int _players;
    private bool _pause = false;

    private static Game _instance = null;

    public static Game Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.Find("Game(Clone)").GetComponent<Game>();
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

        Instantiate(_knug);
        _players = 0;
        for (int i = 0; i < 3; i++)
        {
            AddPlayer();
        }
        GameObject go = Instantiate(_hud);
        go.GetComponent<ScoreTracker>().Initiliaize(_players);
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            Pause();
        }
	}

    //Private function to add a player 
    private void AddPlayer()
    {
        GameObject go = GameObject.Instantiate(_tonky);
        go.GetComponent<Tonky>()._playerId = _players;
        //go.transform.position = _spawnpoints[_players].transform.position;
        _players++;
    }

    public void Pause()
    {
        if(!_pause)
        {
            Time.timeScale = 0f;
            GameObject.Instantiate(_pausemenu);
            _pause = true;
        }
        else
        {
            Time.timeScale = 1f;
            Destroy(GameObject.Find("Pause(Clone)"));
            _pause = false;
        }
        
    }

    public void ButtonPause()
    {
        Instance.Pause();
    }
}
