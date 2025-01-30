using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CordenadasCilindricas : MonoBehaviour {
	public Vector3 cordenadas;
	public Transform Prueba;
	public GameObject Roh,fi,z;
	public GameObject RohPosText,fiPosText;
	public TextMesh RohText, fitext;

	public Circulo360 Circulo;
	public  float ScalaGeneral;
	public float AnguloFi;
	public float factorEscalaRoh;
	// Use this for initialization

	void Update () {
		Actualizar ();

	}


	[ContextMenu("Actualizar")]
	public void Actualizar(){
		////////////////////////
		///CODIGO DE PRUEBA////

		//cordenadas = Prueba.position;

		///////////////////////
		///////////////////////
		 
		//Debug.Log((180/(Mathf.PI * 2)));
		AnguloFi = (Mathf.Atan2 (cordenadas.z, cordenadas.x))*Mathf.Rad2Deg;
		fi.transform.eulerAngles = new Vector3 (0, -AnguloFi, 0);
		if (AnguloFi < 180 && AnguloFi >= 0 ) {
			Circulo.Angulo = Mathf.RoundToInt (Mathf.Abs (AnguloFi));
		} else {
			Circulo.Angulo = Mathf.RoundToInt ( 360 - (Mathf.Abs (AnguloFi)));
		}
		z.transform.position =  (new Vector3 (0,cordenadas.y, 0));
		float rohf = Mathf.Pow ((cordenadas.z * cordenadas.z + cordenadas.x * cordenadas.x), 0.5f);
		Roh.transform.localScale = new Vector3 ( factorEscalaRoh * rohf,  factorEscalaRoh * Mathf.Abs (cordenadas.y),  factorEscalaRoh * rohf);
		RohPosText.transform.position = new Vector3 (cordenadas.x/2 , cordenadas.y + 0.1f, cordenadas.z/2); 
		fiPosText.transform.position = new Vector3 ((rohf / 2) + 0.1f, 0.1f, 0);
		RohText.text = "ρ " +rohf.ToString ("F");
		fitext.text = "φ " + AnguloFi.ToString ("F") + "°";
	}
}
