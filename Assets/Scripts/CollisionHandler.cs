using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class CollisionHandler : MonoBehaviour
{

    public GameObject ScorePop;
    public GameObject OnFireObject;

    private bool wasMoving = false;
    private int hittedDuringLastShot = 0;

    void Awake()
    {
        var fc = GetComponent<FarmerController>();
        fc.FarmerShotWhileMoving += FarmerWasMoving;
        fc.FarmerShoted += FarmerShoted;
        fc.FarmerStopped += FarmerStopped;
    }

    void FarmerWasMoving()
    {
        wasMoving = true;
    }

    void FarmerShoted()
    {
        GameStateManager.Combo = 1;
    }

    void FarmerStopped()
    {
        GameStateManager.Combo = 1;
    }

    void OnCollisionEnter2D(Collision2D other) {
        var otherObject = other.gameObject;
        if (otherObject.tag == "Chicken") {
            GameStateManager.Combo += 1;
            if (wasMoving)
            {
                Debug.Log("ON FIRE!");
                StaticUtility.SpawnRandomlyInCircle(OnFireObject, new Vector2(0, 0), 0.8f);
                GameStateManager.OnFireStreak += 1;
                wasMoving = false;
            }
            Debug.Log("CHICKEN COLLISION");
            var cai = otherObject.GetComponentInChildren<ChickenAI>();
            int score = GameStateManager.AddScore(100);
            var sp = Instantiate(ScorePop, cai.transform.position,Quaternion.identity) as GameObject;
            sp.GetComponentInChildren<Text>().text = score.ToString();
            //sp.transform.parent = cai.transform;
            cai.MakeCrazy();
        }
        if (otherObject.tag == "Boundaries") {
            Debug.Log("SPONDA BONUS");
            GameStateManager.BounceMultiplier += 1;
        }
    }
}
