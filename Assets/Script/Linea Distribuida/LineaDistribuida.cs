using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineaDistribuida : MonoBehaviour {
	public Color ColorNeutral;

	public Transform P_inicio, P_1, P_2, P_final; // Posiciones
	public LineRenderer LineaDraw; // Dibujador de Linea
	public Vector3[] Puntos; // Mapeo De Puntos
	public int Calidad; // numero de lineas
	public GameObject EditorLinea;
	private ControlDistribuidas CD;
	public float DistanciaDelaLinea; // m
	public float ValorGenericoLineal; // C/m
	public float ValorPorCarga;// Coulomb    C/m * m = C   ( ValorGenericoLineal * DistanciaDeLaLinea);
	public float[] DistribucionDeIntensidad; // gradient de 0 - 1 par asaber la intensidad 
	[Range(0f,0.5f)]
	public float LeftGradient;
	[Range(0.5f,1f)]
	public float RightGradient;
	// Use this for initialization
	void Start () {
		Calidad = 200;
		CD = FindObjectOfType<ControlDistribuidas> ().GetComponent<ControlDistribuidas>();
	}
	[ContextMenu("AplicarCalidad")]
	public void AplicarCalidad(){
		float SepPont = (Vector3.Distance (P_inicio.position, P_final.position) / 4);

		LineaDraw.positionCount = Calidad;

		Puntos = new Vector3[Calidad];
		Vector3[] PointsLine = Puntos;
		float DisLine = Vector3.Distance (P_inicio.position, P_final.position);

		float Separador = DisLine / Calidad;
	

		Vector3 dir = P_final.position - P_inicio.position;

	



		for (int x = 0; x < Puntos.Length; x++) {
			LineaDraw.SetPosition (x, P_inicio.position + ((Separador * x) * dir.normalized));
			PointsLine [x] = P_inicio.position + ((Separador * x) * dir.normalized);
			Puntos[x] = P_inicio.position + ((Separador * x) * dir.normalized);
		}
		//Puntos [Calidad - 1] = P_final.position;

		P_1.position = new Vector3(P_1.position.x , P_1.position.y , P_inicio.transform.position.z + SepPont);
		P_2.position = new Vector3(P_2.position.x , P_2.position.y , P_inicio.transform.position.z + (3*SepPont));
		LineaDraw.SetPositions (Puntos);
			
	}
	[ContextMenu("DibujarPuntos")]

	public void DibujarPuntos(){
		LineaDraw.positionCount = Puntos.Length;
		LineaDraw.SetPositions (Puntos);


	}


	[ContextMenu("AplicarSeno")]
	public void AplicarFormaSeno(){
		AplicarCalidad ();
		//	Vector3 dir = P_final.position - P_inicio.position;
		//Debug.Log (dir.normalized);

		float SubDivAngle = Mathf.PI / ((Puntos.Length)/2);
		// primer Seno 
		int ptratado = 0;
		for (int x = 0; x < Puntos.Length/2; x++) {
		//	float Valueangel = SubDivAngle * x;
			Puntos [x] = new Vector3((P_1.position.x) *  Mathf.Sin (SubDivAngle*x),
									(P_1.position.y) *  Mathf.Sin (SubDivAngle*x) ,
									(Puntos[x].z)); 
			ptratado++;
		}

		for (int x = Puntos.Length-1; x > Puntos.Length/2; x--) {
			//	float Valueangel = SubDivAngle * x;
			Puntos [x] = new Vector3((-P_2.position.x) *  Mathf.Sin (SubDivAngle*x),
						(-P_2.position.y) *  Mathf.Sin (SubDivAngle*x) ,
						(Puntos[x].z)); 
			ptratado++;

		} 
		Puntos [Calidad - 1] = P_final.position;
		DibujarPuntos ();
		CalcularDistancia ();
	}
	public void CalcularDistancia(){
		DistanciaDelaLinea = 0;
		for (int x = 0; x < Puntos.Length-1; x++) {
			DistanciaDelaLinea += Vector3.Distance (Puntos [x], Puntos [x + 1]);
		} 
		AplicarColorGradient ();
	}
	public void AplicarCalculos(){
		ValorPorCarga = ValorGenericoLineal * DistanciaDelaLinea;
		DistribucionDeIntensidad = new float[Calidad];
		//recorrido del gradient Izq -> centro 
		for(int x = 0; x < DistribucionDeIntensidad.Length;x++){
			DistribucionDeIntensidad [x] = 1;
		}
		float SepSmoot = 1/(LeftGradient * Calidad);
		for(int x = 0 ; x < (Mathf.RoundToInt(LeftGradient*Calidad)) ; x++){
			DistribucionDeIntensidad [x] = (x* SepSmoot);
		} 
		SepSmoot = 1/((RightGradient) * Calidad);
		int cont = 0;
		for (int x = (DistribucionDeIntensidad.Length-1)  ; x > (Mathf.RoundToInt ((RightGradient) * Calidad)) ; x--) {
			
			DistribucionDeIntensidad [x] = (cont * SepSmoot);
			cont++;
		}


	}
	public void right (float f){
		RightGradient =1.5f - f;
		AplicarCalculos ();
	}
	public void LeftGradientfloat (float f){
		
		LeftGradient =f;
		AplicarCalculos ();
	}
	public void AplicarColorGradient(){
		AplicarCalculos ();
		Gradient gradient = new Gradient();
		if (ValorGenericoLineal > 0) {
			gradient.SetKeys (
				new GradientColorKey[] {
					new GradientColorKey (ColorNeutral, 0.0f),
					new GradientColorKey (Color.green, LeftGradient) ,
					new GradientColorKey (Color.green, RightGradient),
					new GradientColorKey (ColorNeutral, 1.0f)
				},
				new GradientAlphaKey[] {
					new GradientAlphaKey (1f, 0.0f),
					new GradientAlphaKey (1.0f, LeftGradient) ,
					new GradientAlphaKey (1.0f, RightGradient) ,
					new GradientAlphaKey (1f, 1.0f)
				}
			);
		}
		if (ValorGenericoLineal < 0) {
			gradient.SetKeys (
				new GradientColorKey[] {
					new GradientColorKey (ColorNeutral, 0.0f),
					new GradientColorKey (Color.red, LeftGradient) ,
					new GradientColorKey (Color.red, RightGradient),
					new GradientColorKey (ColorNeutral, 1.0f)
				},
				new GradientAlphaKey[] {
					new GradientAlphaKey (1f, 0.0f),
					new GradientAlphaKey (1.0f, LeftGradient) ,
					new GradientAlphaKey (1.0f, RightGradient) ,
					new GradientAlphaKey (1f, 1.0f)
				}
			);
		}
		LineaDraw.colorGradient = gradient;
	}

	void Update () {
		if (CD.EstadoVentana && !PlayerPrefs.HasKey ("campos") && !PlayerPrefs.HasKey ("simular")) {
			EditorLinea.SetActive (true);
			AplicarFormaSeno ();
		} else {
			EditorLinea.SetActive (false);
		}
	}
}

