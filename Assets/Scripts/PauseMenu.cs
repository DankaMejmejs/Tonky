using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Resume()
    {
        Game.Instance.Pause();
    }

    public void Exit()
    {
        Game.Instance.Exit();
    }
}
