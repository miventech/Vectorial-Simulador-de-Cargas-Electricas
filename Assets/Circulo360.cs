using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circulo360 : MonoBehaviour {
	public LineRenderer LR;
	[Range(0,360)]
	public int Angulo;
	public Vector3[] puntosAngulo;
	public Vector3[] PuntosAGraficar;
	// Use this for initialization
	void Start () {
		puntosAngulo = new Vector3[360];

		for (int x = 0; x < puntosAngulo.Length; x++) {
		
			puntosAngulo [x] = new Vector3 (Mathf.Cos (x * Mathf.Deg2Rad), 0, Mathf.Sin (x* Mathf.Deg2Rad));
		
		}
		LR.positionCount = 0;

//		LR.positionCount = 360;
//		LR.SetPositions (puntosAngulo);

	}
	
	// Update is called once per frame
	void Update () {
		
		PuntosAGraficar = new Vector3[Angulo];
		for (int x = 0; x < Angulo; x++) {

			PuntosAGraficar[x] = puntosAngulo [x];

		}
		LR.positionCount = Angulo;
		LR.SetPositions (PuntosAGraficar);
	}

	[ContextMenu("Graficar")]
	public void graficar(){
		puntosAngulo = new Vector3[360];

		for (int x = 0; x < puntosAngulo.Length; x++) {

			puntosAngulo [x] = new Vector3 (Mathf.Cos (x * Mathf.Deg2Rad), 0, Mathf.Sin (x* Mathf.Deg2Rad));

		}
		LR.positionCount = 0;

		PuntosAGraficar = new Vector3[Angulo];
		for (int x = 0; x < Angulo; x++) {

			PuntosAGraficar[x] = puntosAngulo [x];

		}
		LR.positionCount = Angulo;
		LR.SetPositions (PuntosAGraficar);
	}
}
