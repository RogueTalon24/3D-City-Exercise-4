using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameras : MonoBehaviour
{
    public Camera[] cameras = new Camera[4];
    public bool changeAudioListener = true;

    // Start is called before the first frame update
    void Start()
    {
        EnableCamera(cameras[0], true);
        EnableCamera(cameras[1], false);
        EnableCamera(cameras[2], false);
        EnableCamera(cameras[3], false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            EnableCamera(cameras[0], true);
            EnableCamera(cameras[1], false);
            EnableCamera(cameras[2], false);
            EnableCamera(cameras[3], false);
        }
        else
        if (Input.GetKeyDown(KeyCode.G))
        {
            EnableCamera(cameras[0], false);
            EnableCamera(cameras[1], true);
            EnableCamera(cameras[2], false);
            EnableCamera(cameras[3], false);
        }
        else
        if (Input.GetKeyDown(KeyCode.H))
        {
            EnableCamera(cameras[0], false);
            EnableCamera(cameras[1], false);
            EnableCamera(cameras[2], true);
            EnableCamera(cameras[3], false);
        }
        else
        if (Input.GetKeyDown(KeyCode.J))
        {
            EnableCamera(cameras[0], false);
            EnableCamera(cameras[1], false);
            EnableCamera(cameras[2], false);
            EnableCamera(cameras[3], true);
        }
    }

    private void EnableCamera(Camera cam, bool enabledStatus)
    {
        cam.enabled = enabledStatus;
        if (changeAudioListener)
            cam.GetComponent<AudioListener>().enabled =  enabledStatus;
    }
}
