using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FiltersMenu : MonoBehaviour
{

	//navigate to MaterialFilter Scene
	public void MaterialFilterScene(){
		SceneManager.LoadScene ("MaterialFilter");
	}

	//navigate to TextureFilter Scene
	public void TextureFilterScene(){
		SceneManager.LoadScene ("TextureFilter");
	}

	//navigate to FaceObjectFilter Scene
	public void FaceObjectFilterScene(){
		SceneManager.LoadScene ("ObjectFilter");
	}

	//navigate to StartMenu Scene
	public void BackMenu() {
		SceneManager.LoadScene ("StartMenu");
	}

}
