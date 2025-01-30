using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SelectCarga : MonoBehaviour
{
	private RaycastHit Rayo;
	public GameObject ejes;
	public InputField x, y, z, roh, fiCilin, zCilin, r, tita, fiEsfe, NombreSelect, ValorSelect;
	public Dropdown TipoDeCompo;
	public Toggle CargaDePrueba;
	public Text DatosExtra;

	public GameObject Ventana;
	[Header ("Datos")]
	public Vector3 Pos;
	public float valor;
	public string Nombre;
	public Carga CargaSeleccionada;
	public Button Simular, Campos;
	public CordenadasRect CordRect;
	public CordenadasEsfericas CordEsfericas;
	public CordenadasCilindricas CordCilin;
	public Animator Anim;
	public GameObject PararContribucion;
	// Use this for initialization
	void Start ()
	{
		Anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update ()
	{


		if (PlayerPrefs.GetInt ("R_$") == 1) {
			Campos.interactable = false;
			Simular.interactable = false;
		} else {
			Campos.interactable = true;
			Simular.interactable = true;
		}


		if (!PlayerPrefs.HasKey ("simular") && !PlayerPrefs.HasKey ("campos")) { //este if pregunta si la variable guardada "simular" y "campos"  no (!=) existe //

            if (!CamaraControl.modo_android)
            {
                Ray R = Camera.main.ScreenPointToRay(Input.mousePosition); /// es un rayo que va de la posicion de la pantalla a la del escenario

                if (Input.GetKeyUp(KeyCode.Mouse1))
                { /// pregunta si el boton derecho del mouse es precionado
                    if (Physics.Raycast(R, out Rayo, 1000f))
                    { // este if funciona como el rayo que se lanza y obtiene datos de quien coliciones ejemplo ( (camara) <| -------(rayo)--------- * (datos))
                        if (Rayo.collider.CompareTag("Carga"))
                        { // este if pregunta sí el objeto con quien choco eñ rayo contiene una estiqueta (tag) de nombre carga
                            CargaSeleccionada = Rayo.collider.GetComponent<Carga>();
                            CargaDePrueba.isOn = CargaSeleccionada.CargaDePrueba;
                            ejes.GetComponent<Ejes>().SituarEjeEnCarga(CargaSeleccionada.transform, CargaSeleccionada);
                            Pos = Rayo.collider.GetComponent<Carga>().transform.position;
                            x.text = Pos.x + "";
                            z.text = Pos.y + "";
                            y.text = Pos.z + "";
                            valor = Rayo.collider.GetComponent<Carga>().ValorCarga;
                            ValorSelect.text = "" + (valor / Mathf.Pow(10f, (-6f)));
                            Nombre = Rayo.collider.GetComponent<Carga>().Nombre;
                            NombreSelect.text = Nombre;
                            ejes.SetActive(true);
                            PlayerPrefs.SetString("select", "lero");
                            //	ejes.transform.position = Pos;
                            Anim.SetBool("Open", true);
                            EndEdicionRectangular();
                        }
                        if (Rayo.collider == null)
                        {

                            Pos = new Vector3(0, 0, 0);
                            valor = 0f;
                            Nombre = "No hay carga seleccionada";


                        }

                    }
                    else
                    {
                        Anim.SetBool("Open", false);

                        PlayerPrefs.DeleteKey("select");

                        Simular.interactable = true;
                        Campos.interactable = true;
                        ejes.GetComponent<Ejes>().DesituarCarga();

                        CargaSeleccionada = null;
                        Pos = new Vector3(0, 0, 0);
                        valor = 0f;
                        Nombre = "No hay carga seleccionada";
                        ejes.SetActive(false);

                    }
                }
            }
            else
            {

                if (Input.touchCount > 0)
                {
                    if (Input.GetTouch(0).tapCount >= 2)
                    { /// pregunta si el boton derecho del mouse es precionado
                        Ray R = Camera.main.ScreenPointToRay(Input.GetTouch(0).position); /// es un rayo que va de la posicion de la pantalla a la del escenario
                        if (Physics.Raycast(R, out Rayo, 1000f))
                        { // este if funciona como el rayo que se lanza y obtiene datos de quien coliciones ejemplo ( (camara) <| -------(rayo)--------- * (datos))
                            if (Rayo.collider.CompareTag("Carga"))
                            { // este if pregunta sí el objeto con quien choco eñ rayo contiene una estiqueta (tag) de nombre carga
                                CargaSeleccionada = Rayo.collider.GetComponent<Carga>();
                                CargaDePrueba.isOn = CargaSeleccionada.CargaDePrueba;
                                ejes.GetComponent<Ejes>().SituarEjeEnCarga(CargaSeleccionada.transform, CargaSeleccionada);
                                Pos = Rayo.collider.GetComponent<Carga>().transform.position;
                                x.text = Pos.x + "";
                                z.text = Pos.y + "";
                                y.text = Pos.z + "";
                                valor = Rayo.collider.GetComponent<Carga>().ValorCarga;
                                ValorSelect.text = "" + (valor / Mathf.Pow(10f, (-6f)));
                                Nombre = Rayo.collider.GetComponent<Carga>().Nombre;
                                NombreSelect.text = Nombre;
                                ejes.SetActive(true);
                                PlayerPrefs.SetString("select", "lero");
                                //	ejes.transform.position = Pos;
                                Anim.SetBool("Open", true);
                                EndEdicionRectangular();
                            }
                            if (Rayo.collider == null)
                            {

                                Pos = new Vector3(0, 0, 0);
                                valor = 0f;
                                Nombre = "No hay carga seleccionada";


                            }

                        }
                        else
                        {
                            Anim.SetBool("Open", false);

                            PlayerPrefs.DeleteKey("select");

                            Simular.interactable = true;
                            Campos.interactable = true;
                            ejes.GetComponent<Ejes>().DesituarCarga();

                            CargaSeleccionada = null;
                            Pos = new Vector3(0, 0, 0);
                            valor = 0f;
                            Nombre = "No hay carga seleccionada";
                            ejes.SetActive(false);

                        }
                    }
                }
            }

			/// mostrar en las diferentes coordenadas////
			if (CargaSeleccionada != null && Ventana.activeSelf) {
				if (TipoDeCompo.value == 1) {
					CordRect.cordenadas = CargaSeleccionada.transform.position;
					CordRect.gameObject.SetActive (true);
				} else {
					CordRect.gameObject.SetActive (false);
				}
				if (TipoDeCompo.value == 2) {
					CordCilin.cordenadas = CargaSeleccionada.transform.position;
					CordCilin.gameObject.SetActive (true);
				} else {
					CordCilin.gameObject.SetActive (false);
				}
				if (TipoDeCompo.value == 3) {
					CordEsfericas.cordenadas = CargaSeleccionada.transform.position;
					CordEsfericas.gameObject.SetActive (true);
				} else {
					CordEsfericas.gameObject.SetActive (false);

				}


			} else {
				CordRect.gameObject.SetActive (false);
				CordCilin.gameObject.SetActive (false);
				CordEsfericas.gameObject.SetActive (false);
			}
			if (CargaSeleccionada != null && !Input.GetKey (KeyCode.Mouse1)) {
				Campos.interactable = false;
				Simular.interactable = false;
				if (Input.GetMouseButtonUp (0)) {
					Pos = CargaSeleccionada.transform.position;
					x.text = Pos.x + ""; 
					z.text = Pos.y + ""; 
					y.text = Pos.z + ""; 
					EndEdicionRectangular ();
				}
				Vector3 FuerzaResultante = CargaSeleccionada.FuerzaResultante;
				string Denominacion = "N";
				float Multipli = 1;
				if (FuerzaResultante.magnitude < 1000000f && FuerzaResultante.magnitude >= 1000f) { 
					Multipli = 1000f;
					Denominacion = " kN";
				}

				if (FuerzaResultante.magnitude < 1000f && FuerzaResultante.magnitude >= 1f) { 
					Multipli = 1;
					Denominacion = " N";
				}

				if (FuerzaResultante.magnitude < 1f && FuerzaResultante.magnitude >= 0.0001f) { 
					Multipli = 1000;
					Denominacion = " mN";
				}
				if (FuerzaResultante.magnitude < 0.0001f && FuerzaResultante.magnitude >= 0.0000001f) { 
					Multipli = 1000000;
					Denominacion = " uN";
				}


				if (FuerzaResultante.magnitude < 0.0000001f && FuerzaResultante.magnitude >= 0.0000000001f) { 
					Multipli = 1000000000;
					Denominacion = " nN";
				}
				if (FuerzaResultante.magnitude < 0.0000000001f) { 
					Multipli = 1000000000000;
					Denominacion = " pN";
				}


				DatosExtra.text = "Fuerza Resultante\n" + (Multipli * CargaSeleccionada.FuerzaResultante).ToString () + " " + Denominacion + "\nDireccion\n" + CargaSeleccionada.FuerzaResultante.normalized;
				PlayerPrefs.SetString ("select", "lero");
				CargaSeleccionada.ValorCarga = float.Parse (ValorSelect.text) * Mathf.Pow (10f, -6f);
				CargaSeleccionada.Nombre = NombreSelect.text;
				CargaSeleccionada.CargaDePrueba = CargaDePrueba.isOn;
				//	ejes.transform.position = CargaSeleccionada.transform.position;

			}
		}

	}

	public void VisualizarContribucion ()
	{
		if (CargaSeleccionada != null) {
			if (!PlayerPrefs.HasKey ("R_$")) {
				PlayerPrefs.SetInt ("R_$", 0);
			}
			if (PlayerPrefs.GetInt ("R_$") == 0) {
				PlayerPrefs.SetInt ("contribucion", 1);
				CargaSeleccionada.IniciarContribucion ();
				Anim.SetBool ("Open", false);


				CargaSeleccionada = null;
				PlayerPrefs.DeleteKey ("select");
				ejes.SetActive (false);
				PararContribucion.SetActive (true);

			

			}
		}
	}

	public void _PararContribucion ()
	{
		PlayerPrefs.SetInt ("contribucion", 0);
		PararContribucion.SetActive (false);
	}


	public void EndEdicionRectangular ()
	{
	
		Vector3 CordCilin = Conversor.Rect_a_Cilindricas (new Vector3 (float.Parse (x.text), float.Parse (y.text), float.Parse (z.text)));
		Vector3 CordEsfer = Conversor.Rect_a_Esfericas (new Vector3 (float.Parse (x.text), float.Parse (y.text), float.Parse (z.text))); 


		roh.text = CordCilin.x + "";
		fiCilin.text = CordCilin.y + "";
		zCilin.text = CordCilin.z + "";

		r.text = CordEsfer.x + "";
		tita.text = CordEsfer.y + "";
		fiEsfe.text = CordEsfer.z + "";


		PasarPosicion ();
	}


	public void EndEdicionCilindrica ()
	{
		Vector3 cilin = new Vector3 (float.Parse (roh.text), float.Parse (fiCilin.text), float.Parse (zCilin.text));
		Vector3 CordRect = Conversor.Cilindricas_a_Rect (cilin);
		Vector3 CordEsfer = Conversor.Cilin_a_Esfericas (cilin); 


		x.text = CordRect.x + "";
		y.text = CordRect.y + "";
		z.text = CordRect.z + "";

		r.text = CordEsfer.x + "";
		tita.text = CordEsfer.y + "";
		fiEsfe.text = CordEsfer.z + "";


		PasarPosicion ();
	}

	public void EndEdicionEsferica ()
	{
		Vector3 Esfer = new Vector3 (float.Parse (r.text), float.Parse (tita.text), float.Parse (fiEsfe.text));
		Vector3 CordRect = Conversor.Esfericas_a_Rect (Esfer);

		x.text = CordRect.x + "";
		y.text = CordRect.y + "";
		z.text = CordRect.z + "";



		Vector3 CordCilin = Conversor.Rect_a_Cilindricas (new Vector3 (float.Parse (x.text), float.Parse (y.text), float.Parse (z.text)));

		roh.text = CordCilin.x + "";
		fiCilin.text = CordCilin.y + "";
		zCilin.text = CordCilin.z + "";



		PasarPosicion ();
	}


	public void EliminarCarga ()
	{
		if (CargaSeleccionada != null) {
			Destroy (CargaSeleccionada.gameObject);
		}
		FindObjectOfType<ControlCargas> ().Actualizar ();

		CargaSeleccionada = null;
		Pos = new Vector3 (0, 0, 0);
		valor = 0f;
		Nombre = "No hay carga seleccionada";
		ejes.SetActive (false);
		FindObjectOfType<ControlCargas> ().Actualizar ();
		Anim.SetBool ("Open", true);
		PlayerPrefs.DeleteKey ("select");

	}

	void PasarPosicion ()
	{
		ejes.GetComponent<Ejes> ().DesituarCarga ();
		if (float.Parse (z.text) == 0) {
			z.text = "0.00001";
		}
		CargaSeleccionada.transform.position = new Vector3 (float.Parse (x.text), float.Parse (z.text), float.Parse (y.text));
		CargaSeleccionada.GuardarDatos ();
		ejes.GetComponent<Ejes> ().SituarEjeEnCarga (CargaSeleccionada.transform, CargaSeleccionada);

	}
}
