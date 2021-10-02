using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    RenderTexture CoreImage, WaterImage, WasteImage;

    [SerializeField]
    RawImage LowerCam, UpperCam;

    [SerializeField]
    Camera CoreCam, WaterCam, WasteCam;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ToggleCameras(true, false, false);
            LowerCam.texture = WaterImage;
            UpperCam.texture = WasteImage;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ToggleCameras(false, true, false);
            LowerCam.texture = CoreImage;
            UpperCam.texture = WasteImage;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ToggleCameras(false, false, true);
            LowerCam.texture = CoreImage;
            UpperCam.texture = WaterImage;
        }
    }

    void ToggleCameras(bool core, bool water, bool waste)
    {
        CoreCam.gameObject.SetActive(core);
        WaterCam.gameObject.SetActive(water);
        WasteCam.gameObject.SetActive(waste);
    }
}
