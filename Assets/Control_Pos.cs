using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control_Pos : MonoBehaviour {

	public Puntos[] TodosLosPuntos;
	private Transform MirarA, IrA;
	public bool GuardarPos = true;
	public float tiempo;
	[Space(30f)]
	[Header("Otros Datos")]
	public int PuntoActual;
	public GameObject Camara;
	public GameObject Mirador;
	public float suavizadoCaminar,SuavizadoMirar;
	void Start(){
		if (PlayerPrefs.HasKey ("Expo") && GuardarPos) {
			PuntoActual = PlayerPrefs.GetInt ("Expo");
		} else {
			PuntoActual = 0;
		}
		Actualizar ();
		suavizadoCaminar = 2.5f;
		SuavizadoMirar = 2.0f;

	}
	public void IrAUbicacion (int indice){
		PuntoActual = indice;
		Actualizar ();
	}


	void Update(){


		Camara.transform.position = Vector3.Slerp (Camara.transform.position, TodosLosPuntos [PuntoActual].IrA.position, suavizadoCaminar*Time.deltaTime);
		Mirador.transform.LookAt (TodosLosPuntos [PuntoActual].MirarA.position);
		Camara.transform.rotation = Quaternion.Slerp (Camara.transform.rotation, Mirador.transform.rotation, SuavizadoMirar*Time.deltaTime);

		if (Input.touchCount > 0) {
			tiempo -= Time.deltaTime;
			if (Input.GetTouch (0).tapCount >= 2 && tiempo < 0 ) {
				Siguiente ();
				tiempo = 0.5f;
			}
		}


		if (Input.GetKeyUp (KeyCode.S)) {
			
			Siguiente ();

		}

		if (Input.GetKeyUp (KeyCode.A)) {
			
			Atras ();

		}
		if (Input.GetKeyUp (KeyCode.P)) {

			SceneManager.LoadScene ("Simulador");
			PlayerPrefs.SetInt ("Expo", PuntoActual);
		}

		if (Input.GetKeyUp (KeyCode.Escape)) {

            Salir();
		}
	}




    public void Salir(){
        SceneManager.LoadScene ("MenuInicio");
        PlayerPrefs.SetInt ("Expo", 0);
    }


	[ContextMenu("Siguiente")]
	public void Siguiente() {
		
		PuntoActual++;
		if (PuntoActual > TodosLosPuntos.Length-1) {
			PuntoActual = TodosLosPuntos.Length - 1;
		}
		Actualizar ();
	}
	[ContextMenu("Atras")]

	public void Atras() {
		PuntoActual--;

		if (PuntoActual < 0) {
			PuntoActual = 0;
		}
		Actualizar ();

	}

	public void Actualizar(){
		GameObject[] Obj = TodosLosPuntos [PuntoActual].Objetos;

		for (int i = 0; i < Obj.Length; i++) {
			Obj [i].SetActive (true);
		}
		if ((PuntoActual - 1) >= 0) {
			Obj = TodosLosPuntos [PuntoActual - 1].Objetos;

			for (int i = 0; i < Obj.Length; i++) {
				Obj [i].SetActive (false);
			}
		}
		if ((PuntoActual + 1) < TodosLosPuntos.Length) {
			Obj = TodosLosPuntos [PuntoActual + 1].Objetos;

			for (int i = 0; i < Obj.Length; i++) {
				Obj [i].SetActive (false);
			}
		}

	}


}
[System.Serializable ]
public struct Puntos{
	public string Nombre;
	public Transform IrA,MirarA;
	public GameObject[] Objetos;
}
