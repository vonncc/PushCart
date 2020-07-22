using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAisleDetectorScript : MonoBehaviour
{
    public TappedSideEnum colliderSide;


    Rigidbody mRigidybody;

    AisleEnum collidedAisle;
    //AisleEnum collidedAisleRight;

    List<AisleEnum> itemCollected;

    AisleEnum itemHoldCheck;

    public delegate void AisleCheckInsert();
    // Start is called before the first frame update
    void Start()
    {
        mRigidybody = GetComponent<Rigidbody>();
        //collidedAisleLeft = new List<AisleEnum>();
        //collidedAisleRight = new List<AisleEnum>();
        itemCollected = new List<AisleEnum>();
    }


    void DoOnHit(Collider pOther)
    {
        //switch (colliderSide)
        //{
        //    case TappedSideEnum.left:
        //        //collidedAisleLeft.Add(pOther.GetComponent<AisleChecker>().GetValue());
        //        collidedAisleLeft = pOther.GetComponent<AisleChecker>().GetValue();
        //        break;
        //    case TappedSideEnum.right:
        //        collidedAisleRight = pOther.GetComponent<AisleChecker>().GetValue();
        //        //collidedAisleRight.Add(pOther.GetComponent<AisleChecker>().GetValue());
        //        break;
        //}
        if (pOther.tag != "Cashier")
            collidedAisle = pOther.GetComponent<AisleChecker>().GetValue();
    }

    void DoOnExit(Collider pOther)
    {
        //switch (colliderSide)
        //{
        //    case TappedSideEnum.left:
        //        //collidedAisleLeft.Remove(pOther.GetComponent<AisleChecker>().GetValue());
        //        break;
        //    case TappedSideEnum.right:
        //        //collidedAisleRight.Remove(pOther.GetComponent<AisleChecker>().GetValue());
        //        break;
        //}
        if (pOther.tag != "Cashier")
            collidedAisle = AisleEnum.nothing;
    }

    private void OnTriggerEnter(Collider other)
    {
        //print("pasok");
        DoOnHit(other);
    }

    private void OnTriggerExit(Collider other)
    {

        //print("alis");
        DoOnExit(other);
    }

    public AisleEnum Tapped(TappedSideEnum pTappedByUser)
    {
        return collidedAisle;

       
        //switch (pTappedByUser)
        //{
        //    case TappedSideEnum.left:
        //        itemCollected.Add(collidedAisle);
        //        break;
        //    case TappedSideEnum.right:
        //        break;
        //}
    }

    public void TappedRight()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
