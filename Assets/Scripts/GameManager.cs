using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    GameObject startButton,endPanel,playerOrange,playerPink;

    [SerializeField]
    TMP_Text playerScoreText, AIScoreText, winText;

    int playerScore, AIScore;


    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        Time.timeScale = 1f;
        playerScore = 0;
        AIScore = 0;
        playerScoreText.text = (playerScore > 9 ? "" : "0") + playerScore.ToString();
        AIScoreText.text = (AIScore > 9 ? "" : "0") + AIScore.ToString();
        startButton.SetActive(true);
        endPanel.SetActive(false);
        playerOrange.GetComponent<Player>().canMove = false;
        playerPink.GetComponent<Player>().canMove = false;
    }

    public void StartGame()
    {
        startButton.SetActive(false);
        playerOrange.GetComponent<Player>().canMove = true;
        playerPink.GetComponent<Player>().canMove = true;
    }

    public void UpdateScore(bool isPlayer)
    {
        if(isPlayer)
        {
            playerScore++;
            playerScoreText.text = (playerScore > 9 ? "" : "0") + playerScore.ToString();
            if (playerScore == 15)
                GameFinished(isPlayer);
        }
        else
        {
            AIScore++;
            AIScoreText.text = (AIScore> 9 ? "" : "0") + AIScore.ToString();
            if (AIScore == 15)
                GameFinished(isPlayer);
        }
    }

    public void GameFinished(bool isPlayer)
    {
        winText.text = (isPlayer ? "Pink" : "Orange") + " Wins!";
        endPanel.SetActive(true);
        playerOrange.GetComponent<Player>().canMove = false;
        playerPink.GetComponent<Player>().canMove = false;
        Time.timeScale = 0f;
    }

    public void GameQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void GameRestart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
