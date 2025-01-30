using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCargas : MonoBehaviour {
	public Carga[] TodasLasCargas;
	public void Actualizar ()
	{
		TodasLasCargas = FindObjectsOfType<Carga> (); 	
	}
}
