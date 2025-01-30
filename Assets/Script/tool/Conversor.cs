using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversor : MonoBehaviour {
	/// <summary>
	/// Rects a cilindricas.
	/// </summary>
	/// <returns> transforme.position = (x ,z  , y)</returns>
	/// <param name="Rectpos">Rectpos.</param>
	public static Vector3 Rect_a_Cilindricas(Vector3 Rectpos){
		Vector3 cordenadas = Rectpos;
		float rohf = Mathf.Pow ((cordenadas.y * cordenadas.y + cordenadas.x * cordenadas.x), 0.5f);
		float AnguloFi = (Mathf.Atan2 (cordenadas.y, cordenadas.x))*Mathf.Rad2Deg;
		
		return( new Vector3 ( rohf , AnguloFi , Rectpos.z));
	}

	public static Vector3 Rect_a_Esfericas(Vector3 Rectpos){
		Vector3 cordenadas = Rectpos;

		float r = cordenadas.magnitude;
		float fi = (Mathf.Atan2 (cordenadas.y, cordenadas.x))*Mathf.Rad2Deg;
		float tita = Mathf.Acos (cordenadas.z / cordenadas.magnitude)*Mathf.Rad2Deg;
		return( new Vector3 ( r ,tita, fi ));

	}


	public static Vector3 Cilindricas_a_Rect(Vector3 Cilinpos){
		float x = Cilinpos.x * Mathf.Cos (Cilinpos.y * Mathf.Deg2Rad);
		float y = Cilinpos.x * Mathf.Sin (Cilinpos.y * Mathf.Deg2Rad);
		float z = Cilinpos.z;
		return (new Vector3 (x, y, z));
	}
	public static Vector3 Esfericas_a_Rect(Vector3 EsferaPos){
	
		float x = EsferaPos.x * Mathf.Sin(EsferaPos.y * Mathf.Deg2Rad)* Mathf.Cos(EsferaPos.z * Mathf.Deg2Rad);
		float y = EsferaPos.x * Mathf.Sin (EsferaPos.y * Mathf.Deg2Rad)* Mathf.Sin(EsferaPos.z * Mathf.Deg2Rad);
		float z = EsferaPos.x * Mathf.Cos (EsferaPos.y * Mathf.Deg2Rad);
		return (new Vector3 (x, y, z));
	}
	public static Vector3 Esfericas_a_Cilin(Vector3 EsferaPos){

		float x = EsferaPos.x * Mathf.Sin(EsferaPos.y * Mathf.Deg2Rad)* Mathf.Cos(EsferaPos.z * Mathf.Deg2Rad);
		float y = EsferaPos.x * Mathf.Sin (EsferaPos.y * Mathf.Deg2Rad)* Mathf.Sin(EsferaPos.z * Mathf.Deg2Rad);
		float z = EsferaPos.x * Mathf.Cos (EsferaPos.y * Mathf.Deg2Rad);
		Vector3  r = Rect_a_Cilindricas (new Vector3 (x, y, z));
		return r ;
	}
	public static Vector3 Cilin_a_Esfericas(Vector3 Cilinpos){

		float x = Cilinpos.x * Mathf.Cos (Cilinpos.y * Mathf.Deg2Rad);
		float y = Cilinpos.x * Mathf.Sin (Cilinpos.y * Mathf.Deg2Rad);
		float z = Cilinpos.z;
		Vector3  r = Rect_a_Esfericas (new Vector3 (x, y, z));
		return r ;
	}
}

