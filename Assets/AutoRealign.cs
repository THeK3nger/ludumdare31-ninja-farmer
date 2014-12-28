using UnityEngine;
using System.Collections;

public class AutoRealign : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public IEnumerator ReAlign(Rigidbody2D parentBody)
    {
        for (var i = 0; i < 60; i++) {
            parentBody.transform.rotation = Quaternion.Lerp(parentBody.transform.rotation, Quaternion.identity, Time.deltaTime * 10.0f);

            yield return new WaitForEndOfFrame();
        }
    }
}
