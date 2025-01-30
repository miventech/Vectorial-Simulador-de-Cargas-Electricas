using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlDeProyectos : MonoBehaviour {
	public GameObject SlotDeGuardado;
	public RectTransform CuadraPartidas;
	public float DistancePorSlot;

	// Use this for initialization
	void Start () {
		CuadraPartidas = GetComponent<RectTransform> ();
		VerificarProyectos ();
	}
	
	public void VerificarProyectos(){
		string DatosProyectos = "";
		if (PlayerPrefs.HasKey ("Proyectos")) {
			DatosProyectos = PlayerPrefs.GetString ("Proyectos");
		}
		string[] Guardados = DatosProyectos.Split ('@');
		CuadraPartidas.sizeDelta = new Vector2 (0, ((DistancePorSlot * (Guardados.Length - 1)) + DistancePorSlot));

		for (int x = 0; x < Guardados.Length; x++) {
			if (Guardados [x] != string.Empty) {
				GameObject g = Instantiate (SlotDeGuardado, transform);
				g.GetComponent<SlotDeProyecto> ().Nombre.text = Guardados [x];
				g.GetComponent<SlotDeProyecto> ().NOmbre_G = Guardados [x];
				g.GetComponent<SlotDeProyecto> ().CargarImagen ();
			}
		}
	}



}
