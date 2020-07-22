using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public UnityEngine.UI.Text pText;
    public float speed = 1f;

    bool canRotate;
    bool doRotate;
    Vector3 rotateTarget;
    Vector3 referenceRotation;
    public enum DirectionToFace
    {
        left, right
    };

    public enum MovementModifier
    {
        forward,
        backward,
        reset
    }

    float movementModif;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    //Transform mTransform;
    // Start is called before the first frame update
    void Start()
    {
        canRotate = true;
        referenceRotation = new Vector3(0, 0, 0);
        rotateTarget = transform.eulerAngles;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AisleWhole")
        {
            UpdatePlayerRotate(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "AisleWhole")
        {
            UpdatePlayerRotate(true);
        }
    }

    public void UpdatePlayerRotate(bool pCanRotate)
    {
        canRotate = pCanRotate;
    }

    public void RotatePlayer(DirectionToFace pDirection)
    {
        if (canRotate == true)
        {
            doRotate = true;
            int directionToMove = 1;
            switch (pDirection)
            {
                case DirectionToFace.left:
                    directionToMove = -1;
                    break;
                case DirectionToFace.right:
                    directionToMove = 1;
                    break;
            }
            rotateTarget += new Vector3(0, 90 * directionToMove, 0);
        }
    }

    public void ModifySpeed(MovementModifier pModifier)
    {
        switch (pModifier)
        {
            case MovementModifier.forward:
                //directionToMove = -1;
                movementModif = 5f;
                break;
            case MovementModifier.backward:
                //directionToMove = 1;
                movementModif = -3f;
                break;
            case MovementModifier.reset:
                //directionToMove = 1;
                movementModif = 0;
                break;
        }
    }


    void AccelerometerDetect()
    {
        if (Input.acceleration.z > 0.5f)
        {
            ModifySpeed(MovementModifier.forward);
        }
        else if (Input.acceleration.z < -0.5f)
        {
            ModifySpeed(MovementModifier.backward);
        } else
        {
            ModifySpeed(MovementModifier.reset);
        }

        if (canRotate == true)
        {
            if (doRotate == false)
            {

                if (Input.acceleration.x > 0.5f)
                {
                    RotatePlayer(DirectionToFace.right);
                }
                else if (Input.acceleration.x < -0.5f)
                {
                    RotatePlayer(DirectionToFace.left);
                }

            }
            else
            {
                if (Input.acceleration.x < 0.5f && Input.acceleration.x > -0.5f)
                {
                    doRotate = false;
                }
            }
        }
        
    }

    float ComputeRotationDistance(float pd1, float pd2)
    {
        if (pd1 > pd2)
        {
            return pd1 - pd2;
        } else
        {
            return pd2 - pd1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        pText.text = Input.acceleration.ToString();
        if (GameManagerScript.isPlaying == true)
        {
            transform.position += (transform.forward * (speed + movementModif)) * Time.deltaTime;

#if UNITY_EDITOR || UNITY_STANDALONE
            if (Input.GetKeyDown(KeyCode.A))
                RotatePlayer(DirectionToFace.left);
            else if (Input.GetKeyDown(KeyCode.D))
                RotatePlayer(DirectionToFace.right);

            if (Input.GetKeyDown(KeyCode.W))
                ModifySpeed(MovementModifier.forward);
            else if (Input.GetKeyUp(KeyCode.W))
                ModifySpeed(MovementModifier.reset);

            if (Input.GetKeyDown(KeyCode.S))
                ModifySpeed(MovementModifier.backward);
            else if (Input.GetKeyUp(KeyCode.S))
                ModifySpeed(MovementModifier.reset);
#else
            //AccelerometerDetect();
#endif



            //if (doRotate)
            //{
            //transform.eulerAngles = Vector3.RotateTowards(transform.eulerAngles, Vector3.down * 90, 5f, 5f);



            referenceRotation = Vector3.Slerp(referenceRotation, rotateTarget, .25f);
                transform.eulerAngles = referenceRotation;
                //print(Vector3.Distance(transform.eulerAngles, rotateTarget));
                float angleDirection = ComputeRotationDistance(Mathf.Abs(rotateTarget.y), Mathf.Abs(transform.eulerAngles.y));

                
                //print("HEY");
                //print(Mathf.Abs(rotateTarget.y));
                //print(Mathf.Abs(transform.eulerAngles.y));
                //print(angleDirection);

            //}

            //print(doRotate);
            //print(Vector3.down * 100);

        }
    }
}
