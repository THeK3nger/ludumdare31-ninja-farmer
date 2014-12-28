using UnityEngine;
using System.Collections;

public class ChickenAI : MonoBehaviour {

    public float MoveIntervall = 1.0f;

    public float MoveSpeed = 1.0f;

    private float redShift = 0.0f;

    enum ChickenState { IDLE, HITTED }

    private ChickenState cState = ChickenState.IDLE;

    private Rigidbody2D parentBody;

    private AutoRealign align;

    void Awake() {
        parentBody = transform.parent.gameObject.GetComponent<Rigidbody2D>();
        if (parentBody == null) {
            Debug.LogError("ChickenAI parent must have a Rigidbody2D component!");
        }
        align = gameObject.GetComponent<AutoRealign>();
    }

	// Use this for initialization
	void Start () {
        StartCoroutine(FSM());
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void MakeCrazy() {
        Debug.Log("Make Crazy!");
        cState = ChickenState.HITTED;
    }

    IEnumerator FSM() {
        while (true) {
            switch (cState) {
                case ChickenState.IDLE :
                    yield return StartCoroutine(Idle());
                    break;
                case ChickenState.HITTED:
                    yield return StartCoroutine(Hitted());
                    break;
                default:
                    Debug.LogWarning("Ehm...");
                    break;
            }
        }
    }

    IEnumerator Idle() {
        // During IDLE, the chicken start moving around randomly.
        Debug.Log("Entering IDLE State");
        while (cState == ChickenState.IDLE) {
            Vector2 randomMovement = Random.insideUnitCircle;
            parentBody.velocity = randomMovement * MoveSpeed;
            yield return new WaitForSeconds(MoveIntervall);
        }
        Debug.Log("Exiting IDLE State");
    }

    IEnumerator Hitted() {
        // During HIT Animations and effects
        Debug.Log("Entering CRAZY State");
        MoveIntervall = MoveIntervall * 0.9f;
        MoveSpeed = MoveSpeed * 1.2f;
        parentBody.gameObject.renderer.material.color = Color.Lerp(parentBody.gameObject.renderer.material.color,Color.red,0.1f);
        while (cState == ChickenState.HITTED) {
            Debug.Log("CHICCHI");
            yield return new WaitForSeconds(1.0f);
            yield return StartCoroutine(align.ReAlign(parentBody));
            parentBody.transform.rotation = Quaternion.identity;
            cState = ChickenState.IDLE;
        }
        Debug.Log("Exiting CRAZY State");
    }
}
