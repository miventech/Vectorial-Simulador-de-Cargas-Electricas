using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorDeVolumen : MonoBehaviour {
	public GameObject Tamaño;
	private bool B_Tamaño;
	private Vector3 GlobalRotation;
	private RaycastHit Rayo;
	public float VelDespl = 10;
	// Use this for initialization
	void Start () {
		
	}
	
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


			
				if (Rayo.collider.name == "Tamaño") {
					//transform.Translate (0 , VelDespl * Time.deltaTime * ( Input.GetAxis ("Mouse Y")*Mathf.Cos(Mathf.Deg2Rad*(GlobalRotation.x)) + Input.GetAxis ("Mouse X")*Mathf.Cos(Mathf.Deg2Rad*GlobalRotation.x+90)), 0)  ;
					B_Tamaño = true;
				}


			} else {
				PlayerPrefs.DeleteKey("Eje");
			}
		}
		if (Input.GetKeyUp (KeyCode.Mouse0)) {
			
			B_Tamaño = false;
			PlayerPrefs.DeleteKey("Eje");
			ActualizarDatos ();
		}

		if (B_Tamaño) {
			//Tamaño.transform.Translate (0 , VelDespl * Time.deltaTime * ( Input.GetAxis ("Mouse Y")*Mathf.Cos(Mathf.Deg2Rad*(GlobalRotation.y)) + Input.GetAxis ("Mouse X")*Mathf.Cos(Mathf.Deg2Rad*GlobalRotation.y+90))  );
			Tamaño.transform.Translate (VelDespl * Time.deltaTime * ( Input.GetAxis ("Mouse Y")*Mathf.Cos(Mathf.Deg2Rad*(GlobalRotation.y-90)) + Input.GetAxis ("Mouse X")*Mathf.Cos(Mathf.Deg2Rad*GlobalRotation.y))   , 0, 0);
			Tamaño.transform.position = new Vector3 (Tamaño.transform.position.x, Tamaño.transform.position.x, 0);
		}

	}

	public void ActualizarDatos(){
		// SupDis.DeformarMallaSecundaria ();
		// SupDis.AplicarDistribucion (DegLine.transform.localScale.x);
	}
}
