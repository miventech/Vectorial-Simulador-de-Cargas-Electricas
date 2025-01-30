using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineasEnTreCargas : MonoBehaviour {
//	public ControlCargas CtrlCargas;
	public LineRenderer LR;
	// Use this for initialization
	[ContextMenu("Lineas Entre Cargas")]
	void Update(){


		if (PlayerPrefs.HasKey ("LineasEC") && PlayerPrefs.GetInt ("R_$") == 0) {
			LR.gameObject.SetActive (true);
		
			Carga[] Cargas = GameObject.FindObjectsOfType<Carga> ();

			int puntos = Cargas.Length * (Cargas.Length - 1);
			Vector3[] Ubicaciones = new Vector3[puntos];
			int matriz = 0;
			for (int x = 0; x < Cargas.Length; x++) {
				
			for (int y = (Cargas.Length-1) ; y > x  ; y--) {
				if (y > 0 && y < Cargas.Length) {
					Ubicaciones [matriz] = Cargas [x].transform.position;
					matriz++;
					Ubicaciones [matriz] = Cargas [y].transform.position;
					matriz++;
				//	Debug.Log (y);

				}
			}
		
			}
		LR.positionCount = puntos;
		LR.SetPositions (Ubicaciones);
		} else {
			LR.gameObject.SetActive (false);

		}


	}
}
