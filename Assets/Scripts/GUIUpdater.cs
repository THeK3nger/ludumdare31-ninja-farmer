using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class GUIUpdater : MonoBehaviour
{

    public Text ScoreTextLabel;

    public Text ComboTextLabel;

    public Text SpondeTextLabel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    ScoreTextLabel.text = GameStateManager.Score.ToString();
	    ComboTextLabel.text = GameStateManager.Combo.ToString();
	    SpondeTextLabel.text = GameStateManager.BounceMultiplier.ToString();
	}
}
