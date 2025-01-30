using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorDeSuperficie : MonoBehaviour {
	public SuperficieDistribuida SupDis;
	public GameObject Tamaño;
	public GameObject Radio, Amplitud;
	private bool B_Radio,B_AmplitudX ,B_AmplitudY,B_AmplitudZ ,B_Tamaño;
	private Vector3 GlobalRotation;
	private RaycastHit Rayo;
	public DegradadoSuperficil DegLine;
	public float VelDespl = 10;
	// Update is called once per frame
	void Start(){
		DegLine.transform.localPosition = new Vector3 (-Amplitud.transform.localPosition.z ,Amplitud.transform.localPosition.x , -2);

	}

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
					B_AmplitudX = true;
				}
				if (Rayo.collider.name == "Y") {
					//transform.Translate (0 , 0, VelDespl * Time.deltaTime * ( Input.GetAxis ("Mouse Y")*Mathf.Cos(Mathf.Deg2Rad*(GlobalRotation.y)) + Input.GetAxis ("Mouse X")*Mathf.Cos(Mathf.Deg2Rad*GlobalRotation.y+90))  );
					B_AmplitudY = true;
				}
				if (Rayo.collider.name == "Z") {
					//transform.Translate (VelDespl * Time.deltaTime * ( Input.GetAxis ("Mouse Y")*Mathf.Cos(Mathf.Deg2Rad*(GlobalRotation.y-90)) + Input.GetAxis ("Mouse X")*Mathf.Cos(Mathf.Deg2Rad*GlobalRotation.y))   , 0, 0);
					B_AmplitudZ = true;
				}
				if (Rayo.collider.name == "Radio") {
					//transform.Translate (0 , 0, VelDespl * Time.deltaTime * ( Input.GetAxis ("Mouse Y")*Mathf.Cos(Mathf.Deg2Rad*(GlobalRotation.y)) + Input.GetAxis ("Mouse X")*Mathf.Cos(Mathf.Deg2Rad*GlobalRotation.y+90))  );
					B_Radio = true;
				}
				if (Rayo.collider.name == "Tamaño") {
					//transform.Translate (0 , VelDespl * Time.deltaTime * ( Input.GetAxis ("Mouse Y")*Mathf.Cos(Mathf.Deg2Rad*(GlobalRotation.x)) + Input.GetAxis ("Mouse X")*Mathf.Cos(Mathf.Deg2Rad*GlobalRotation.x+90)), 0)  ;
					B_Tamaño = true;
				}


			} else {
				PlayerPrefs.DeleteKey("Eje");
			}
		}
		if (Input.GetKeyUp (KeyCode.Mouse0) && (B_Radio || B_Tamaño || B_AmplitudZ || B_AmplitudY || B_AmplitudX) ) {
			PlayerPrefs.DeleteKey("Eje");
			ActualizarDatos ();
			B_Radio = false;
			B_AmplitudX = false;
			B_AmplitudY = false;
			B_AmplitudZ = false;
			B_Tamaño = false;

		}
		//	if (MoveY1) {
		//		P1.transform.Translate (0 , 0, VelDespl * Time.deltaTime * ( Input.GetAxis ("Mouse Y")*Mathf.Cos(Mathf.Deg2Rad*(GlobalRotation.y)) + Input.GetAxis ("Mouse X")*Mathf.Cos(Mathf.Deg2Rad*GlobalRotation.y+90))  );
		//	}
		if (B_AmplitudX) {
			Amplitud.transform.Translate (VelDespl * Time.deltaTime * ( Input.GetAxis ("Mouse Y")*Mathf.Cos(Mathf.Deg2Rad*(GlobalRotation.y-90)) + Input.GetAxis ("Mouse X")*Mathf.Cos(Mathf.Deg2Rad*GlobalRotation.y))   , 0, 0);
		}
		if (B_AmplitudY) {
			Amplitud.transform.Translate (0 , 0, VelDespl * Time.deltaTime * ( Input.GetAxis ("Mouse Y")*Mathf.Cos(Mathf.Deg2Rad*(GlobalRotation.y)) + Input.GetAxis ("Mouse X")*Mathf.Cos(Mathf.Deg2Rad*GlobalRotation.y+90))  );

		}
		if (B_AmplitudZ) {
			Amplitud.transform.Translate (0 , VelDespl * Time.deltaTime * ( Input.GetAxis ("Mouse Y")*Mathf.Cos(Mathf.Deg2Rad*(GlobalRotation.x)) + Input.GetAxis ("Mouse X")*Mathf.Cos(Mathf.Deg2Rad*GlobalRotation.x+90)), 0)  ;

		}
		if (B_Radio) {
			Radio.transform.Translate (0, -VelDespl * Time.deltaTime * ( Input.GetAxis ("Mouse Y")*Mathf.Cos(Mathf.Deg2Rad*(GlobalRotation.y)) + Input.GetAxis ("Mouse X")*Mathf.Cos(Mathf.Deg2Rad*GlobalRotation.y+90)), 0  );

			//P2.transform.Translate (0 , VelDespl * Time.deltaTime * ( Input.GetAxis ("Mouse Y")*Mathf.Cos(Mathf.Deg2Rad*(GlobalRotation.x)) + Input.GetAxis ("Mouse X")*Mathf.Cos(Mathf.Deg2Rad*GlobalRotation.x+90)), 0)  ;
		}

		if (B_Tamaño) {
			//Tamaño.transform.Translate (0 , VelDespl * Time.deltaTime * ( Input.GetAxis ("Mouse Y")*Mathf.Cos(Mathf.Deg2Rad*(GlobalRotation.y)) + Input.GetAxis ("Mouse X")*Mathf.Cos(Mathf.Deg2Rad*GlobalRotation.y+90))  );
			Tamaño.transform.Translate (VelDespl * Time.deltaTime * ( Input.GetAxis ("Mouse Y")*Mathf.Cos(Mathf.Deg2Rad*(GlobalRotation.y-90)) + Input.GetAxis ("Mouse X")*Mathf.Cos(Mathf.Deg2Rad*GlobalRotation.y))   , 0, 0);
		}
		if (B_Tamaño || B_Radio || B_AmplitudX || B_AmplitudY || B_AmplitudZ) {
			SupDis.DeformarMalla (SupDis.PlanoHigh);
			SupDis.transform.localScale = new Vector3 (SupDis.Tamaño.localPosition.x, SupDis.Tamaño.localPosition.x, SupDis.Tamaño.localPosition.x);

		}

		DegLine.transform.localPosition = new Vector3 (-Amplitud.transform.localPosition.z ,Amplitud.transform.localPosition.x , -2);

	}

	public void ActualizarDatos(){
		SupDis.DeformarMallaSecundaria ();
		SupDis.AplicarDistribucion (DegLine.transform.localScale.x);
	}
}
