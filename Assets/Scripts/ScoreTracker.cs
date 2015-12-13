using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreTracker : MonoBehaviour {

    public int[] _scores;
    public Text[] _texts;
    public int _winAmount;

    private static ScoreTracker _instance = null;

    public static ScoreTracker Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.Find("HUD(Clone)").GetComponent<ScoreTracker>();
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
	
	}
	
	// Update is called once per frame
	void Update () {
	    for(int i = 0; i < _scores.Length; i++)
        {
            _texts[i].text = _scores[i].ToString();
        }
	}

    public void Initiliaize(int amountOfPlayers)
    {
        _scores = new int[amountOfPlayers];

        for(int i = 0; i < amountOfPlayers; i++)
        {
            _texts[i].gameObject.SetActive(true);
            _texts[i].text = _scores[i].ToString();
        }
    }

    public void AddScore(int amount, int player)
    {
        _scores[player] += amount;
        if(_scores[player] > _winAmount)
        {
            Game.Instance.Victory(player);
        }
    }


}
