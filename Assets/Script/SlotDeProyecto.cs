using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SlotDeProyecto : MonoBehaviour {
	public Text Nombre;
	public string NOmbre_G;
	public AnalizadorDePartidas ANDPT;
	/// S///////////////////// <summary>
	/// The image cargada.
	/// </summary>/

	public RawImage ImageDePrevew;
	public string SavePath;

	///////////////////////////
	public void Start(){
		ANDPT = FindObjectOfType<AnalizadorDePartidas> ();
		GetComponent<Button> ().onClick.AddListener (PasarD);

	}
	public void PasarD(){
		ANDPT.PasarDatos (NOmbre_G);
	}


	public void CargarImagen(){
		////usr esta Como SavePath///
		//Debug.Log (Application.persistentDataPath);


		StartCoroutine (LCargarImagen ());

	}

	private IEnumerator LCargarImagen(){


		SavePath = Application.persistentDataPath +"/"+ NOmbre_G +".png";


		yield return new WaitForEndOfFrame ();


		Texture2D nueva = new Texture2D (2, 2);

		if (System.IO.File.Exists (SavePath)) {
			byte[] Bytes = System.IO.File.ReadAllBytes (SavePath);
			nueva.LoadImage (Bytes);
			ImageDePrevew.texture = nueva as Texture;
			//Capturecont++;
		}else{
			//	Debug.Log ("Nombre Enviado: " + NombreItemEnviado);
		}
	}


}
