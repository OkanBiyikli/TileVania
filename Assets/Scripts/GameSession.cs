using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int score = 0;
    
        //  OYUNCUYA 3 CAN VERDİK, HER ÖLDÜĞÜNDE CANI BİTENE KADAR BULUNDUĞU BÖLÜMDE YENİDEN DOĞUYOR, CANLARI BİTTİĞİNDE İSE EN BAŞTAN.
    [SerializeField] int playerLives = 3;
    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start() 
    {
        livesText.text = playerLives.ToString();    
        scoreText.text = score.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    public void AddToScore (int pointstoAdd)
    {
        score += pointstoAdd;
        scoreText.text = score.ToString(); //coinpickup kısmına bunu eklememiz gerekiyor ama hata alıyorz..
    }


    void TakeLife()
    {
        playerLives = playerLives -1; //playerLives--; de diyebiliriz
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = playerLives.ToString(); 
    }

    void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

}
