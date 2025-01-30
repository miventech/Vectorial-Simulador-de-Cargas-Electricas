using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraficadorDeLineas : MonoBehaviour {
	public LineRenderer LR1 , LR2;

	
	// Update is called once per frame
	void Update () {
	
		LR1.positionCount = 3;
		LR2.positionCount = 4;

		LR1.SetPosition (0, new Vector3 (transform.position.x, 0, 0));
		LR1.SetPosition (1, new Vector3 (transform.position.x, 0, transform.position.z));
		LR1.SetPosition (2, new Vector3 (0, 0, transform.position.z));

		LR2.SetPosition (0, new Vector3 (0, 0, 0));
		LR2.SetPosition (1, new Vector3 (transform.position.x, 0, transform.position.z));
		LR2.SetPosition (2,new Vector3 (transform.position.x, transform.position.y, transform.position.z));
		LR2.SetPosition (3, new Vector3 (0, transform.position.y, 0));

	}
}
