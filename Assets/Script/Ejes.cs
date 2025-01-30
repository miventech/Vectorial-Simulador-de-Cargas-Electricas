using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejes : MonoBehaviour
{
	private RaycastHit Rayo;
	public float VelDespl;
	public Vector3 GlobalRotation;
	public Transform cargaPos;
	private Carga car;
	private bool Movex, MoveY, MoveZ;
	public bool stop;
	public bool tap;

	void Update ()
	{
	
		GlobalRotation = Camera.main.transform.eulerAngles;
        if (!CamaraControl.modo_android)
        {
            Ray R = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                /// pregunta si el boton derecho del mouse es presionado
                if (Physics.Raycast(R, out Rayo, 500f))
                { // este if funciona como el rayo que se lanza y obtiene datos de quien coliciones ejemplo ( (camara) <| -------(rayo)--------- * (datos))

                    if (Rayo.collider.CompareTag("Eje"))
                    {
                        PlayerPrefs.SetString("Eje", "yeah");
                    }
                    else
                    {
                        PlayerPrefs.DeleteKey("Eje");
                    }


                    if (Rayo.collider.name == "Xaxis")
                    {
                        //transform.Translate (VelDespl * Time.deltaTime * ( Input.GetAxis ("Mouse Y")*Mathf.Cos(Mathf.Deg2Rad*(GlobalRotation.y-90)) + Input.GetAxis ("Mouse X")*Mathf.Cos(Mathf.Deg2Rad*GlobalRotation.y))   , 0, 0);
                        Movex = true;
                    }
                    if (Rayo.collider.name == "Yaxis")
                    {
                        //transform.Translate (0 , 0, VelDespl * Time.deltaTime * ( Input.GetAxis ("Mouse Y")*Mathf.Cos(Mathf.Deg2Rad*(GlobalRotation.y)) + Input.GetAxis ("Mouse X")*Mathf.Cos(Mathf.Deg2Rad*GlobalRotation.y+90))  );
                        MoveY = true;
                    }
                    if (Rayo.collider.name == "Zaxis")
                    {
                        //transform.Translate (0 , VelDespl * Time.deltaTime * ( Input.GetAxis ("Mouse Y")*Mathf.Cos(Mathf.Deg2Rad*(GlobalRotation.x)) + Input.GetAxis ("Mouse X")*Mathf.Cos(Mathf.Deg2Rad*GlobalRotation.x+90)), 0)  ;
                        MoveZ = true;
                    }

                }
                else
                {
                    PlayerPrefs.DeleteKey("Eje");
                }
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                Movex = false;
                MoveY = false;
                MoveZ = false;
                PlayerPrefs.DeleteKey("Eje");

            }
            if (MoveY)
            {
                transform.Translate(0, 0, VelDespl * Time.deltaTime * (Input.GetAxis("Mouse Y") * Mathf.Cos(Mathf.Deg2Rad * (GlobalRotation.y)) + Input.GetAxis("Mouse X") * Mathf.Cos(Mathf.Deg2Rad * GlobalRotation.y + 90)));
            }
            if (Movex)
            {
                transform.Translate(VelDespl * Time.deltaTime * (Input.GetAxis("Mouse Y") * Mathf.Cos(Mathf.Deg2Rad * (GlobalRotation.y - 90)) + Input.GetAxis("Mouse X") * Mathf.Cos(Mathf.Deg2Rad * GlobalRotation.y)), 0, 0);
            }
            if (MoveZ)
            {
                transform.Translate(0, VelDespl * Time.deltaTime * (Input.GetAxis("Mouse Y") * Mathf.Cos(Mathf.Deg2Rad * (GlobalRotation.x)) + Input.GetAxis("Mouse X") * Mathf.Cos(Mathf.Deg2Rad * GlobalRotation.x + 90)), 0);
            }
            if (PlayerPrefs.HasKey("select") && !stop)
            {
                if (cargaPos != null)
                {
                    cargaPos.transform.position = transform.position;
                    car.LineaDeRecorrido.Clear();
                    car.GuardarDatos();
                }
            }
        }else
        {

            if (Input.touchCount > 0)
            {
                Ray R = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

                if (Input.GetTouch(0).tapCount >= 2)
                {
                    tap = true;
                }
                /// pregunta si el boton derecho del mouse es presionado
                if (Physics.Raycast(R, out Rayo, 500f) && tap)
                { // este if funciona como el rayo que se lanza y obtiene datos de quien coliciones ejemplo ( (camara) <| -------(rayo)--------- * (datos))

                    if (Rayo.collider.CompareTag("Eje"))
                    {
                        PlayerPrefs.SetString("Eje", "yeah");
                    }
                    else
                    {
                        PlayerPrefs.DeleteKey("Eje");
                    }


                    if (Rayo.collider.name == "Xaxis")
                    {
                        //transform.Translate (VelDespl * Time.deltaTime * ( Input.GetAxis ("Mouse Y")*Mathf.Cos(Mathf.Deg2Rad*(GlobalRotation.y-90)) + Input.GetAxis ("Mouse X")*Mathf.Cos(Mathf.Deg2Rad*GlobalRotation.y))   , 0, 0);
                        Movex = true;
                    }
                    if (Rayo.collider.name == "Yaxis")
                    {
                        //transform.Translate (0 , 0, VelDespl * Time.deltaTime * ( Input.GetAxis ("Mouse Y")*Mathf.Cos(Mathf.Deg2Rad*(GlobalRotation.y)) + Input.GetAxis ("Mouse X")*Mathf.Cos(Mathf.Deg2Rad*GlobalRotation.y+90))  );
                        MoveY = true;
                    }
                    if (Rayo.collider.name == "Zaxis")
                    {
                        //transform.Translate (0 , VelDespl * Time.deltaTime * ( Input.GetAxis ("Mouse Y")*Mathf.Cos(Mathf.Deg2Rad*(GlobalRotation.x)) + Input.GetAxis ("Mouse X")*Mathf.Cos(Mathf.Deg2Rad*GlobalRotation.x+90)), 0)  ;
                        MoveZ = true;
                    }
                    if (MoveY)
                    {
                        transform.Translate(0, 0, VelDespl * Time.deltaTime * (Input.GetTouch(0).deltaPosition.y * Mathf.Cos(Mathf.Deg2Rad * (GlobalRotation.y)) + Input.GetTouch(0).deltaPosition.x * Mathf.Cos(Mathf.Deg2Rad * GlobalRotation.y + 90)));
                    }
                    if (Movex)
                    {
                        transform.Translate(VelDespl * Time.deltaTime * (Input.GetTouch(0).deltaPosition.y * Mathf.Cos(Mathf.Deg2Rad * (GlobalRotation.y - 90)) + Input.GetTouch(0).deltaPosition.x * Mathf.Cos(Mathf.Deg2Rad * GlobalRotation.y)), 0, 0);
                    }
                    if (MoveZ)
                    {
                        transform.Translate(0, VelDespl * Time.deltaTime * (Input.GetTouch(0).deltaPosition.y * Mathf.Cos(Mathf.Deg2Rad * (GlobalRotation.x)) + Input.GetTouch(0).deltaPosition.x * Mathf.Cos(Mathf.Deg2Rad * GlobalRotation.x + 90)), 0);
                    }
                    if (PlayerPrefs.HasKey("select") && !stop)
                    {
                        if (cargaPos != null)
                        {
                            cargaPos.transform.position = transform.position;
                            car.LineaDeRecorrido.Clear();
                            car.GuardarDatos();
                        }
                    }
                }
                else
                {
                    PlayerPrefs.DeleteKey("Eje");

                }
            }
            else
            {
                tap = false;
                Movex = false;
                MoveY = false;
                MoveZ = false;
                PlayerPrefs.DeleteKey("Eje");
            }
        }
	}

	public void SituarEjeEnCarga (Transform Carg, Carga c)
	{
		car = c;
		cargaPos = Carg;

		transform.position = Carg.position;
	}

	public void SituarEjeEnLinea ()
	{
	}

	public void DesituarCarga ()
	{
		cargaPos = null;

	}
}
