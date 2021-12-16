using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_UI : MonoBehaviour
{
    [SerializeField]
    private Animator transition;

    public float transitionTime = 1f;
    public void OnClickPlay()
    {
       StartCoroutine( loadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void OnClickQuit()
    {
        //Debug.Log("You have Quit");
        Application.Quit();
    }

    IEnumerator loadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);

    }
}
