using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellPointLogosBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = Vector2.Lerp(gameObject.transform.position, new Vector2(9f, 9f), 5 * Time.deltaTime);

        if(transform.position.x >= 8f || transform.position.y >= 8f)
        {
            Destroy(gameObject);
        }

	}
}
