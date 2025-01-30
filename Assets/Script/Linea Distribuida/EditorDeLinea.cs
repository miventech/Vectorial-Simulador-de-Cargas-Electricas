using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorDeLinea : MonoBehaviour {
	public GameObject P_inicial;
	public GameObject P1, P2, P_Final;
	private bool MoveX1,MoveX2,MoveY1,MoveY2,MFinal,MInicial;
	private Vector3 GlobalRotation;
	private RaycastHit Rayo;
	public float VelDespl = 10;

	// Update is called once per frame
	void Update () {


		Ray R = Camera.main.ScreenPointToRay (Input.mousePosition);
		GlobalRotation = Camera.main.transform.eulerAngles;
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			/// pregunta si el boton derecho del mouse es presionado
			if (Physics.Raycast (R, out Rayo, 500f)) { // este if funciona como el rayo que se lanza y obtiene datos de quien coliciones ejemplo ( (camara) <| -------(rayo)--------- * (datos))

				if (Rayo.collider.CompareTag ("Eje")) {
					PlayerPrefs.SetString ("Eje", "yeah");
				} else {
					PlayerPrefs.DeleteKey("Eje");
				}


				if (Rayo.collider.name == "X") {
					//transform.Translate (VelDespl * Time.deltaTime * ( Input.GetAxis ("Mouse Y")*Mathf.Cos(Mathf.Deg2Rad*(GlobalRotation.y-90)) + Input.GetAxis ("Mouse X")*Mathf.Cos(Mathf.Deg2Rad*GlobalRotation.y))   , 0, 0);
					MoveX1 = true;
				}
				if (Rayo.collider.name == "Y") {
					//transform.Translate (0 , 0, VelDespl * Time.deltaTime * ( Input.GetAxis ("Mouse Y")*Mathf.Cos(Mathf.Deg2Rad*(GlobalRotation.y)) + Input.GetAxis ("Mouse X")*Mathf.Cos(Mathf.Deg2Rad*GlobalRotation.y+90))  );
					MoveY1 = true;
				}
				if (Rayo.collider.name == "X2") {
					//transform.Translate (VelDespl * Time.deltaTime * ( Input.GetAxis ("Mouse Y")*Mathf.Cos(Mathf.Deg2Rad*(GlobalRotation.y-90)) + Input.GetAxis ("Mouse X")*Mathf.Cos(Mathf.Deg2Rad*GlobalRotation.y))   , 0, 0);
					MoveX2 = true;
				}
				if (Rayo.collider.name == "Y2") {
					//transform.Translate (0 , 0, VelDespl * Time.deltaTime * ( Input.GetAxis ("Mouse Y")*Mathf.Cos(Mathf.Deg2Rad*(GlobalRotation.y)) + Input.GetAxis ("Mouse X")*Mathf.Cos(Mathf.Deg2Rad*GlobalRotation.y+90))  );
					MoveY2 = true;
				}
				if (Rayo.collider.name == "Final") {
					//transform.Translate (0 , VelDespl * Time.deltaTime * ( Input.GetAxis ("Mouse Y")*Mathf.Cos(Mathf.Deg2Rad*(GlobalRotation.x)) + Input.GetAxis ("Mouse X")*Mathf.Cos(Mathf.Deg2Rad*GlobalRotation.x+90)), 0)  ;
					MFinal = true;
				}
				if (Rayo.collider.name == "Inicio") {
					//transform.Translate (0 , VelDespl * Time.deltaTime * ( Input.GetAxis ("Mouse Y")*Mathf.Cos(Mathf.Deg2Rad*(GlobalRotation.x)) + Input.GetAxis ("Mouse X")*Mathf.Cos(Mathf.Deg2Rad*GlobalRotation.x+90)), 0)  ;
					MInicial = true;
				}

			} else {
				PlayerPrefs.DeleteKey("Eje");
			}
		}
		if (Input.GetKeyUp (KeyCode.Mouse0)) {
			MoveX1 = false;
			MoveY1 = false;
			MoveX2 = false;
			MoveY2 = false;
			MFinal = false;
			MInicial = false;
			PlayerPrefs.DeleteKey("Eje");
		}

	//	if (MoveY1) {
	//		P1.transform.Translate (0 , 0, VelDespl * Time.deltaTime * ( Input.GetAxis ("Mouse Y")*Mathf.Cos(Mathf.Deg2Rad*(GlobalRotation.y)) + Input.GetAxis ("Mouse X")*Mathf.Cos(Mathf.Deg2Rad*GlobalRotation.y+90))  );
	//	}
		if (MoveX1) {
			P1.transform.Translate (VelDespl * Time.deltaTime * ( Input.GetAxis ("Mouse Y")*Mathf.Cos(Mathf.Deg2Rad*(GlobalRotation.y-90)) + Input.GetAxis ("Mouse X")*Mathf.Cos(Mathf.Deg2Rad*GlobalRotation.y))   , 0, 0);
		}
		if (MoveY1) {
			P1.transform.Translate (0 , VelDespl * Time.deltaTime * ( Input.GetAxis ("Mouse Y")*Mathf.Cos(Mathf.Deg2Rad*(GlobalRotation.x)) + Input.GetAxis ("Mouse X")*Mathf.Cos(Mathf.Deg2Rad*GlobalRotation.x+90)), 0)  ;
		}
		if (MoveX2) {
			P2.transform.Translate (VelDespl * Time.deltaTime * ( Input.GetAxis ("Mouse Y")*Mathf.Cos(Mathf.Deg2Rad*(GlobalRotation.y-90)) + Input.GetAxis ("Mouse X")*Mathf.Cos(Mathf.Deg2Rad*GlobalRotation.y))   , 0, 0);
		}
		if (MoveY2) {
			P2.transform.Translate (0 , VelDespl * Time.deltaTime * ( Input.GetAxis ("Mouse Y")*Mathf.Cos(Mathf.Deg2Rad*(GlobalRotation.x)) + Input.GetAxis ("Mouse X")*Mathf.Cos(Mathf.Deg2Rad*GlobalRotation.x+90)), 0)  ;
		}

		if (MFinal) {
			P_Final.transform.Translate (0 , 0, VelDespl * Time.deltaTime * ( Input.GetAxis ("Mouse Y")*Mathf.Cos(Mathf.Deg2Rad*(GlobalRotation.y)) + Input.GetAxis ("Mouse X")*Mathf.Cos(Mathf.Deg2Rad*GlobalRotation.y+90))  );
			if (P_Final.transform.position.z < 0.1f) {
				P_Final.transform.position = new Vector3 (P_Final.transform.position.x, P_Final.transform.position.y, 0.2f);
			}
		}
		if (MInicial) {
			P_inicial.transform.Translate (0 , 0, VelDespl * Time.deltaTime * ( Input.GetAxis ("Mouse Y")*Mathf.Cos(Mathf.Deg2Rad*(GlobalRotation.y)) + Input.GetAxis ("Mouse X")*Mathf.Cos(Mathf.Deg2Rad*GlobalRotation.y+90))  );
			if (P_inicial.transform.position.z > -0.1f) {
				P_inicial.transform.position = new Vector3 (P_Final.transform.position.x, P_Final.transform.position.y, -0.2f);
			}
		}

	}
}
