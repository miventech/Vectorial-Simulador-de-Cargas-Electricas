using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Opciones : MonoBehaviour {
	public Toggle Fl_result , Nombre , ValorF,Posicion,LineasEntreC,VectorR,Recorrido;
	public Slider VelDeSimulacion;
	public Text Vel;
	public float Valor;
	public bool Estado;
	public Animator Anim;
	public GameObject CargarDeRef;
	public InputField NombreDeGuardado,DescGuarda;
	// Update is called once per frame
	void Start(){
		if (!PlayerPrefs.HasKey ("R_$")) {
			PlayerPrefs.SetInt ("R_$", 0);
		}
		PlayerPrefs.SetInt ("R_$", 0);
		if(PlayerPrefs.HasKey("CargaArchivo")){
		Cargar(PlayerPrefs.GetString ("CargaArchivo"));
		}
		Anim = GetComponent<Animator> ();
		PlayerPrefs.DeleteKey ("simular");
		PlayerPrefs.DeleteKey ("select");

	}
	public void SalirAlmenu (){
		SceneManager.LoadScene (0);
	}

			public void Actualizar(){
	
			}
	void Update () {

		Time.timeScale = VelDeSimulacion.value;
		Vel.text = VelDeSimulacion.value.ToString ("F");
		if (Fl_result.isOn) {
			PlayerPrefs.SetString ("FResultante","lero lero :P");
		} else {
			PlayerPrefs.DeleteKey ("FResultante");
			ValorF.isOn = false;
		}

		if (Nombre.isOn) {
			PlayerPrefs.SetString ("nombre","lero lero");
		} else {
			PlayerPrefs.DeleteKey ("nombre");
		}
		if (Recorrido.isOn) {
			PlayerPrefs.SetString ("Recorrido","lero lero");
		} else {
			PlayerPrefs.DeleteKey ("Recorrido");
		}
		if (ValorF.isOn) {
			PlayerPrefs.SetString ("ValorCarga","lero lero");

		} else {
			PlayerPrefs.DeleteKey ("ValorCarga");
		}
		if (Posicion.isOn) {
			PlayerPrefs.SetString ("Posicion","lero lero");
		} else {
			PlayerPrefs.DeleteKey ("Posicion");
		}
		if (LineasEntreC.isOn) {
			PlayerPrefs.SetString ("LineasEC", "lerolero");

		} else {
			PlayerPrefs.DeleteKey ("LineasEC");
		}
		if (VectorR.isOn) {
		
			PlayerPrefs.SetString ("VectorR", "lero");
		} else {
			PlayerPrefs.DeleteKey ("VectorR");
		}
	}

	public void EliminarTodasLasCargas(){

		Carga[] TodasLasCargas = FindObjectsOfType<Carga> (); 	
		for (int x = 0; x < TodasLasCargas.Length; x++) {
		
			DestroyImmediate (TodasLasCargas [x].gameObject);

		}

		FindObjectOfType<ControlCargas> ().Actualizar ();


	}

	public void OcultarMostrar(){
		if (Estado) {
			Estado = false;
		}else{
			Estado = true;
		}
		Anim.SetBool ("Open", Estado);
	}
	public void CerrarVentana(){
		Estado = false;
		Anim.SetBool ("Open", Estado);

	}

	public void Guardar(){
		Carga[] TodasLasCargas = FindObjectsOfType<Carga> (); 
		Image[] TodasLasGUI = FindObjectsOfType<Image> ();
		string DatosProyectos = "";
		if (PlayerPrefs.HasKey ("Proyectos")) {
			DatosProyectos = PlayerPrefs.GetString ("Proyectos");
		}

		DatosProyectos += "@" + NombreDeGuardado.text;

		if (!PlayerPrefs.HasKey (NombreDeGuardado.text)) {
			PlayerPrefs.SetString ("Proyectos", DatosProyectos);
		}

		string TextoGuardado = "";
		string SeparadorPrimario = "$";// separar el numero de Cargas
		string SeparadorSecundario = "%";// Separar la posicion
		for (int x = 0; x < TodasLasCargas.Length; x++) {
			int R = 0;
			if (TodasLasCargas [x].CargaDePrueba == true) {
				R = 1;
			
			} else {
				R = 0;
			}
		
			Vector3 Pos = TodasLasCargas [x].transform.position;
			TextoGuardado +=  "" + Pos.x + SeparadorSecundario + Pos.y + SeparadorSecundario + Pos.z + SeparadorSecundario +
				TodasLasCargas[x].Nombre + SeparadorSecundario + TodasLasCargas[x].ValorCarga  + SeparadorSecundario + R  + SeparadorPrimario;
		}
		PlayerPrefs.SetString (NombreDeGuardado.text, TextoGuardado);
		PlayerPrefs.SetString (NombreDeGuardado.text + "Desc", DescGuarda.text);

		string SavePath = Application.persistentDataPath +"/"+ NombreDeGuardado.text +".png";
		for (int x = 0; x < TodasLasGUI.Length; x++) {
			TodasLasGUI [x].enabled = false;
		}
		ScreenCapture.CaptureScreenshot (SavePath);

		for (int x = 0; x < TodasLasGUI.Length; x++) {
			TodasLasGUI [x].enabled = true;
		}




	}

	public void Cargar(string SaveDate){
		NombreDeGuardado.text = SaveDate;
		DescGuarda.text = PlayerPrefs.GetString (SaveDate + "Desc");
		string Datos = PlayerPrefs.GetString (SaveDate);
		char SeparadorPrimario = '$';
		char SeparadorSecundario = '%';
		string[] DatosPrimario = Datos.Split (SeparadorPrimario);
		for (int x = 0; x < DatosPrimario.Length; x++) {
			if (DatosPrimario [x] != string.Empty) {


				string[] DatosSecundario = DatosPrimario [x].Split (SeparadorSecundario);

				Vector3 pos = new Vector3 (float.Parse (DatosSecundario [0]), float.Parse (DatosSecundario [1]), float.Parse (DatosSecundario [2])); 

				GameObject CargaAct = Instantiate (CargarDeRef, pos, new Quaternion (0, 0, 0, 0));
				Carga car = CargaAct.GetComponent<Carga> ();

				int R =  int.Parse (car.Nombre = DatosSecundario [5]);
				bool f = false;
				if (R == 1) {
					f = true;
				}
				if (R == 0) {
					f = false;
				}
				car.ID = x;
				car.PasarDatos (float.Parse (DatosSecundario [4]), DatosSecundario [3], f);

			}
		}
		FindObjectOfType<ControlCargas> ().Actualizar ();
		PlayerPrefs.DeleteKey ("CargaArchivo");

	}



}
