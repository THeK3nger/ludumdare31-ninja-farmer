using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{

    public Text ScoreValueLabel;

	// Use this for initialization
	void Start ()
	{
	    ScoreValueLabel.text = GameStateManager.Score.ToString();
	}

    public void LoadGame() {
        GameStateManager.Reset();
        Application.LoadLevel("MainScene");
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
