using UnityEngine;
using System.Collections;
using System.Globalization;

using UnityEngine.UI;

public class GUIUpdater : MonoBehaviour
{

    public Text ScoreTextLabel;

    public Text ComboTextLabel;

    public Text SpondeTextLabel;

    public Text TimeTextLabel;

    private TimerOracle time;

	// Use this for initialization
	void Start ()
	{
	    this.time = GameObject.FindObjectOfType<TimerOracle>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    ScoreTextLabel.text = GameStateManager.Score.ToString();
	    ComboTextLabel.text = GameStateManager.Combo.ToString();
	    SpondeTextLabel.text = GameStateManager.BounceMultiplier.ToString();
	    TimeTextLabel.text = this.time.MatchTime.ToString(CultureInfo.InvariantCulture);
	}
}
