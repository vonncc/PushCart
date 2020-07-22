using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouchManager : MonoBehaviour
{

    public Transform cameraTransform;
    public Transform cameraTransform3rdPerson;
    public PlayerMovement playerMovement;
    Vector2 startTouch;
    Vector2 endTouch;

    Vector2 positionToCompute;


    [System.Serializable]
    public class TouchEventSomething : UnityEvent<TappedSideEnum> { }

    public TouchEventSomething touchDone;
    void UpdateTouchVariables(ref Vector2 pPosition)
    {
        if (GameManagerScript.isPlaying == true)
        {
            pPosition = Input.mousePosition;
        }
    }
    public void OnTouchBegan()
    {
        //print("BEGAN");
        UpdateTouchVariables(ref startTouch);
        //if (pTappedSideEnum)
        TappedSideEnum tpSide;
        if (GameManagerScript.isPlaying == true)
        {
            if (startTouch.x >= Screen.width / 2)
            {
                tpSide = TappedSideEnum.right;
            }
            else
            {
                tpSide = TappedSideEnum.left;
            }

            touchDone.Invoke(tpSide);
        }

        //if (startTouch.x)
        //startTouch = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //print(Input.mousePosition);
    }

    public void OnTouchEnded()
    {
        //print("ENDED");
        UpdateTouchVariables(ref endTouch);

        //cameraTransform.localEulerAngles = new Vector3(0, 0, 0);
        //cameraTransform3rdPerson.localEulerAngles = new Vector3(cameraTransform3rdPerson.localEulerAngles.x, 0, cameraTransform3rdPerson.localEulerAngles.z);
        float touchXDelta = Mathf.Abs(startTouch.x - endTouch.x);
        if (touchXDelta > 10f)
        {
            if (endTouch.x > startTouch.x)
            {
                playerMovement.RotatePlayer(PlayerMovement.DirectionToFace.right);
            }
            else
            {
                playerMovement.RotatePlayer(PlayerMovement.DirectionToFace.left);
            }
        }
        //touchDone.Invoke();
        //print(Input.mousePosition);


    }

    public void OnDragHold()
    {
        //lineRenderer.SetPosition(1, );

        //float tenTX = Input.mousePosition.x - startTouch.x;
        //float tenTY = Input.mousePosition.y - startTouch.y;
        //float distance = Mathf.Sqrt(Mathf.Pow(tenTX, 2) + Mathf.Pow(tenTY, 2));
        //float directionFacer = 1;
        //if (Input.mousePosition.x < startTouch.x)
        //{
        //    directionFacer = -1;
        //}

        //float maximumValue = 100;
        //float lineLength = Mathf.Clamp(Mathf.Abs(distance), 0, maximumValue);
        //float getPercentage = lineLength / maximumValue;
        //print(getPercentage);
        //cameraTransform.localEulerAngles = new Vector3(0, getPercentage * 60 * directionFacer, 0);
        //cameraTransform3rdPerson.localEulerAngles = new Vector3(cameraTransform3rdPerson.localEulerAngles.x, getPercentage * 30 * directionFacer, cameraTransform3rdPerson.localEulerAngles.z);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //lineRenderer.SetPosition(0, );

        
        //print(Time.timeScale);
    }
}
