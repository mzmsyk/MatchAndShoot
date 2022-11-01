using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public int _score;
    int totalScore=0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        totalScore = 0;
        Time.timeScale = 0;
    }
    public void LevelFailed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Time.timeScale = 1;

    }
    public void LevelNext(int score)
    {
        totalScore = score+totalScore;
        Debug.Log(totalScore);
        if (_score==totalScore)
        {
            StartCoroutine(LevelNextDelay());
        }
    }
    IEnumerator LevelNextDelay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("bitti");
    }
}
