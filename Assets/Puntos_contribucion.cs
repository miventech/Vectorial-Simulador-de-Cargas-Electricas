using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntos_contribucion : MonoBehaviour {
	public GameObject Punto1 ,Punto2,Punto3;
	public Vector3[] posiciones;
	public LineRenderer LR,LR1,LR2,LR3;
	public void Start (){
		posiciones = new Vector3[4];
		for (int x = 0; x < posiciones.Length; x++) {
			posiciones [x] = new Vector3 (1000f,1000f,1000f);
		}
		LR.gameObject.SetActive (false);
		LR1.gameObject.SetActive (false);
		LR2.gameObject.SetActive (false);
		LR3.gameObject.SetActive (false);



	}
		
	public void SetViewContribucion (Vector3 posicion, Vector3 PosInicio){

		for (int x = posiciones.Length - 1; x >= 0; x--) {
			if (x != 0) {
				posiciones [x] = posiciones [x - 1];
			}		
			if (x == 0) {
				posiciones [0] = posicion;
			}
		}

		transform.position = posiciones [0];
		Punto1.transform.position = posiciones [1];
		Punto2.transform.position = posiciones [2];
		Punto3.transform.position = posiciones [3];

		Setline (posiciones [0], PosInicio, LR);
		Setline (posiciones [1], PosInicio, LR1);
		Setline (posiciones [2], PosInicio, LR2);
		Setline (posiciones [3], PosInicio, LR3);

	}

	public void Setline (Vector3 Pos1 ,Vector3 Pos2 , LineRenderer lr){


		LR.gameObject.SetActive (true);
		LR1.gameObject.SetActive (true);
		LR2.gameObject.SetActive (true);
		LR3.gameObject.SetActive (true);
		Vector3 direccion = Pos2 - Pos1;
		Vector3 SeparFlecha = new Vector3 (1f, 1f, 1f);
		Vector3 Separ = new Vector3 (0.2f, 0.2f, 0.2f);
		Vector3 Separacion = new Vector3 ( direccion.normalized.x * Separ.x , direccion.normalized.y * Separ.y , direccion.normalized.z * Separ.z);
		Vector3 PuntoFlecha = new Vector3 ( direccion.normalized.x * SeparFlecha.x , direccion.normalized.y * SeparFlecha.y , direccion.normalized.z * SeparFlecha.z);
	//	Vector3 Puntoin = new Vector3 (direccion.normalized.x * SeparFlecha.x , direccion.normalized

		lr.positionCount = 3;
		lr.SetPosition (0, Pos1 + Separacion);
		lr.SetPosition (1, Pos2 - PuntoFlecha);
		lr.SetPosition (2, Pos2 - Separacion);

	}

	public void FinVisualizacion(){

		for (int x = 0; x < posiciones.Length; x++) {
			posiciones [x] = new Vector3(1000f,1000f,1000f);
		}

		Vector3[] v = new Vector3[0];
		LR.SetPositions (v);
		LR.positionCount = 0;
		LR.gameObject.SetActive (false);
		LR1.gameObject.SetActive (false);
		LR2.gameObject.SetActive (false);
		LR3.gameObject.SetActive (false);
		transform.position = posiciones [0];
		Punto1.transform.position = posiciones [1];
		Punto2.transform.position = posiciones [2];
		Punto3.transform.position = posiciones [3];
	}






}
