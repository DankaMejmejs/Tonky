using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class MainMenu : MonoBehaviour {
    public GameObject _game;
    public Image[] _players;
    public bool _playerSelection = false;
    public bool[] _playersJoined = new bool[4];
    private int _playerCount;

	// Use this for initialization
	void Start () {
        _playerCount = 0;
        for (int i = 0; i < 4; i++)
            _playersJoined[i] = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if(_playerSelection)
        {
            if(Input.GetKeyDown(KeyCode.Joystick1Button2) && _playersJoined[0] == false)
            {
                _players[0].enabled = true;
                _playerCount++;
                _playersJoined[0] = true;
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button2) && _playersJoined[1] == false)
            {
                _players[1].enabled = true;
                _playerCount++;
                _playersJoined[1] = true;
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button2) && _playersJoined[2] == false)
            {
                _players[2].enabled = true;
                _playerCount++;
                _playersJoined[2] = true;
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button2) && _playersJoined[3] == false)
            {
                _players[3].enabled = true;
                _playerCount++;
                _playersJoined[3] = true;
            }

            if(Input.GetKeyDown(KeyCode.JoystickButton7) && _playerCount > 0)
            {
                Instantiate(_game).GetComponent<Game>().Init(_playerCount);
                Destroy(this.gameObject);
            }
        }
	}

    public void Play()
    {
        _playerSelection = true;
        GetComponentsInChildren<Transform>(true).FirstOrDefault(x => x.name == "PlayerSelect").gameObject.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
