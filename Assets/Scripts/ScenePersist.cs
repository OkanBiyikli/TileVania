using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePersist : MonoBehaviour
{
        //BU KISIM CANIMIZ BİTENE KADAR BÖLÜMDE KALDIĞIMIZ YERDEN DEVAM ETMEMİZİ VE
        //TOPLADIĞIMIZ PARALAR VE ÖLDÜRDÜĞÜMÜZ DÜŞMANLARIN CANIMIZ TAMAMEN BİTENE KADAR
        //YENİDEN DOĞMAMASINI SAĞLIYOR..
 
 void Awake()
    {
        int numScenePersists = FindObjectsOfType<ScenePersist>().Length;
        if (numScenePersists > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ResetScenePersist()
    {
        Destroy(gameObject);
    }
}
