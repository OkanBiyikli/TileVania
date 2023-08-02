using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelExit : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
          StartCoroutine(LoadNextLevel());        //ÖNCELİKLE TRIGGERIMIZI GİRİYORUZ
        }
    }

    IEnumerator LoadNextLevel()  //BURADA YAPTIĞIMIZ ŞEY DELAYLI Bİ ŞEKİLDE BÖLÜM GEÇİŞİ 
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;   
        int nextSceneIndex = currentSceneIndex + 1;

        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings) 
        {
            nextSceneIndex = 0;         //EĞER BÖLÜMLER BİTERSE BAŞA ATIYOR
        }
        
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(nextSceneIndex);
    }

    void LevelCheating()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene(2);
        }
    }
}
