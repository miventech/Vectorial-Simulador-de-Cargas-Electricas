using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DegradadoSuperficil : MonoBehaviour {
	public float FactoMultiplicativo;
	public Vector3 ScalaActual;
//	public Transform PosDegradado;
	public void Tamaño(float f){
		transform.localScale = new Vector3 (FactoMultiplicativo * f, FactoMultiplicativo * f, FactoMultiplicativo * f);
		ScalaActual = transform.localScale;
	}

}
