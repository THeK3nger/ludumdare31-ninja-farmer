using UnityEngine;
using System.Collections;

public class GameStateManager : MonoBehaviour {

    // How Many Bounces Before
    static public int BounceMultiplier = 1;

    static public int Combo = 1;

    static public int OnFireStreak = 0;

    static public int Score = 0;

    static public int  AddScore(int score) {
        int addScore = (score * BounceMultiplier * Combo) + 100 * OnFireStreak;
        GameStateManager.Score += addScore;
        return addScore;
    }

    static public void ReseBounceMultiplier() {
        BounceMultiplier = 1;
    }

    static public void Reset()
    {
        BounceMultiplier = 1;
        Combo = 1;
        OnFireStreak = 0;
        Score = 0;
    }
}
