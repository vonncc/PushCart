using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerAction : MonoBehaviour
{

    public Text alcoholText;
    public Text cannedGoodsText;
    public Text waterText;
    public Text tissueText;

    public Text sampleThings;

    public PlayerAisleDetectorScript playerAisleDetectorLeft;
    public PlayerAisleDetectorScript playerAisleDetectorRight;

    List<AisleEnum> collectedItems;

    int totalItems;
    int alcoholCounter;
    int cannedgoodCounter;
    int tissueCounter;
    int waterCounter;

    int alcoholRequirement;
    int cannedgoodRequirement;
    int tissueRequirement;
    int waterRequirement;

    bool didWin;

    // to be modified
    int SAMPLE1;
    int SAMPLE2;
    int SAMPLE3;
    int SAMPLE4;

    void ToBeUpdated(ref int pToBeUpdated)
    {
        pToBeUpdated = Random.Range(1, 5);
    }
    // Start is called before the first frame update
    void Start()
    {
        collectedItems = new List<AisleEnum>();
        ToBeUpdated(ref alcoholRequirement);
        ToBeUpdated(ref cannedgoodRequirement);
        ToBeUpdated(ref tissueRequirement);
        ToBeUpdated(ref waterRequirement);

        sampleThings.text = "Things To Buy:\n \n" + "Alcohol: " + alcoholRequirement.ToString()
            + "\nCanned Goods: " + cannedgoodRequirement.ToString()
            + "\nWater: " + waterRequirement.ToString()
            + "\nTissue: " + tissueRequirement.ToString();

    }

    void ToBeModified(Text pText, int value, int maxrequirement)
    {

    }
    void CheckIfNothingIsHit(AisleEnum pAisleEnum)
    {
        if (pAisleEnum != AisleEnum.nothing)
        {
            collectedItems.Add(pAisleEnum);
            switch (pAisleEnum)
            {
                case AisleEnum.alcohol:
                    SAMPLE1 += 1;
                    break;
                case AisleEnum.cannedgoods:
                    SAMPLE2 += 1;
                    break;
                case AisleEnum.water:
                    SAMPLE3 += 1;
                    break;
                case AisleEnum.tissue:
                    SAMPLE4 += 1;
                    break;
            }

            // to be modified
            alcoholText.text = "Alcohol: " + SAMPLE1.ToString();
            cannedGoodsText.text = "Canned Goods: " + SAMPLE2.ToString();
            waterText.text = "Water: " + SAMPLE3.ToString();
            tissueText.text = "Tissue: " + SAMPLE4.ToString();
        }
    }
    public void CheckSideTouched(TappedSideEnum pTapped)
    {
        switch(pTapped)
        {
            case TappedSideEnum.left:
                CheckIfNothingIsHit(playerAisleDetectorLeft.Tapped(pTapped));
                break;
            case TappedSideEnum.right:
                CheckIfNothingIsHit(playerAisleDetectorRight.Tapped(pTapped));
                break;
        }
        
        
    }

    void ToBeModifiedFunc(Text pText, int value, int maxrequirement, string pHaha)
    {
        //pText.text = pHaha + ": " + value.ToString();
    }
    void CounterAdder(ref int pToBeUpdated, int pRequirement, Text pSampText,AisleEnum pSomething)
    {
        pToBeUpdated += 1;
        ToBeModifiedFunc(pSampText, pToBeUpdated, pRequirement, pSomething.ToString());
        didWin = false;
        if (pToBeUpdated == pRequirement)
        {
            didWin = true;
        }

    }

    bool Checker(int n1, int n2)
    {
        return n1 == n2;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cashier")
        {
            for (int i = 0; i < collectedItems.Count; i++)
            {
                switch(collectedItems[i])
                {
                    case AisleEnum.alcohol:
                        CounterAdder(ref alcoholCounter, alcoholRequirement, alcoholText, collectedItems[i]);
                        break;
                    case AisleEnum.cannedgoods:
                        CounterAdder(ref cannedgoodCounter, cannedgoodRequirement, cannedGoodsText, collectedItems[i]);
                        break;
                    case AisleEnum.tissue:
                        CounterAdder(ref tissueCounter, tissueRequirement, tissueText, collectedItems[i]);
                        break;
                    case AisleEnum.water:
                        CounterAdder(ref waterCounter, waterRequirement, waterText, collectedItems[i]);
                        break;
                }
            }

            string forResult = "\n" + "Alcohol: " + alcoholCounter.ToString() + " / " + alcoholRequirement.ToString() +
                "\nCanned Goods: " + cannedgoodCounter.ToString() + " / " + cannedgoodRequirement.ToString() +
                "\nWater: " + waterCounter.ToString() + " / " + waterRequirement.ToString() +
                "\nTissue: " + tissueCounter.ToString() + " / " + tissueRequirement.ToString();
            

            if (didWin == true)
            {
                print("WINNER");
                GameManagerScript.GameFinish(GameManagerScript.ResultStatusEnum.win, forResult);
            } else
            {
                print("EXCEED or INSUFFICIENT");
                GameManagerScript.GameFinish(GameManagerScript.ResultStatusEnum.insuficient, forResult);


            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
