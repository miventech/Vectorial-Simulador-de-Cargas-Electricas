using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CordenadasEsfericas : MonoBehaviour {
	public Vector3 cordenadas;
	public Transform Prueba;
	public GameObject r,fi,tita,rohTextoGameObject;
	public TextMesh Textfi,TextTita,TextRoh;
	public GameObject GOTextfi,GOTextTita,UbicacionTextTita;
	public Circulo360 angulofiCirculo, AnguloTitaCirculo;
	public  float ScalaGeneral;
	public float AnguloFi,anguloTita;
	public float factorEscalaRoh;
	public float FactorMultCono= 0.707f;
	private float Base;
	// Use this for initialization

	void Update () {
		
		AnguloFi = (Mathf.Atan2 (cordenadas.z, cordenadas.x))*Mathf.Rad2Deg;
		fi.transform.eulerAngles = new Vector3 (0, -AnguloFi, 0);
		GOTextfi.transform.position = angulofiCirculo.puntosAngulo [0] + new Vector3 (0, 0.1f, 0);
		float scalafi = Mathf.Pow (((cordenadas.z * cordenadas.z) + (cordenadas.x * cordenadas.x)), 0.5f)/2;

		rohTextoGameObject.transform.position = new Vector3 ((cordenadas.x/2) + 0.3f, cordenadas.y/2, (cordenadas.z/2) + 0.3f);

		angulofiCirculo.transform.localScale = new Vector3 (scalafi, scalafi, scalafi);



		GOTextTita.transform.position = UbicacionTextTita.transform.position;
		Textfi.text ="φ " + AnguloFi.ToString("F") + "°" ;
		TextTita.text = "θ " + (anguloTita*Mathf.Rad2Deg).ToString("F") + "°";

		if (AnguloFi < 180 && AnguloFi >= 0 ) {
			angulofiCirculo.Angulo = Mathf.RoundToInt (Mathf.Abs (AnguloFi));
		} else {
			angulofiCirculo.Angulo = Mathf.RoundToInt ( 360 - (Mathf.Abs (AnguloFi)));
		}
		AnguloTitaCirculo.Angulo = Mathf.RoundToInt (Mathf.Abs ( anguloTita * Mathf.Rad2Deg));
		anguloTita = Mathf.Acos (cordenadas.y / cordenadas.magnitude);
		Base = (cordenadas.y + cordenadas.y*0.5f)* Mathf.Tan (anguloTita);
		tita.transform.localScale = new Vector3 (Base , (cordenadas.y + cordenadas.y*0.5f) , Base);
		float rohf = cordenadas.magnitude;
		TextRoh.text = "r " + rohf.ToString ("F");
		r.transform.localScale = new Vector3 ( factorEscalaRoh * rohf, factorEscalaRoh * rohf ,  factorEscalaRoh * rohf);
	}
}
