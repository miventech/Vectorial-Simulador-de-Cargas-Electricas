using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdicionadorDeCargas : MonoBehaviour {
	public InputField Nombre,valor_Text,xt,yt,zt , roh, fiCilin, zCilin, r, tita, fiEsfe;
	public Toggle TipoDeCarga;
	public GameObject CargaObjeto;
	private string[] AleNombres;
	public float Valor ;
	public Vector3 Position;
	public string NombreString;
	private int cont = 0;
	public bool Estado;
	public Animator Anim;

	void Start(){
		AleNombres = new string[31];
		AleNombres [0] = "Carga 1";
		AleNombres [1] = "G";
		AleNombres [2] = "Electron";
		AleNombres [3] = "Proton";
		AleNombres [4] = "J";
		AleNombres [5] = "Omh";
		AleNombres [6] = "RMS";
		AleNombres [7] = "Johely";
		AleNombres [8] = "N";
		AleNombres [9] = "P";
		AleNombres [10] = "Andres";
		AleNombres [11] = "Jas";
		AleNombres [12] = "Jor";
		AleNombres [13] = "Rod";
		AleNombres [14] = "Amb";
		AleNombres [15] = "R";
		AleNombres [16] = "S";
		AleNombres [17] = "Carga 2";
		AleNombres [18] = "Carga Unica";
		AleNombres [19] = "C";
		AleNombres [20] = "F";
		AleNombres [21] = "Z";
		AleNombres [22] = "V";
		AleNombres [23] = "B";
		AleNombres [24] = "M";
		AleNombres [25] = "W";
		AleNombres [26] = "Q";
		AleNombres [27] = "T";
		AleNombres [28] = "Y";
		AleNombres [29] = "I";
		AleNombres [30] = "K";
		EndEdicionRectangular ();

	}
	void Update(){
		Valor = float.Parse (valor_Text.text) * Mathf.Pow(10f,-6f);
		Position = new Vector3 (float.Parse (xt.text), float.Parse (zt.text) , float.Parse (yt.text));
		NombreString = Nombre.text;
		if (PlayerPrefs.HasKey ("select")) {
			Anim.SetBool ("Open", false);
		}
	}
	public void ColorcarCarga(){
		
		if (!PlayerPrefs.HasKey ("campos")) {
			GameObject Carg_obj = Instantiate (CargaObjeto, Position, new Quaternion (0, 0, 0, 0));
			Carga C = Carg_obj.GetComponent<Carga> ();
			C.ID = cont;
			C.PasarDatos (Valor, NombreString, TipoDeCarga.isOn);
			cont++;
			RamdonVAlue ();
			FindObjectOfType<ControlCargas> ().Actualizar ();
		}
	}
	public void RamdonVAlue(){
		zt.text =""+Random.Range (0.0001f, 4);
		xt.text = "" + Random.Range (-4, 4);
		yt.text = "" + Random.Range (-4, 4);
		valor_Text.text = "" + Random.Range (-10, 40).ToString ("##.##");
		Nombre.text = AleNombres [Random.Range (0, 30)];
		EndEdicionRectangular ();
	}

	public void OcultarMostrar(){
		
		if (Estado) {
			Estado = false;
		}else{
			Estado = true;
		}
		Anim.SetBool ("Open", Estado);


	}

	public void EndEdicionRectangular ()
	{

		Vector3 CordCilin = Conversor.Rect_a_Cilindricas (new Vector3 (float.Parse (xt.text), float.Parse (yt.text), float.Parse (zt.text)));
		Vector3 CordEsfer = Conversor.Rect_a_Esfericas (new Vector3 (float.Parse (xt.text), float.Parse (yt.text), float.Parse (zt.text))); 


		roh.text = CordCilin.x + "";
		fiCilin.text = CordCilin.y + "";
		zCilin.text = CordCilin.z + "";

		r.text = CordEsfer.x + "";
		tita.text = CordEsfer.y + "";
		fiEsfe.text = CordEsfer.z + "";


	}


	public void EndEdicionCilindrica ()
	{
		Vector3 cilin = new Vector3 (float.Parse (roh.text), float.Parse (fiCilin.text), float.Parse (zCilin.text));
		Vector3 CordRect = Conversor.Cilindricas_a_Rect (cilin);
		Vector3 CordEsfer = Conversor.Cilin_a_Esfericas (cilin); 


		xt.text = CordRect.x + "";
		yt.text = CordRect.y + "";
		zt.text = CordRect.z + "";

		r.text = CordEsfer.x + "";
		tita.text = CordEsfer.y + "";
		fiEsfe.text = CordEsfer.z + "";


	}

	public void EndEdicionEsferica ()
	{
		Vector3 Esfer = new Vector3 (float.Parse (r.text), float.Parse (tita.text), float.Parse (fiEsfe.text));
		Vector3 CordRect = Conversor.Esfericas_a_Rect(Esfer);

		xt.text = CordRect.x + "";
		yt.text = CordRect.y + "";
		zt.text = CordRect.z + "";



		Vector3 CordCilin = Conversor.Rect_a_Cilindricas (new Vector3 (float.Parse (xt.text), float.Parse (yt.text), float.Parse (zt.text)));

		roh.text = CordCilin.x + "";
		fiCilin.text = CordCilin.y + "";
		zCilin.text = CordCilin.z + "";



	}

}
