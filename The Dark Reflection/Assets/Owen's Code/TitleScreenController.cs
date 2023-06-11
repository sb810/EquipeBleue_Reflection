using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    public string sceneToLoad; // The name of the scene to load when transitioning from the title screen

    public void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad); // Load the specified scene
    }

    public void QuitGame()
    {
        Application.Quit(); // Quit the application
    }
}
