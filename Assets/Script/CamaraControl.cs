using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamaraControl : MonoBehaviour {
	private Camera Cam;
	public Transform CentroSecundario;
	public float Sensibility_Y, Sensibility_X;
	public float Sensibility_deplazamiento;
	public float SensibilityScroll;
	public Vector3 Euler,LocarlEuler;
    public static bool modo_android;
	// Use this for initialization
	void Start () {
		Cam = Camera.main;
        modo_android = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!PlayerPrefs.HasKey ("Eje") || modo_android) {
			Euler = transform.eulerAngles;
			LocarlEuler = transform.localEulerAngles;
			Cam.transform.Translate (0, 0, SensibilityScroll * Time.deltaTime * Input.mouseScrollDelta.y);
            if (!modo_android) {
                if (Input.GetKey(KeyCode.Mouse0) && !Input.GetKey(KeyCode.LeftShift)) {

                    transform.Rotate(0, Sensibility_X * Time.deltaTime * Input.GetAxis("Mouse X") * 40, 0, Space.World);
                    transform.Rotate(0, 0, Sensibility_X * Time.deltaTime * Input.GetAxis("Mouse Y") * 40, Space.Self);
                }
                if (Input.GetKey(KeyCode.Mouse0) && Input.GetKey(KeyCode.LeftShift)) {
                    transform.Translate(0, Time.deltaTime * Input.GetAxis("Mouse Y") * Sensibility_deplazamiento, 0, Space.World);
                    transform.Translate(0, 0, Input.GetAxis("Mouse X") * Sensibility_deplazamiento * Time.deltaTime, Space.Self);

                }
                if (Input.GetKeyDown(KeyCode.R)) {
                    transform.position = Vector3.zero;
                }
            }
            else {

                Debug.Log("Touch Count:" + Input.touchCount);
                if (Input.touchCount > 0 && Input.touchCount < 2) {
                    transform.Rotate(0, Sensibility_X * Time.deltaTime * Input.GetTouch(0).deltaPosition.x * 4, 0, Space.World);
                    transform.Rotate(0, 0, Sensibility_X * Time.deltaTime * Input.GetTouch(0).deltaPosition.y * 4, Space.Self);
                } else if (Input.touchCount > 1 && Input.touchCount < 3) {

                    Cam.transform.Translate(0, 0, SensibilityScroll * Time.deltaTime * Input.GetTouch(1).deltaPosition.x);
                    Cam.transform.Translate(0, 0, SensibilityScroll * Time.deltaTime * Input.GetTouch(1).deltaPosition.y);
                    Cam.transform.Translate(0, 0, SensibilityScroll * Time.deltaTime * Input.GetTouch(2).deltaPosition.y);
                    Cam.transform.Translate(0, 0, SensibilityScroll * Time.deltaTime * Input.GetTouch(2).deltaPosition.x);


                } else if (Input.touchCount > 2) {

                    transform.Translate(0, Sensibility_X * Time.deltaTime * Input.GetTouch(2).deltaPosition.y, 0, Space.World);
                    transform.Translate(0, 0, Sensibility_X * Time.deltaTime * Input.GetTouch(2).deltaPosition.x, Space.Self);

                }
			}
		}
		if (Input.GetKey (KeyCode.P)) {
			
			SceneManager.LoadScene ("Exposicion");
		
		}
	}
}
