using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebCamera : MonoBehaviour
{
    WebCamTexture camTexture;
    public Image image;
    public RawImage rawImage;
    public Material material;
    /*public string[] devicesNames { get {
            WebCamDevice[] devices = WebCamTexture.devices;
            for (int i = 0; i < devices.Length; i++)
                devicesNames[i] = devices[i].name;
            Debug.Log("public string[] devicesNames");
            return devicesNames; 
        } private set { } }

    */

    void Start()
    {
            /*WebCamDevice[] devices = WebCamTexture.devices;
            for (int i = 0; i < devices.Length; i++)
                Debug.Log(devices[i].name);*/
        //camTexture = new WebCamTexture();
        
            //Debug.Log(camTexture.deviceName);
        //camTexture.deviceName = "Microsoft Modern Webcam";
            //image.material.mainTexture = camTexture;
        //rawImage.material.mainTexture = camTexture;
        //rawImage.texture = camTexture;
           // GetComponent<Renderer>().material.mainTexture = camTexture;
           //material.mainTexture = camTexture;

        //camTexture.Play();
    }

    void Update()
    {
        
    }
}
