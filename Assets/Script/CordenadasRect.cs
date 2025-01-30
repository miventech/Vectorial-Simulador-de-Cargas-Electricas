using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CordenadasRect : MonoBehaviour {
	public Vector3 cordenadas;
	public Transform Prueba;
	public GameObject x,y,z;
	public  float ScalaGeneral;
	public float ValorMultEscala = 0.5f;

	void Update () {
		
		x.transform.position =  (new Vector3 (cordenadas.x, 0, 0));
		y.transform.position =  (new Vector3 (0,cordenadas.y, 0));
		z.transform.position =  (new Vector3 (0,0 ,cordenadas.z));
		ScalaGeneral = ValorMultEscala * cordenadas.magnitude;
		x.transform.localScale = new Vector3 ( ScalaGeneral , 0.0001f ,ScalaGeneral);
		z.transform.localScale =  new Vector3 ( ScalaGeneral , 0.0001f ,ScalaGeneral);
		y.transform.localScale = new Vector3 ( ScalaGeneral , 0.0001f ,ScalaGeneral);
	}
}
