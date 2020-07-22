using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public static bool isPlaying;
    public static bool isCheckingList;

    public GameObject gameResultGameObject;
    public Text resultText;
    public Text buyingText;

    static Text mResultText;
    static Text mBuyingText;
    static GameObject mGameResultGameObject;
    static GameObject mListGameObject;

    public enum ResultStatusEnum
    {
        win,
        insuficient,
        timerdone
    }

    ResultStatusEnum resultStatus;

    static void UpdateIsPlaying(bool pIsPlaying)
    {
        isPlaying = pIsPlaying;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        //UpdateIsPlaying(true);
        mBuyingText = buyingText;
        mResultText = resultText;
        mGameResultGameObject = gameResultGameObject;
    }

    public static void PauseGame(bool pIsCheckingList)
    {
        UpdateIsPlaying(false);
        isCheckingList = pIsCheckingList;
    }

    public static void StartGame()
    {
        //mListGameObject.SetActive(false);
        UpdateIsPlaying(true);
    }

    public static void GameFinish(ResultStatusEnum pResultStatus, string pResult = "")
    {
        mGameResultGameObject.SetActive(true);
        PauseGame(false);

        switch(pResultStatus)
        {
            case ResultStatusEnum.win:
                mResultText.text = "YOU GOT: \n" + pResult;
                break;
            case ResultStatusEnum.insuficient:
                mResultText.text = "YOU GOT: \n" + pResult + "\n" + "Did not meet requirement";
                 break;
            case ResultStatusEnum.timerdone:
                mResultText.text = "Time Ran Out, \n Try Again";
                break;
        }
    }
    public static void ResumeGame()
    {
        
        UpdateIsPlaying(true);
        isCheckingList = false;
        //mListGameObject.SetActive(false);

    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
