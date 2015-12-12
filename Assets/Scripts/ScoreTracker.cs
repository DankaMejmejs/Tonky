using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreTracker : MonoBehaviour {

    public int[] _scores;
    public Text[] _texts;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Initiliaize(int amountOfPlayers)
    {
        _scores = new int[amountOfPlayers];

        for(int i = 0; i < amountOfPlayers; i++)
        {
            _texts[i].enabled = true;
        }
    }
}
