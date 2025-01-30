using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperficieDistribuida : MonoBehaviour
{
	
	public MeshFilter PlanoLow, PlanoHigh;
	public Transform PosDistorcion, RadioSeno,Tamaño;
	public GameObject EditorDeSuperficie;
	public float[] ValorDistribucion;
	public float ValorDistribuida;
	public ControlDistribuidas CD;
	public float Area,ValorPorCarga;
	void Start (){
		DeformarMalla (PlanoLow);	
		DeformarMalla (PlanoHigh);
		transform.localScale = new Vector3 (Tamaño.localPosition.x, Tamaño.localPosition.x, Tamaño.localPosition.x);
		CD = FindObjectOfType<ControlDistribuidas> ().GetComponent<ControlDistribuidas>();

	}
	 
	public void DeformarMalla (MeshFilter MeshF)
	{
		
		MeshFilter MF = MeshF;
		float TamañoVert = MF.mesh.vertices.Length;
		float SubDivAngle = Mathf.PI/2 ;
		Vector3[] vers = MF.mesh.vertices;
		//vers [vers.Length / 2] = new Vector3 (vers [vers.Length / 2].x, 4, vers [vers.Length / 2].z);
		float DistaciaRef = Vector3.Distance (new Vector3 (PosDistorcion.localPosition.x, 0, PosDistorcion.localPosition.z), RadioSeno.localPosition);
		for (int x = 0; x < vers.Length; x++) {
			float DistanciaVertice = Vector3.Distance (new Vector3 (PosDistorcion.localPosition.x, 0, PosDistorcion.localPosition.z),new Vector3( vers [x].x ,0 , vers [x].z));
			if (DistanciaVertice <= DistaciaRef) {

				float RMult = 1 - (DistanciaVertice / DistaciaRef);
				vers [x] = new Vector3 (vers [x].x, PosDistorcion.localPosition.y * Mathf.Sin( (SubDivAngle * RMult)), vers [x].z);
		
			} else {
				vers [x] = new Vector3 (vers [x].x,0, vers [x].z);

			}

		}
		MF.mesh.vertices = vers;

	}
	[ContextMenu ("Modificar Malla Secundaria")]
	public void DeformarMallaSecundaria(){
		DeformarMalla (PlanoLow);
	}
	public void AplicarDistribucion(float EscalaDegradado){


		ValorDistribucion = new float[ PlanoLow.mesh.vertices.Length];
		MeshFilter MF = PlanoLow;
		//float TamañoVert = MF.mesh.vertices.Length;
		float SubDivAngle = Mathf.PI/2 ;
		Vector3[] vers = MF.mesh.vertices;

		//vers [vers.Length / 2] = new Vector3 (vers [vers.Length / 2].x, 4, vers [vers.Length / 2].z);
		float DistaciaRef = EscalaDegradado * transform.localScale.x;
		for (int x = 0; x < vers.Length; x++) {
			float DistanciaVertice = Vector3.Distance (new Vector3 (PosDistorcion.localPosition.x, 0, PosDistorcion.localPosition.z),new Vector3( vers [x].x ,0 , vers [x].z));
			if (DistanciaVertice <= DistaciaRef) {
				float RMult = 1 - (DistanciaVertice / DistaciaRef);
				ValorDistribucion [x] = Mathf.Sin ((SubDivAngle * RMult));
			} else {
				ValorDistribucion[x] = 0f;
			}

		}
		MF.mesh.vertices = vers;
		CalcularArea ();
		ValorPorCarga = ValorDistribuida * Area;



	}
	[ContextMenu("Calcular Area")]
	public void CalcularArea(){
		//Debug.Log (PlanoLow.mesh.triangles.Length);;
		Mesh MeshArea = PlanoLow.mesh;
		float AreaTotal = 0;
		for(int x = 0; x < (MeshArea.triangles.Length/3);x++){
			int t1 = MeshArea.triangles[0 + (3*x)];
			int t2 = MeshArea.triangles[1 + (3*x)];
			int t3 = MeshArea.triangles[2 + (3*x)];
			Vector3 P1 = MeshArea.vertices [t1];
			Vector3 P2 = MeshArea.vertices [t2];
			Vector3 P3 = MeshArea.vertices [t3];
			float A = Vector3.Distance (P1, P2);
			float B = Vector3.Distance (P2, P3);
			float C = Vector3.Distance (P1, P3);
			float Perimetro = ((A + B + C) / (2));
			//Debug.Log (Perimetro);
			float Res = (Perimetro * (Perimetro-A) * (Perimetro-B) * (Perimetro-C));
			//Debug.Log (Res);

			float SemiArea = Mathf.Sqrt (Res);
			AreaTotal += SemiArea;
			//Debug.Log (SemiArea);


		}
		AreaTotal *= transform.localScale.x;
		Area = AreaTotal;
		//Debug.Log (AreaTotal);
	}
	void Update () {
		if (CD.EstadoVentana && !PlayerPrefs.HasKey ("campos") && !PlayerPrefs.HasKey ("simular")) {
			EditorDeSuperficie.SetActive (true);
		} else {
			EditorDeSuperficie.SetActive (false);
		}
	}
}

