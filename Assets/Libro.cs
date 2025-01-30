using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Libro : MonoBehaviour {
	private Animator Anim ;
	private Transform Camara;
	public float Distancia;
	public float DistanciaApertura = 7f;
	// Use this for initialization
	void Start () {
		Anim = GetComponent<Animator> ();
		Camara = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
		Distancia = Vector3.Distance (transform.position, Camara.transform.position);

		if (Distancia < DistanciaApertura) {
		
			Anim.SetBool ("Abierto", true);
		
		} else {
		
			Anim.SetBool ("Abierto", false);

		}

		
	}
}
