using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{
    public Animator anim;
    public float transitionDelay;
    
    public void LoadScene(string sceneName)
    {
        StartCoroutine(Transition());

        IEnumerator Transition()
        {
            anim.SetTrigger("Fade");

            yield return new WaitForSeconds(transitionDelay);
            
            SceneManager.LoadScene(sceneName);
        }
    }
}
