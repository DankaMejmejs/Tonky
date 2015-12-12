using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
    public GameObject _game;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Play()
    {
        Instantiate(_game);
        Destroy(this.gameObject);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
