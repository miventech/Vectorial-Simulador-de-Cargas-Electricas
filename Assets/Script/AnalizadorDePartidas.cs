using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnalizadorDePartidas : MonoBehaviour {
	private string LoadName;
	public Text NombreText, DescripcionText;
	public Button Cargar,Bton_Eliminar;
	// Use this for initialization
	void Start () {
		Cargar.onClick.AddListener (IniciarCarga);
		Bton_Eliminar.onClick.AddListener (eliminar);
	}

	public void PasarDatos(string NombreDeGuardado){
		LoadName = NombreDeGuardado;


		if (PlayerPrefs.HasKey (LoadName)) {
			DescripcionText.text = PlayerPrefs.GetString (LoadName + "Desc");
			if (DescripcionText.text == string.Empty) {
				DescripcionText.text = "Este archivo de guardado no posee descripción. \nPuedes colocarla en el menú de guardado \nEstando dentro de una simulación";
			}
			NombreText.text = LoadName;
		}
		Cargar.gameObject.SetActive (true);
		Bton_Eliminar.gameObject.SetActive (true);

	}

	public void IniciarCarga(){
		PlayerPrefs.SetString ("CargaArchivo", LoadName);

		UnityEngine.SceneManagement.SceneManager.LoadScene (1);
	}
	public void eliminar(){
	
		string DatosProyectos = "";
		if (PlayerPrefs.HasKey ("Proyectos")) {
			DatosProyectos = PlayerPrefs.GetString ("Proyectos");
		}
		string NuevosDatos = "";
		string[] Guardados = DatosProyectos.Split ('@');

		for (int x = 0; x < Guardados.Length; x++) {
			if (Guardados [x] != string.Empty) { 
				if (Guardados [x] != LoadName) {
					NuevosDatos += Guardados [x] + "@"; 
				}
			}
		}
		PlayerPrefs.SetString ("Proyectos", NuevosDatos);
		SlotDeProyecto[] S = FindObjectsOfType<SlotDeProyecto> ();
		for (int x = 0; x < S.Length; x++) {
		
			Destroy (S [x].gameObject);
		
		}

		ControlDeProyectos CTP = FindObjectOfType<ControlDeProyectos> ();
		CTP.VerificarProyectos();
	}


	public void NuevoProyecto(){
		PlayerPrefs.DeleteKey ("CargaArchivo");
		UnityEngine.SceneManagement.SceneManager.LoadScene (1);
	}

	public void AbrirExposicion (){
		PlayerPrefs.DeleteKey ("CargaArchivo");
		PlayerPrefs.DeleteKey ("Expo");
		UnityEngine.SceneManagement.SceneManager.LoadScene (2);
	}
	public void AbrirTeoria(){
		PlayerPrefs.DeleteKey ("Expo");
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Teoria");
	}
	public void SalirDeLaAplicacion(){
		Application.Quit ();
	}
}
