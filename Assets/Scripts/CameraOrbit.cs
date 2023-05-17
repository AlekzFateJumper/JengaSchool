using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour {

    public GameObject Alvo;
    public int Tempo;

    private float VelocidadeHorizontal = 100f;
    private float VelocidadeVertical = 60f;

    void Update ()
    {
        transform.LookAt(Alvo.transform);
        if(Input.GetMouseButton(0)){
            float zs = Mathf.Sign(transform.position.z);
            var VelHorizontal = VelocidadeHorizontal * Input.GetAxis("Mouse X");
            var VelVertical = VelocidadeVertical * Input.GetAxis("Mouse Y") * zs;
            if( transform.position.y > 1.5f || ( zs * VelVertical < 0 )){
                transform.RotateAround(Alvo.transform.position, new Vector3(VelVertical, VelHorizontal, 0), Tempo * Time.deltaTime);
            }
        }
    }
}
