using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargaCampo : MonoBehaviour
{


	private float PermDelEspacio, K;
	public string VisualizarDatosFreno;
	[Header ("Datos")]
	public float ControlDeVelocidad = 1f;
	public Transform PosInicio;
	public Vector3 FuerzaResultante;
	private Carga[] CargasT;
	public TrailRenderer recorrido;
	private Carga C;
	private float direc = 1;
	private float TiempoInicio;
	public bool FrenoCampo;
	private bool simCampo;

	//privadas//
	private ControlCargas Control_Carg;



	// Use this for initialization
	void Start ()
	{
		C = GetComponentInParent<Carga> ();
		Control_Carg = GameObject.FindGameObjectWithTag ("ControlCargas").GetComponent<ControlCargas> ();

		PermDelEspacio = (8.854f * Mathf.Pow (10f, (-12f)));
		//PermDelEspacio = 8.854f;
		K = 1 / (4 * Mathf.PI * PermDelEspacio);

	}



	void Update ()
	{

		if (simCampo && PlayerPrefs.HasKey ("campos")) {
			transform.position = PosInicio.position;
			recorrido.Clear ();
			StartCoroutine (IniciarCampo ());
		}
		if(!PlayerPrefs.HasKey ("campos")){
			simCampo = true;
			FrenoCampo = false;
			CargasT = Control_Carg.TodasLasCargas;
		}
			

//// seccion De simulacion ///////


		// esto es porque si no el trial renderer no empieza dedes cero no me pregunten porque.... gracias


	}

	public IEnumerator IniciarCampo ()
	{
		if (C.ValorCarga < 0) {
			recorrido.material = C.Negativo;

		} else {
			recorrido.material = C.Positivo;
		} 
		simCampo = false;
		recorrido.enabled = true;
		transform.position = PosInicio.position;
		recorrido.Clear ();
		//////////////////////////////////////////////////
		while (PlayerPrefs.HasKey ("campos")) {
			FuerzaResultante = Vector3.zero;
			FuerzaResultante = GetForceResult (CargasT);
			FuerzaResultante += GetForceLine ();
			FuerzaResultante += GetforceSuperficie ();
			FuerzaResultante += GetForceVolumen ();
			PlayerPrefs.DeleteKey ("Eje");
			AplicarFuerza ();
			yield return new WaitForSeconds (0.01f);

		}
		/////////////////////////////////////////////////
		recorrido.Clear ();
		recorrido.enabled = false;
		simCampo = true;
	
	}




	/*	void FixedUpdate ()
	{
		CargasT = Control_Carg.TodasLasCargas;
		if (!PlayerPrefs.HasKey ("campos")) {
			recorrido.Clear ();
			recorrido.enabled = false;
			FrenoCampo = false;
			TiempoInicio = 0.3f;
			transform.position = PosInicio.position;
		} else {
			recorrido.enabled = true;
		}

		if (PlayerPrefs.HasKey ("campos") && TiempoInicio < 0f && !FrenoCampo) {
			FuerzaResultante = GetForceResult (CargasT);
			FuerzaResultante += GetForceLine ();
			FuerzaResultante += GetforceSuperficie ();
			FuerzaResultante += GetForceVolumen ();
			PlayerPrefs.DeleteKey ("Eje");
			AplicarFuerza ();
		}
	}

*/

	void AplicarFuerza ()
	{


		/*
		if (Mathf.Abs( FuerzaResultante.magnitude) < 1f) {
			ControlVel = 1000f;
		}
		if (Mathf.Abs( FuerzaResultante.magnitude) < 100f && Mathf.Abs( FuerzaResultante.magnitude) > 1f) {
			ControlVel = 0.1f;
		}
		if (Mathf.Abs( FuerzaResultante.magnitude) < 5000f && Mathf.Abs( FuerzaResultante.magnitude) > 100f) {
			ControlVel = 0.000005f;
		}
		if (Mathf.Abs( FuerzaResultante.magnitude) < 20000f &&  Mathf.Abs( FuerzaResultante.magnitude) > 5000f) {
			ControlVel = 0.000001f;
		}
		if (Mathf.Abs( FuerzaResultante.magnitude) < 60000f &&  Mathf.Abs( FuerzaResultante.magnitude) > 20000f) {
			ControlVel = 0.0000005f;
		}
		if (Mathf.Abs( FuerzaResultante.magnitude) > 60000f && Mathf.Abs( FuerzaResultante.magnitude) < 1000000f) {
			ControlVel = 0.00000005f;
		}
		if (Mathf.Abs( FuerzaResultante.magnitude) > 1000000f && Mathf.Abs( FuerzaResultante.magnitude) < 10000000f) {
			ControlVel = 0.000000005f;
		}
		if (Mathf.Abs( FuerzaResultante.magnitude) > 100000000f && Mathf.Abs( FuerzaResultante.magnitude) < 10000000000f ) {
			ControlVel = 0.00000000005f;
		}
		if (Mathf.Abs( FuerzaResultante.magnitude) > 100000000000f  ) {
			ControlVel = 0.000000000005f;
		}
		VisualizarDatosFreno = ControlVel.ToString () + "  Magnitud:" + FuerzaResultante.magnitude ;
		ControlVel *= 100f;
		if (!FrenoCampo) { 
			if (C.ValorCarga < 0) {
				transform.Translate (-FuerzaResultante * Time.deltaTime *ControlVel);

			} else {
				transform.Translate (FuerzaResultante *Time.deltaTime* ControlVel);

			} 
		}
     */
		if (ControlDeVelocidad == 0) {
			ControlDeVelocidad = 1f;
		}
		if (!FrenoCampo) { 
			if (C.ValorCarga < 0) {
				transform.Translate (-FuerzaResultante.normalized * Time.deltaTime *ControlDeVelocidad);

			} else {
				transform.Translate (FuerzaResultante.normalized *Time.deltaTime* ControlDeVelocidad);

			} 
		}
	
	
	
	
	
	
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

				Vector3 Direccion = (transform.position - LD.Puntos [i]);
				float Distancia = Direccion.magnitude;
				if (Distancia > 0.05f) {
					float Fuerza = (K * (LD.DistribucionDeIntensidad [i] * LD.ValorGenericoLineal * direc)) / Mathf.Pow (Distancia, 2);
					Vector3 FuerzaVector3 = Direccion.normalized * Fuerza;
					ResForce = ResForce + FuerzaVector3;
				} else {
					FrenoCampo = true;
				}
			}
		}
		return ResForce;
	}

	public Vector3 GetforceSuperficie ()
	{


		/////////////////////////
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

					Vector3 Direccion = (transform.position - (Puntos [i] * SD.transform.localScale.x));
					float Distancia = Direccion.magnitude;
					if (Distancia < 0.05f) {

						FrenoCampo = true;
					}
					float Fuerza = (K * (Intensidad [i] * ValorPorCarga)) / Mathf.Pow (Distancia, 2);
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
						if (Distancia < 0.05f) {

							FrenoCampo = true;
						}
						float Fuerza = (K * (VD.CargaIndividual)) / Mathf.Pow (Distancia, 2);
						Vector3 FuerzaVector3 = Direccion.normalized * Fuerza;
						ResForce = ResForce + FuerzaVector3;
					}
				}
			}
		}
		return ResForce;

	

	}

	public Vector3 GetForceResult (Carga[] cargasTotales)
	{
		Vector3 ResForce = Vector3.zero;

		for (int i = 0; i < cargasTotales.Length; i++) {
			
			Carga cargaSola = cargasTotales [i]; 
			if (cargaSola != null) {
				Vector3 Direccion = (transform.position - cargaSola.transform.position);
				

				// maginitud de la direccion ( distancia)
				float Distancia = Direccion.magnitude;
				if (Distancia > 0.2f) {
					float Fuerza = ((K * cargaSola.ValorCarga * direc) / Mathf.Pow (Distancia, 2));
					Vector3 FuerzaVector3 = Direccion.normalized * Fuerza;

					ResForce = ResForce + FuerzaVector3;

				} else {
					FrenoCampo = true;
				}
			}

		}

		return ResForce;
	}



}
