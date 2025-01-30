using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trans_ : MonoBehaviour {
	public Transform Camara;
	public float distancia;
	public SpriteRenderer SR;
	// Use this for initialization
	void Start () {
		SR = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		distancia = Vector3.Distance (transform.position, Camara.transform.position);
		if (distancia <= 0.8f) {
			Color C = new Color (SR.color.r, SR.color.g, SR.color.b, 0);
			SR.color = Color.Lerp (SR.color, C, 4.5f * Time.deltaTime);
		} else {
			SR.color = Color.Lerp (SR.color, new Color (SR.color.r, SR.color.g, SR.color.b, 1f), 4.5f * Time.deltaTime);
		}
	}
}
