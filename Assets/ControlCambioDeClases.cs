using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCambioDeClases : MonoBehaviour {
	public Sprite[] Clases;
	public Control_Pos posCamara;
	public int PosAccion;
	public SpriteRenderer SR;
	public Animator Anim;
	public TextMesh TextoPos;
	private bool AnimState;
	private int Pos;
	// Use this for initialization
	void Start () {
		posCamara = GameObject.FindObjectOfType<Control_Pos> ();
		Anim = GetComponentInChildren<Animator> ();
		Pos = 0;
		Actualizar ();
		AnimState = false;
	}

	void Update () {
		if (posCamara.PuntoActual == PosAccion) {
			if (Input.GetKeyDown (KeyCode.RightArrow) && !AnimState) {
				Pos++;
				if (Pos > Clases.Length - 1) {
					Pos = Clases.Length - 1;
				} else {
					Actualizar ();
				}

			}

			if (Input.GetKeyDown (KeyCode.LeftArrow) && !AnimState) {
				Pos--;
				if (Pos < 0) {
					Pos = 0;
				} else {
					Actualizar ();
				}


			}
		
		}
	}


	void Actualizar(){
		TextoPos.text = (Pos + 1) + "/" + Clases.Length;
		if (!AnimState) {
			StopCoroutine ("CambioDeClase");
			StartCoroutine (CambioDeClase ());
		}
	}

	IEnumerator CambioDeClase (){
		Anim.SetBool ("Cambiar", true);
		AnimState = true;
		yield return new WaitForSeconds (0.5f);
		SR.sprite = Clases [Pos];
		yield return new WaitForSeconds (0.5f);
		Anim.SetBool ("Cambiar", false);
		AnimState = false;
	}
    

}
