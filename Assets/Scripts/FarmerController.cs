using System;

using UnityEngine;
using System.Collections;

public class FarmerController : MonoBehaviour
{

    public event Action FarmerShotWhileMoving;
    public event Action FarmerStopped;
    public event Action FarmerShoted; 

    public GameObject ArrowPrefab;

    public float SpeedMultiplier;

    private GameObject arrowInstance;
    

    private bool clicked;

    private Vector3 shotDirection;

    private bool moving;

    private AutoRealign align;

    void Awake()
    {
        align = gameObject.GetComponent<AutoRealign>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (clicked && Input.GetMouseButton(0)) {
            Ray ray = Camera.mainCamera.ScreenPointToRay(Input.mousePosition);
            Vector3 endPosition = ray.direction*10;
            shotDirection = transform.position-ray.origin;
            shotDirection = new Vector3(shotDirection.x, shotDirection.y, 0); 
            arrowInstance.transform.position = transform.position;
            // Compute Rotation to the shot direction!
            float angle = Mathf.Atan2(shotDirection.y, shotDirection.x) * Mathf.Rad2Deg;
            arrowInstance.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            // Compute Scale
            arrowInstance.transform.localScale = new Vector3(shotDirection.magnitude*0.5f, 0.1f, 1.0f);
            Debug.DrawLine(transform.position, ray.origin);
        }

        if (clicked && Input.GetMouseButtonUp(0)) {
            if (FarmerShoted != null)
            {
                FarmerShoted();
            }

            // Reset Bounce Multiplier
            GameStateManager.ReseBounceMultiplier();

            Debug.DrawLine(transform.position, transform.position+shotDirection*10,Color.red,2.0f);

            // Check On Fire Streak
            if (moving) {
                if (FarmerShotWhileMoving != null)
                {
                    FarmerShotWhileMoving();
                }
            }
            rigidbody2D.velocity = shotDirection*SpeedMultiplier;
            clicked = false;
            moving = true;
            Destroy(arrowInstance);
        }

        if (moving && rigidbody2D.velocity.magnitude < 0.2) {
            if (FarmerStopped != null)
            {
                FarmerStopped();
            }
            Debug.Log("Multiplier Reset. Was: " + GameStateManager.BounceMultiplier);
            GameStateManager.ReseBounceMultiplier();
            GameStateManager.OnFireStreak = 0;
            moving = false;
            StartCoroutine(align.ReAlign(gameObject.GetComponent<Rigidbody2D>()));
        }


	}

    void OnMouseDown() {
        clicked = true;
        arrowInstance = Instantiate(ArrowPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
    }
}
