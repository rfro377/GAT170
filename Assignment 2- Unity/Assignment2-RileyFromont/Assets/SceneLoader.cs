using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneLoader : MonoBehaviour
{

    public Animator transition;
    public InputActionReference pause;

    public Canvas pausescreen;
    
    public float transitionwait = 0.95f;
    public void SceneLoad(int Sceneindex)
    {
        StartCoroutine(LoadLevel(Sceneindex));
    }
    // Start is called before the first frame update
    void Start()
    {
       
        if (SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void Resume()
    {
        pausescreen.gameObject.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator LoadLevel(int sceneindex)
    {
        
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionwait);

        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneindex);
    }
}
