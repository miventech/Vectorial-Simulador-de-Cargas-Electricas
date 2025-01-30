using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumenDistribuido : MonoBehaviour {
	public float volumen;
	public TipoDeVolumen Tipo = TipoDeVolumen.Cubo;
	public Vector3[] Vertices;
	public float CargaVolumetrica;
	public float CargaIndividual;
	[Header("Mallas de los Volumenes")]
	public MeshFilter mCubo;
	public MeshFilter mEsfera,mCilindro;
	public GameObject g_cubo, g_Cilindro, g_Esfera;
	[Header("Parametros de Modificacion")]
	public Transform Escala;

	void Update () {
		
		if (Tipo == TipoDeVolumen.Cubo) {

			float scale = Escala.position.x;
			mCubo.transform.localScale = new Vector3 (scale, scale, scale);
			g_cubo.transform.localScale = new Vector3 (scale, scale, scale);
			volumen = Mathf.Pow (mCubo.transform.localScale.x*2, 3);
			CargaIndividual = CargaVolumetrica * volumen;
			Vertices = mCubo.mesh.vertices;


		}
		if (Tipo == TipoDeVolumen.Esfera) {
			
			float scale = Escala.position.x;
			mEsfera.transform.localScale = new Vector3 (scale, scale, scale);
			g_Esfera.transform.localScale = new Vector3 (scale, scale, scale);
			volumen = (4/3) * Mathf.PI * (scale);
			CargaIndividual = CargaVolumetrica * volumen;
			Vertices = mEsfera.mesh.vertices;

		}
		if (Tipo == TipoDeVolumen.Cilindro) {

			float scale = Escala.position.x;
			mCilindro.transform.localScale = new Vector3 (scale, scale, scale);
			g_Cilindro.transform.localScale = new Vector3 (scale, scale, scale);
			volumen = scale*2 * Mathf.PI * Mathf.Pow((scale),2);
			CargaIndividual = CargaVolumetrica * volumen;
			Vertices = mCilindro.mesh.vertices;

		}
	}

	void ActualizarEnables(){
		VolumenDistribuido VD = this;

		if (Tipo == TipoDeVolumen.Cubo ){
			VD.enabled = true;

			if (VD.g_cubo != null) {

				VD.g_cubo.SetActive (true);

			}


			if (VD.g_Cilindro != null) {

				VD.g_Cilindro.SetActive (false);

			}


			if (VD.g_Esfera != null) {

				VD.g_Esfera.SetActive (false);

			}
			VD.mCubo.gameObject.SetActive (true);
			VD.mCilindro.gameObject.SetActive (false);
			VD.mEsfera.gameObject.SetActive (false);

		}else if (Tipo == TipoDeVolumen.Esfera){
			VD.enabled = true;

			if (VD.g_cubo != null) {

				VD.g_cubo.SetActive (false);

			}


			if (VD.g_Cilindro != null) {

				VD.g_Cilindro.SetActive (false);

			}


			if (VD.g_Esfera != null) {

				VD.g_Esfera.SetActive (true);

			}
			VD.mCubo.gameObject.SetActive (false);
			VD.mCilindro.gameObject.SetActive (false);
			VD.mEsfera.gameObject.SetActive (true);

		}else if (Tipo == TipoDeVolumen.Cilindro){
			VD.enabled = true;

			if (VD.g_cubo != null) {

				VD.g_cubo.SetActive (false);

			}


			if (VD.g_Cilindro != null) {

				VD.g_Cilindro.SetActive (true);

			}


			if (VD.g_Esfera != null) {

				VD.g_Esfera.SetActive (false);

			}
			VD.mCubo.gameObject.SetActive (false);
			VD.mCilindro.gameObject.SetActive (true);
			VD.mEsfera.gameObject.SetActive (false);

		}
	}



}
public enum TipoDeVolumen{
	Cubo,Esfera,Cilindro
}
