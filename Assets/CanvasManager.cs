using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasManager : MonoBehaviour
{
    public GameObject listGameObject;
    public GameObject startBuyingButton;
    public GameObject resumeBuyingButton;
    public float maxTimer;
    float counter;
    bool shownList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenList()
    {
        counter = 0;
        shownList = true;
        listGameObject.SetActive(true);
        GameManagerScript.PauseGame(true);
    }

    public void HideList(bool pIsFreshStart)
    {
        counter = 0;
        shownList = false;
        listGameObject.SetActive(false);
        ShowResumeBuying();
        if (pIsFreshStart)
            GameManagerScript.StartGame();
        else
            GameManagerScript.ResumeGame();
    }

    public void ShowResumeBuying()
    {
        resumeBuyingButton.SetActive(true);
        startBuyingButton.SetActive(false);
    }
    private void Update()
    {
        //if (shownList)
        //{
        //    counter += Time.deltaTime;
        //    if (counter >= maxTimer)
        //    {
        //        HideList();
        //    }
        //}
    }
}
