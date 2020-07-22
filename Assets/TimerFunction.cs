using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerFunction : MonoBehaviour
{
    UnityEngine.UI.Text timerText;
    private float timerCounter;
    // Start is called before the first frame update
    void Start()
    {
        timerCounter = 60;
        timerText = GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManagerScript.isPlaying || GameManagerScript.isCheckingList == true)
        {
            timerCounter -= Time.deltaTime;
            timerText.text = "TIMER " + (Mathf.Ceil(timerCounter * 100) / 100).ToString();
            if (timerCounter <= 0)
            {
                timerText.text = "TIMER 0";
                GameManagerScript.GameFinish(GameManagerScript.ResultStatusEnum.timerdone);
            }
        }
        
    }
}
