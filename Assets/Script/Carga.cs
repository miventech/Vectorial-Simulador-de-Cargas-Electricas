using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carga : MonoBehaviour
{
	
	private float PermDelEspacio, K;
	[HideInInspector]
	public Rigidbody Rb;
	[Header ("Decoracion")]
	public Material Positivo;
	public Material Negativo, D_Prueba;
	public TextMesh NombreCarga, ValorFuerza, TextPosicion;
	public bool ColapsoDeCarga;
	public GameObject PuntoHuella;

	[Header ("Datos")]
	public float ValorCarga;
	//	[HideInInspector]
	public bool CargaDePrueba, Simular;
	public string Nombre;
	[HideInInspector]
	public int ID;
	public  string IDGuardado;
	[HideInInspector]
	public float Vel;
	public Vector3 FuerzaResultante;
	private float AngleA, AngleB;

	public Carga[] CargasT;
	private float tiempo;
	[Header ("Lineas")]
//	public LineRenderer LineasEntreCargas;
	public LineRenderer LineOrigen;
	public TrailRenderer LineaDeRecorrido;
	//privadas//
	private ControlCargas Control_Carg;
	public float ValorMasAlto;
	[Header("Flacha reultante")]

	public GameObject FlechaResultante,TamañoFlecha;
	public Color ColorMin, ColorMax;
	public float SizeArrow;

	// Use this for initialization
	void Start ()
	{
		if (!PlayerPrefs.HasKey ("R_$")) {
			PlayerPrefs.SetInt ("R_$", 0);
		}
		PlayerPrefs.SetInt ("R_$", 0);
		Control_Carg = GameObject.FindGameObjectWithTag ("ControlCargas").GetComponent<ControlCargas> ();

		PermDelEspacio = (8.854f * Mathf.Pow (10f, (-12f)));
		//PermDelEspacio = 8.854f;
		K = 1 / (4 * Mathf.PI * PermDelEspacio);
		Rb = GetComponent<Rigidbody> ();

	}


	[ContextMenu ("VerContribucion")]
	public void IniciarContribucion ()
	{

		PlayerPrefs.SetInt ("R_$", 1);

		Carga[] Cs = Control_Carg.TodasLasCargas;
		Carga[] CargasDes = new Carga[Cs.Length - 1];
		int control = 0;
		for (int x = 0; x < Cs.Length; x++) {
			if (Cs [x] != this) {
				CargasDes [control] = Cs [x];
				control++;
			}
		}
		for (int x = 0; x < CargasDes.Length; x++) {
			CargasDes [x].gameObject.SetActive (false);
		}

		SuperficieDistribuida SD = null;

		if (FindObjectOfType<SuperficieDistribuida> () != null) {
			SD = FindObjectOfType<SuperficieDistribuida> ();
		}
		LineaDistribuida LD = null;

		if (FindObjectOfType<LineaDistribuida> () != null) {
			LD = FindObjectOfType<LineaDistribuida> ();
		}
		VolumenDistribuido VD = null;
		if (FindObjectOfType<VolumenDistribuido> () != null) {
			VD = FindObjectOfType<VolumenDistribuido> ();
		}

		/*if (VD != null) {
			LD.gameObject.SetActive (false);
		}
		if (LD != null) {
			LD.gameObject.SetActive (false);
		}
		if (SD != null) {
			LD.gameObject.SetActive (false);
		}*/
		StartCoroutine (VisualizarContribucion (CargasDes, LD, SD, VD));
	}

	public IEnumerator VisualizarContribucion (Carga[] C, LineaDistribuida LD, SuperficieDistribuida SD, VolumenDistribuido VD)
	{



		bool State_LD = false;
	
		bool State_SD = false;
		bool State_VD = false;

		if (LD != null) {
			State_LD = LD.gameObject.activeSelf;
			LD.gameObject.SetActive (false);

		}
		if (SD != null) {
			State_SD = SD.gameObject.activeSelf;
			SD.gameObject.SetActive (false);
		}
		if (VD != null) {
			
			State_VD = VD.gameObject.activeSelf;
			VD.gameObject.SetActive (false);
		}
		Puntos_contribucion contribucion = FindObjectOfType<Puntos_contribucion> ();

		contribucion.posiciones = new Vector3[4];
		for (int x = 0; x < contribucion.posiciones.Length; x++) {
			contribucion.posiciones [x] = transform.position;
		}
		///mostrar distribucion de cargas ////

		FuerzaResultante = Vector3.zero;
		for (int x = 0; x < C.Length; x++) {
			if (PlayerPrefs.GetInt ("contribucion") == 1) {
				FuerzaResultante += GetForceEnMi (C [x]);
				contribucion.SetViewContribucion (C [x].transform.position, transform.position);
				GameObject p = Instantiate (PuntoHuella, C [x].transform.position, new Quaternion (0f, 0f, 0f, 0f));
				p.tag = "huella";
				yield return new WaitForSeconds (0.5f);
				ResultanteAngle ();
			} else {
				break;
			}
		}
		if (State_LD) {
			for (int x = 0; x < LD.Calidad; x++) {
				if (PlayerPrefs.GetInt ("contribucion") == 1) {
					Vector3 p = LD.Puntos [x];
					FuerzaResultante += GetForceCustom (p, LD.ValorPorCarga * LD.DistribucionDeIntensidad [x]);
					contribucion.SetViewContribucion (p, transform.position);
					GameObject punto = Instantiate (PuntoHuella, p, new Quaternion (0f, 0f, 0f, 0f));
					punto.tag = "huella";
					ResultanteAngle ();

					yield return new WaitForSeconds (0.1f);
				} else {
					break;
				}

			}
		}

		if (State_SD) {
			SD.gameObject.SetActive (false);
			Vector3[] verts = SD.PlanoLow.mesh.vertices;
			Vector3[] vertsGlobal = new Vector3[verts.Length];
			for (int x = 0; x < verts.Length; x++) {
				vertsGlobal [x] = verts [x] * SD.transform.localScale.x;	
			}

			float[] Intensidad = SD.ValorDistribucion;
		//	float ValorPorCarga = SD.ValorPorCarga;

			if (verts.Length == Intensidad.Length) {
				for (int i = 0; i < verts.Length; i++) {
					if (PlayerPrefs.GetInt ("contribucion") == 1) {
						contribucion.SetViewContribucion (vertsGlobal [i], transform.position);

						FuerzaResultante += GetForceCustom (vertsGlobal [i], SD.ValorPorCarga * Intensidad [i]);
						GameObject punto = Instantiate (PuntoHuella, vertsGlobal [i], new Quaternion (0f, 0f, 0f, 0f));
						punto.tag = "huella";
						ResultanteAngle ();
						yield return new WaitForSeconds (0.04f);

					} else {
						break;
					}
				}

			}

		}
		if (State_VD) {
		
			float sum = VD.transform.localScale.x / 10f;
			for (float x = 0.12f; x <= VD.transform.localScale.x; x += sum) { 
				for (int i = 0; i < VD.Vertices.Length; i++) {
					if (PlayerPrefs.GetInt ("contribucion") == 1) {
						if (VD.CargaIndividual != 0) {
							Vector3 pt = VD.Vertices [i] * x;
							FuerzaResultante += GetForceCustom (pt, VD.CargaIndividual);
							contribucion.SetViewContribucion (pt, transform.position);
							GameObject punto = Instantiate (PuntoHuella, pt, new Quaternion (0f, 0f, 0f, 0f));
							punto.tag = "huella";
							ResultanteAngle ();
							yield return new WaitForSeconds (0.0000007f);

						}
					}
				}
			}
		
		}



		if (LD != null) {
			LD.gameObject.SetActive (State_LD);
		}
		if (SD != null) {
			SD.gameObject.SetActive (State_SD);
		}
		if (VD != null) {
			VD.gameObject.SetActive (State_VD);
		}
		for (int x = 0; x < C.Length; x++) {
			C [x].gameObject.SetActive (true);
		}
		contribucion.FinVisualizacion ();
		GameObject[] puntos_huella = GameObject.FindGameObjectsWithTag ("huella");
		for (int x = 0; x < puntos_huella.Length; x++) {
			Destroy (puntos_huella [x]);
		}
		PlayerPrefs.SetInt ("R_$", 0);
	
	}


	void Actualizar ()
	{
		if (PlayerPrefs.GetInt ("R_$") == 0) {
			if (!PlayerPrefs.HasKey ("campos")) {
				if (!PlayerPrefs.HasKey ("simular")) {
					IDGuardado = Nombre + ID;
					Rb.velocity = new Vector3 (0, 0, 0);
					Rb.interpolation = 0;
					if (PlayerPrefs.HasKey (IDGuardado)) {
						string[] Pos = PlayerPrefs.GetString (IDGuardado).Split ('!');
						if (!PlayerPrefs.HasKey ("select")) {
							transform.position = new Vector3 (float.Parse (Pos [0]), float.Parse (Pos [1]), float.Parse (Pos [2]));
						}
					} else {
						GuardarDatos ();
					}
				} else {
					ColapsoDeCarga = false;
				}
				//dibujar una linea del origen hasta la carga
				LineOrigen.SetPosition (0, Vector3.zero);
				LineOrigen.SetPosition (1, transform.position);
				//// seccion De Opciones ///////
				/// 
				if ((PlayerPrefs.HasKey ("FResultante") && CargasT.Length > 1) || FuerzaResultante.magnitude != 0 || (PlayerPrefs.HasKey ("FResultante") && FindObjectOfType<LineaDistribuida> () != null) || (PlayerPrefs.HasKey ("FResultante") && FindObjectOfType<SuperficieDistribuida> () != null) || (PlayerPrefs.HasKey ("FResultante") && FindObjectOfType<VolumenDistribuido> () != null)) {
					FlechaResultante.SetActive (true);
				} else {
					FlechaResultante.SetActive (false);	
				}
				if (PlayerPrefs.HasKey ("nombre")) {
					NombreCarga.gameObject.SetActive (true);
				} else {
					NombreCarga.gameObject.SetActive (false);	
				}
				if (PlayerPrefs.HasKey ("ValorCarga")) {
					ValorFuerza.gameObject.SetActive (true);
				} else {
					ValorFuerza.gameObject.SetActive (false);	
				}
				if (PlayerPrefs.HasKey ("Posicion")) {
					TextPosicion.gameObject.SetActive (true);
				} else {
					TextPosicion.gameObject.SetActive (false);	
				}

				if (PlayerPrefs.HasKey ("VectorR")) {
					LineOrigen.gameObject.SetActive (true);
				} else {
					LineOrigen.gameObject.SetActive (false);

				}

				if (PlayerPrefs.HasKey ("Recorrido")) {
					LineaDeRecorrido.gameObject.SetActive (true);
				} else {
					LineaDeRecorrido.gameObject.SetActive (false);

				}
				//// seccion De estilos ///////

				if (ValorCarga < 0 && !CargaDePrueba) {
					GetComponent<Renderer> ().material = Negativo;
				}
				if (ValorCarga > 0 && !CargaDePrueba) {
					GetComponent<Renderer> ().material = Positivo;

				}
				if (CargaDePrueba) {
					GetComponent<Renderer> ().material = D_Prueba;
			
				}
				//// seccion De extras ///////

				NombreCarga.text = Nombre;
				if (!CargaDePrueba) {
					Rb.isKinematic = true;
				} else {
					Rb.isKinematic = false;
		
				}
				//// seccion De simulacion ///////



				TextPosicion.text = "(" + transform.position.x.ToString ("F") + "ax," + transform.position.z.ToString ("F") + "ay," + transform.position.y.ToString ("F") + "az)"; 
	
			}
		} else {

			if (ValorCarga < 0 && !CargaDePrueba) {
				GetComponent<Renderer> ().material = Negativo;
			}
			if (ValorCarga > 0 && !CargaDePrueba) {
				GetComponent<Renderer> ().material = Positivo;

			}
			if (CargaDePrueba) {
				GetComponent<Renderer> ().material = D_Prueba;

			}
			FlechaResultante.SetActive (true);
			ValorFuerza.gameObject.SetActive (true);
			LineOrigen.gameObject.SetActive (false);
		
		}
	}

	void FixedUpdate ()
	{

		if (!PlayerPrefs.HasKey ("campos")) {
			if (transform.position.y == 0) {
				transform.position = new Vector3 (transform.position.x, 0.0000001f, transform.position.z);
			}
			CargasT = Control_Carg.TodasLasCargas;



			if ((PlayerPrefs.GetInt ("R_$") == 0) && (CargasT.Length > 1 || FindObjectOfType<LineaDistribuida> () != null || FindObjectOfType<SuperficieDistribuida> () != null || FindObjectOfType<VolumenDistribuido> () != null)) {


					FuerzaResultante = GetForceResult (Control_Carg.TodasLasCargas);
					FuerzaResultante += GetForceLine ();
					FuerzaResultante += GetforceSuperficie ();
					FuerzaResultante += GetForceVolumen ();



				ResultanteAngle ();




				// seccion de simulacion//
				if (LineaDeRecorrido.gameObject.activeSelf) {
					if (!PlayerPrefs.HasKey ("simular")) {
						LineaDeRecorrido.Clear ();
						LineaDeRecorrido.enabled = false;
					} else {
						LineaDeRecorrido.enabled = true;
					}
				}



				if (PlayerPrefs.HasKey ("simular")) {
					PlayerPrefs.DeleteKey ("Eje");
					if (!ColapsoDeCarga) {
						AplicarFuerza ();
					}
				}
				Actualizar ();	

			} else {
				Actualizar ();	
		
			}

		}
	}


	public void ResultanteAngle ()
	{

		///////////////////TAMAÑO RESULTANTE///////////////////

		Renderer R = TamañoFlecha.GetComponentInChildren<Renderer> ();
		SizeArrow = ((FuerzaResultante.magnitude) / 1f) + 0.74998f;
		float variante = (FuerzaResultante.magnitude / 10f);
		Color colorF = new Color(1f , 1f - variante ,1f - variante,1f);

		if (SizeArrow > 2.5f) {
			SizeArrow = 2.5f;
			//R.material.color = ColorMax;
		} else {
			//R.material.color = ColorMin;
		}

		R.material.color = colorF;


		TamañoFlecha.transform.localScale = new Vector3 (SizeArrow, SizeArrow, SizeArrow);







		///////////////////////////////////////////////////////




		if (FuerzaResultante.magnitude != 0) {
			AngleA = Mathf.Rad2Deg * Mathf.Atan2 (FuerzaResultante.z, FuerzaResultante.x);
			AngleB = Mathf.Rad2Deg * Mathf.Acos (FuerzaResultante.y / FuerzaResultante.magnitude);
			CargasT = Control_Carg.TodasLasCargas;
			FlechaResultante.transform.localEulerAngles = new Vector3 (0, -AngleA, -AngleB);
			if (FuerzaResultante.magnitude < 1000000f && FuerzaResultante.magnitude >= 1000f) { 
				float F = FuerzaResultante.magnitude / 1000f;
				ValorFuerza.text = "" + F.ToString ("####.##") + " kN";
			}

			if (FuerzaResultante.magnitude < 1000f && FuerzaResultante.magnitude >= 1f) { 
				float F = FuerzaResultante.magnitude;
				ValorFuerza.text = "" + F.ToString ("####.##") + " N";
			}

			if (FuerzaResultante.magnitude < 1f && FuerzaResultante.magnitude >= 0.0001f) { 
				float F = FuerzaResultante.magnitude * 1000;
				ValorFuerza.text = "" + F.ToString ("####.##") + " mN";
			}
			if (FuerzaResultante.magnitude < 0.0001f && FuerzaResultante.magnitude >= 0.0000001f) { 
				float F = FuerzaResultante.magnitude * 1000000;
				ValorFuerza.text = "" + F.ToString ("####.##") + " uN";
			}


			if (FuerzaResultante.magnitude < 0.0000001f && FuerzaResultante.magnitude >= 0.0000000001f) { 
				float F = FuerzaResultante.magnitude * 1000000000;
				ValorFuerza.text = "" + F.ToString ("####.##") + " nN";
			}
			if (FuerzaResultante.magnitude < 0.0000000001f) { 
				float F = FuerzaResultante.magnitude * 1000000000000;
				ValorFuerza.text = "" + F.ToString ("####.##") + " pN";
			}

			//ValorFuerza.text = "" + FuerzaResultante.magnitude;
		} 


	}





	void AplicarFuerza ()
	{
		
		if (CargaDePrueba) {
			
			//Rb.AddForce (FuerzaResultante);
		
			transform.Translate (FuerzaResultante * Time.deltaTime);
		}
	
	}

	public Vector3 GetforceSuperficie ()
	{

		SuperficieDistribuida SD = null;

		if (FindObjectOfType<SuperficieDistribuida> () != null) {
			SD = FindObjectOfType<SuperficieDistribuida> ();
		}
			
		Vector3 ResForce = Vector3.zero;
		if (SD != null) {


			Vector3[] Puntos = SD.PlanoLow.mesh.vertices;
			float[] Intensidad = SD.ValorDistribucion;
			float ValorPorCarga = SD.ValorPorCarga;

			if (Puntos.Length == Intensidad.Length) {
				for (int i = 0; i < Puntos.Length; i++) {
					Puntos [i] = Puntos [i] * SD.transform.localScale.x; 
					Vector3 Direccion = (transform.position - (Puntos [i] * SD.transform.localScale.x));
					float Distancia = Direccion.magnitude;
					if (Distancia == 0) {
						Distancia = 0.000000001f;
					}
					if (Distancia < 0.3f) {
						ColapsoDeCarga = true;
					}
					float Fuerza = (K * ValorCarga * (Intensidad [i] * ValorPorCarga)) / Mathf.Pow (Distancia, 2);
					Vector3 FuerzaVector3 = Direccion.normalized * Fuerza;
					ResForce = ResForce + FuerzaVector3;
				}
			}
		}
		return ResForce;
	}

	public Vector3 GetForceLine ()
	{

		LineaDistribuida LD = null;

		if (FindObjectOfType<LineaDistribuida> () != null) {
			LD = FindObjectOfType<LineaDistribuida> ();
		}

		Vector3 ResForce = Vector3.zero;
		if (LD != null) {
			for (int i = 0; i < LD.Puntos.Length; i++) {
				if (LD.DistribucionDeIntensidad [i] * LD.ValorPorCarga != 0) {
					Vector3 Direccion = (transform.position - LD.Puntos [i]);
					float Distancia = Direccion.magnitude;
					if (Distancia == 0) {
						Distancia = 0.000000001f;
					}
					if (Distancia < 0.3f) {
						ColapsoDeCarga = true;
					}
					float Fuerza = (K * ValorCarga * (LD.DistribucionDeIntensidad [i] * LD.ValorPorCarga)) / Mathf.Pow (Distancia, 2);
					Vector3 FuerzaVector3 = Direccion.normalized * Fuerza;
					ResForce = ResForce + FuerzaVector3;
				}
			}
		}
		return ResForce;
	
	}

	public Vector3 GetForceVolumen ()
	{

		VolumenDistribuido VD = null;
		VD = FindObjectOfType<VolumenDistribuido> ();
		Vector3 ResForce = Vector3.zero;
		if (VD != null) {
			float sum = VD.transform.localScale.x / 10f;
			for (float x = 0.12f; x <= VD.transform.localScale.x; x += sum) { 
				for (int i = 0; i < VD.Vertices.Length; i++) {
					if (VD.CargaIndividual != 0) {
						Vector3 pt = VD.Vertices [i] * x;
						Vector3 Direccion = (transform.position - pt);
						float Distancia = Direccion.magnitude;
						if (Distancia == 0) {
							Distancia = 0.000000001f;
						}
						if (Distancia < 0.3f) {
							ColapsoDeCarga = true;
						}
						float Fuerza = (K * ValorCarga * (VD.CargaIndividual)) / Mathf.Pow (Distancia, 2);
						Vector3 FuerzaVector3 = Direccion.normalized * Fuerza;
						ResForce = ResForce + FuerzaVector3;
					}
				}
			}
		}
		return ResForce;
	}




	public Vector3 GetForceEnMi (Carga C)
	{
		Carga cargaSola = C;

		Vector3 ResForce = Vector3.zero;


		if (cargaSola.ValorCarga != 0 && ValorCarga != 0) {
			// direccion de la fuerza
			Vector3 Direccion = (transform.position - cargaSola.transform.position);


			// maginitud de la direccion ( distancia)
			float Distancia = Direccion.magnitude;
			if (Distancia == 0) {
				Distancia = 0.000000001f;
			}
			if (Distancia < 0.2f) {
				ColapsoDeCarga = true;
			}
			float Fuerza = (K * ValorCarga * cargaSola.ValorCarga) / Mathf.Pow (Distancia, 2);
			Vector3 FuerzaVector3 = Direccion.normalized * Fuerza;

			ResForce = ResForce + FuerzaVector3;
		}
		return ResForce;
	
	}

	public Vector3 GetForceCustom (Vector3 Posicion, float fuerzaC)
	{

		Vector3 ResForce = Vector3.zero;


		if (ValorCarga != 0 && ValorCarga != 0) {
			// direccion de la fuerza
			Vector3 Direccion = (transform.position - Posicion);


			// maginitud de la direccion ( distancia)
			float Distancia = Direccion.magnitude;
			if (Distancia == 0) {
				Distancia = 0.000000001f;
			}
			if (Distancia < 0.2f) {
				ColapsoDeCarga = true;
			}
			float Fuerza = (K * ValorCarga * fuerzaC) / Mathf.Pow (Distancia, 2);
			Vector3 FuerzaVector3 = Direccion.normalized * Fuerza;

			ResForce = ResForce + FuerzaVector3;
		}
		return ResForce;

	}


	public Vector3 GetForceResult (Carga[] cargasTotales)
	{
		
		Vector3 ResForce = Vector3.zero;
		for (int i = 0; i < cargasTotales.Length; i++) {
			if (cargasTotales [i] != null) {
				Carga cargaSola = cargasTotales [i]; 
				if (cargaSola != this) {
					if (cargaSola.ValorCarga != 0) {
						// direccion de la fuerza
						Vector3 Direccion = (transform.position - cargaSola.transform.position);


						// maginitud de la direccion ( distancia)
						float Distancia = Direccion.magnitude;
						if (Distancia == 0) {
							Distancia = 0.000000001f;
						}
						if (Distancia < 0.4f) {
							ColapsoDeCarga = true;
						}
						float Fuerza = (K * ValorCarga * cargaSola.ValorCarga) / Mathf.Pow (Distancia, 2);
						Vector3 FuerzaVector3 = Direccion.normalized * Fuerza;
		
						ResForce = ResForce + FuerzaVector3;
					}
				}
			} else {
				FindObjectOfType<ControlCargas> ().Actualizar ();
			}
		}
	
		return ResForce;
	}

	public void PasarDatos (float ValorCar, string nombre, bool TipoDeCarga)
	{
		Nombre = nombre;
		ValorCarga = ValorCar;
		IDGuardado = Nombre + ID;
		GuardarDatos ();
		CargaDePrueba = TipoDeCarga;
	}

	public void GuardarDatos ()
	{
		IDGuardado = Nombre + ID;
		string PosString = transform.position.x + "!" + transform.position.y + "!" + transform.position.z;
		PlayerPrefs.SetString (IDGuardado, PosString);

	}


}
