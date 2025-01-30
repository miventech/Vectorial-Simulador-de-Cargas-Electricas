using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlDistribuidas : MonoBehaviour {
	private Animator Anim;
	[HideInInspector]
	 public bool EstadoVentana;
	public Dropdown TipoDeDistribucion;
	public Button Act_Des_Vent , A_D_X;
	public GameObject SeccionLineal,SeccionPlano,SeccionVolumen;
	[Header("Obciones de Lineal")]
	public GameObject LineaObj;
	public LineaDistribuida LineaD;
	public Text ValorCalidad;
	public InputField VelorDensidad;
	public Text DatosExtras;
	public Image ColorFondoGradiant;
	[Header("Obciones de Superficie")]
	public SuperficieDistribuida ScriptSuperf;
	public GameObject PlanoObj;
	public Text DatosExtrasSuperficie;
	public SpriteRenderer ColorImagD;
	public Image ColorFondoDegradado;
	public InputField ValorDensidadSuperficie;

	[Header("Obciones de Volumen")]
	public VolumenDistribuido VD;
	public Dropdown TipoDeFigura;
	public InputField VelorDensidadVolumen;
	public Text DatosExtrasVolumen;

	void Start(){
		if (!PlayerPrefs.HasKey ("R_$")) {
			PlayerPrefs.SetInt ("R_$", 0);
		}
		PlayerPrefs.SetInt ("R_$", 0);
		ActualizarVolumenGUI ();
		Anim = GetComponent<Animator> ();
		EstadoVentana = false;
		QCalidadDeLinea (50);
		DensidadLinealFiel ();
		PlayerPrefs.DeleteKey ("campos");
		PlayerPrefs.DeleteKey ("simular");
		CerrarVentana ();
	}
	public void CerrarVentana(){
		EstadoVentana = false;
		Anim.SetBool ("Mostrar", EstadoVentana);
	}	
	public void AbrirVentana(){
		EstadoVentana = true;
		Anim.SetBool ("Mostrar", EstadoVentana);

	}	
	public void QCalidadDeLinea(float f){
		LineaD.Calidad = Mathf.RoundToInt (f);
		ValorCalidad.text = "" + Mathf.RoundToInt (f);
	}
	public void DensidadLinealFiel(){

		float R = float.Parse (VelorDensidad.text);
		LineaD.ValorGenericoLineal = R * (Mathf.Pow(10,-9));
		LineaD.AplicarCalculos ();

	}
	public void CargaSuperficial(){
		float R = float.Parse (ValorDensidadSuperficie.text);
		ScriptSuperf.ValorDistribuida = R * (Mathf.Pow(10,-9));
		ScriptSuperf.AplicarDistribucion (ColorImagD.transform.localScale.x);
	}
	public void DensidadDeSuperficie(){
		
	}
	public void ActualizarVolumenGUI(){
	

		if(TipoDeFigura.value == 0){
			


			if (VD.g_Cilindro != null) {

				VD.g_Cilindro.SetActive (false);

			}


			if (VD.g_Esfera != null) {

				VD.g_Esfera.SetActive (false);

			}
			VD.mCubo.gameObject.SetActive (false);
			VD.mCilindro.gameObject.SetActive (false);
			VD.mEsfera.gameObject.SetActive (false);

			VD.gameObject.SetActive(false);

		
		}else if (TipoDeFigura.value == 1){
			VD.gameObject.SetActive(true);


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

		}else if (TipoDeFigura.value == 2){
			VD.gameObject.SetActive(true);

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

		}else if (TipoDeFigura.value == 3){
			VD.gameObject.SetActive(true);


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



	void Update () {
		if (EstadoVentana) {


			if (PlayerPrefs.HasKey ("campos") || PlayerPrefs.HasKey ("simular") || PlayerPrefs.GetInt("R_$") == 1) {
				Anim.SetBool ("Mostrar", false);
				Act_Des_Vent.interactable = false;
				A_D_X.interactable = false;
			} 
			if (!PlayerPrefs.HasKey ("campos") && !PlayerPrefs.HasKey ("simular") && PlayerPrefs.GetInt("R_$") == 0) {
				Anim.SetBool ("Mostrar", true);
				Act_Des_Vent.interactable = true;
				A_D_X.interactable = true;

				if (TipoDeDistribucion.value == 1) {
					SeccionLineal.SetActive (true);
					LineaObj.SetActive (true);
					DatosExtras.text = "Longitud: " + LineaD.DistanciaDelaLinea + " m\nC: " + LineaD.ValorPorCarga;
					if (LineaD.ValorGenericoLineal < 0) {
						ColorFondoGradiant.color = Color.red;
					}
					if (LineaD.ValorGenericoLineal > 0) {
						ColorFondoGradiant.color = Color.green;
					}



				} else {
					SeccionLineal.SetActive (false);
					LineaObj.SetActive (false);
				}
				if (TipoDeDistribucion.value == 2) {
					SeccionPlano.SetActive (true);
					PlanoObj.SetActive (true);
					DatosExtrasSuperficie.text = "Area: " + ScriptSuperf.Area + " m^2 \n C: " + ScriptSuperf.ValorPorCarga;
					if (ScriptSuperf.ValorPorCarga < 0) {
						ColorFondoDegradado.color = Color.red;
						ColorImagD.color = Color.red;
					}
					if (ScriptSuperf.ValorPorCarga > 0) {
						ColorFondoDegradado.color = Color.green;
						ColorImagD.color = Color.green;

					}
				} else {
					SeccionPlano.SetActive (false);
					PlanoObj.SetActive (false);
				}
				if (TipoDeDistribucion.value == 3) {

					SeccionVolumen.SetActive (true);
					if(TipoDeFigura.value == 0){

						DatosExtrasVolumen.text = "selecciones una figura para empezar a observar cambios";


					}else if (TipoDeFigura.value == 1){

						VD.Tipo = TipoDeVolumen.Cubo;
						float densidad = float.Parse (VelorDensidadVolumen.text);
						VD.CargaVolumetrica = densidad* (Mathf.Pow(10,-9));
						DatosExtrasVolumen.text = "Valor por segmento cubico : " + VD.CargaIndividual + "c\n" + "Volumen: " + VD.volumen+ " m^3"; 


					}else if (TipoDeFigura.value == 2){

						VD.Tipo = TipoDeVolumen.Esfera;
						float densidad = float.Parse (VelorDensidadVolumen.text);
						VD.CargaVolumetrica = densidad* (Mathf.Pow(10,-9));
						DatosExtrasVolumen.text = "Valor por segmento cubico : " + VD.CargaIndividual + "c\n" + "Volumen: " + VD.volumen + " m^3"; 

					}else if (TipoDeFigura.value == 3){
						
						VD.Tipo = TipoDeVolumen.Cilindro;
						float densidad = float.Parse (VelorDensidadVolumen.text);
						VD.CargaVolumetrica = densidad * (Mathf.Pow(10,-9));
						DatosExtrasVolumen.text = "Valor por segmento cubico : " + VD.CargaIndividual + "c\n" + "Volumen: " + VD.volumen+ " m^3"; 
					
					}


				} else {
					SeccionVolumen.SetActive (false);
					VD.gameObject.SetActive (false);
				}
			}
		
		
		} else {
			if (!PlayerPrefs.HasKey ("campos") && !PlayerPrefs.HasKey ("simular") && PlayerPrefs.GetInt("R_$") == 0) {
				Act_Des_Vent.interactable = true;
				A_D_X.interactable = true;
			}
			if (PlayerPrefs.HasKey ("campos") || PlayerPrefs.HasKey ("simular") || PlayerPrefs.GetInt("R_$") == 1) {
				Act_Des_Vent.interactable = false;
				A_D_X.interactable = false;
			}
		}
	}
}
