using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control_expo : MonoBehaviour
{
    public Animator Anim ;
    public bool open_win = true;
    public Control_Pos ctrp;
    void Start() {
        Anim = GetComponent<Animator>();
        ctrp = FindObjectOfType<Control_Pos>();

    }

    public void close_open() {
        open_win = !open_win;
        Anim.SetBool("open", open_win);
    }
    public void salir() {
        ctrp.Salir();
    }
    public void next() {
        ctrp.Siguiente();
        Debug.Log("siguiente");

    }
    public void prev() {
        ctrp.Atras();
        Debug.Log("anteiriro");

    }

    public void arrow_next() {

    }

    public void arrow_prev() {

    }

}
