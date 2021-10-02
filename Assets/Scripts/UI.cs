using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    const string SOURCE_URL = "https://github.com/TotallyDomo/PowerSupply";

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void LoadCoreScene() => SceneManager.LoadScene(1);

    public void LoadMainMenu() => SceneManager.LoadScene(0);

    public void OnSourceClick() => Application.OpenURL(SOURCE_URL);

}
