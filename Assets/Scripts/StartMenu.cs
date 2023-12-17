using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    //navigate to Image Tracking AR Scene
    public void ImageFilterScene()
    {
		SceneManager.LoadScene ("BlankAR");
    }

    //navigate to FaceFilterMenu Scene
    public void FaceFilterMenuScene()
    {
        SceneManager.LoadScene("FiltersMenu");
    }

    //for exiting the Game
    public void QuitGame()
    {
        Application.Quit();
    }
}
