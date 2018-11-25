using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavetextScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        StartCoroutine(DestroyYourself());

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator DestroyYourself()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

}
