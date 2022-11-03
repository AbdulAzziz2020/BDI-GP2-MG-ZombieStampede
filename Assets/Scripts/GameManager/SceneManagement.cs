using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{
    public Animator anim;
    public float transitionDelay;
    public GameObject crossHair;
    
    public void LoadScene(string sceneName)
    { 
        DataCounter.score = 0;
        StartCoroutine(Transition());

        IEnumerator Transition()
        {
            anim.SetTrigger("Fade");

            yield return new WaitForSeconds(transitionDelay);
            
            SceneManager.LoadScene(sceneName);
        }
    }
    
#if UNITY_STANDALONE
    private void Update()
    {
        PointerUtility();
    }
#endif
    
    public void PointerUtility()
    {
        Cursor.visible = GameManager.Instance.isGameOver ? true : false;
        crossHair.SetActive(GameManager.Instance.isGameOver ? false : true);
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        crossHair.transform.position = mousePosition;
    }
}
