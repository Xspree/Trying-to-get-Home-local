using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{
    [SerializeField]
    private Animator transition;

    public float transitionTime = 1f;

    public void onNextClicked()
    {
        //Load next level
        StartCoroutine(loadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void onBackClicked()
    {
        //Take Player back to main page.
        StartCoroutine(loadLevel(0)); ;
    }

    IEnumerator loadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
        

    }
    
    
}
