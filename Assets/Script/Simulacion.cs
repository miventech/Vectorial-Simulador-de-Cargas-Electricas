using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Simulacion : MonoBehaviour {
	public Sprite StopCampo , Playcampo , stopCargas,PlayCargas;
	public Button Simular, Campos;
	void Start(){
		PlayerPrefs.DeleteKey ("simular");
	}
	void Update(){
		if (PlayerPrefs.HasKey ("simular")) {
			Campos.interactable = false;
			Simular.GetComponent<Image> ().sprite = stopCargas;
		} else {
			Campos.interactable = true;
			Simular.GetComponent<Image> ().sprite = PlayCargas;


		}
		if (PlayerPrefs.HasKey ("campos")) {
			Simular.interactable = false;
			Campos.GetComponent<Image> ().sprite = StopCampo;

		} else {
			Simular.interactable = true;

			Campos.GetComponent<Image> ().sprite =Playcampo;
	

		}
	}
	public void CambiarEstado(){
		if (PlayerPrefs.HasKey ("simular")) {
			PlayerPrefs.DeleteKey ("simular");
		} else {
			PlayerPrefs.SetInt ("simular", 1);
		}
	}
	public void CambiarEstadoCampo(){
		if (PlayerPrefs.HasKey ("campos")) {
			PlayerPrefs.DeleteKey ("campos");
		} else {
			PlayerPrefs.SetInt ("campos", 1);
		}
	}
}
