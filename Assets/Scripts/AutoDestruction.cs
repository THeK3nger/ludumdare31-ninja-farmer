using UnityEngine;
using System.Collections;

public class AutoDestruction : MonoBehaviour
{

    public float DestructionDelay = 2.0f;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, DestructionDelay);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
