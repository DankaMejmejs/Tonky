using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class Game : MonoBehaviour {

    public GameObject _tonky;
    public GameObject _hud;
    public GameObject _knug;
    public GameObject _mainMenu;
    public GameObject[] _spawnpoints;
    public Sprite[] _playerSprites;
    public GameObject _pausemenu;
    public GameObject _victory;
    
    public int _players;
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
        //_players = 0;
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
        GameObject go = Instantiate(_tonky);
        go.GetComponent<Tonky>()._playerId = _players;
        //go.transform.position = _spawnpoints[_players].transform.position;
        _players++;
        Debug.Log(_players);
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

    public void Init(int players)
    {
        for (int i = 0; i < players; i++)
        {
            AddPlayer();
        }
        GameObject go = Instantiate(_hud);
        go.GetComponent<ScoreTracker>().Initiliaize(_players);
    }

    public void Exit()
    {
        Debug.Log("Exit" + Instance._players);
        Instance.Pause();
        for (int i = 0; i < Instance._players; i++)
        {
            Debug.Log("Kill tonky");
            Destroy(GameObject.Find("Tonky(Clone)"));
        }
        Instantiate(_mainMenu);
        Destroy(GameObject.Find("HUD(Clone)"));
        Destroy(GameObject.Find("Knug of the hill(Clone)"));
        Destroy(Instance.gameObject);
    }

    public void VictoryExit()
    {
        Camera.main.GetComponent<CameraController>().resetMusic();

        for (int i = 0; i < Instance._players; i++)
        {
            Destroy(GameObject.Find("Tonky(Clone)"));
        }
        Instantiate(_mainMenu);
        Destroy(GameObject.Find("HUD(Clone)"));
        Destroy(GameObject.Find("Knug of the hill(Clone)"));
        Destroy(GameObject.Find("VictoryScreen(Clone)"));
        Destroy(Instance.gameObject);
    }

    public void Victory(int Player)
    {
        GameObject go = Instantiate(_victory);
        go.GetComponentsInChildren<Text>().FirstOrDefault(x => x.name == "Number").text = (Player + 1).ToString();
    }
}
