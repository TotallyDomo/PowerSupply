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
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
            ChangeToCore();

        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
            ChangeToWater();

        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
            ChangeToWaste();
    }

    void ToggleCameras(bool core, bool water, bool waste)
    {
        CoreCam.gameObject.SetActive(core);
        WaterCam.gameObject.SetActive(water);
        WasteCam.gameObject.SetActive(waste);
    }

    void ChangeToCore()
    {
        ToggleCameras(true, false, false);
        LowerCam.texture = WaterImage;
        UpperCam.texture = WasteImage;
    }

    void ChangeToWater()
    {
        ToggleCameras(false, true, false);
        LowerCam.texture = CoreImage;
        UpperCam.texture = WasteImage;
    }

    void ChangeToWaste()
    {
        ToggleCameras(false, false, true);
        LowerCam.texture = CoreImage;
        UpperCam.texture = WaterImage;
    }

    void ChangeCamera(Texture temp)
    {
        if (temp == CoreImage)
            ChangeToCore();
        else if (temp == WaterImage)
            ChangeToWater();
        else if (temp == WasteImage)
            ChangeToWaste();
    }

    public void ChangeToLowerCamera() => ChangeCamera(LowerCam.texture);

    public void ChangeToUpperCamera() => ChangeCamera(UpperCam.texture);
}
