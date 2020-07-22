using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopeManager : MonoBehaviour
{
    public UnityEngine.UI.Text statusText;
    public UnityEngine.UI.Text compassText;

    public Transform platform;
    public Transform compassHead;
    bool gyroEnabled;
    bool acceloEnabled;
    bool compassEnabled;
    Gyroscope mGyroscope;
    
    Compass mCompass;
    Quaternion rotation;

    bool CheckGyroscope()
    {
        mGyroscope = Input.gyro;
        mGyroscope.enabled = true;
        if (SystemInfo.supportsGyroscope)
        {
            compassText.text = "Gyro Enabled";
            mGyroscope = Input.gyro;
            mGyroscope.enabled = true;
            return true;
        }
        //statusText.text = "Device doesn't support Gyroscope";
        return true;
    }

    bool CheckCompass()
    {
        //Input.acce
        compassText.text = "Compass Enabled";
        mCompass = Input.compass;
        Input.location.Start();
        mCompass.enabled = true;
        return true;
      
    }

    bool CheckAccel()
    {

        if (SystemInfo.supportsAccelerometer)
        {
            compassText.text = "Accelerometer Enabled";
            return true;
        }
        //statusText.text = "Device doesn't support Accelerometer";
        return false;
    }
    // Start is called before the first frame update
    void Start()
    {
        gyroEnabled = CheckGyroscope();
        compassEnabled = CheckCompass();
        acceloEnabled = CheckAccel();
        rotation = new Quaternion(0, 0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (gyroEnabled)
        {
            statusText.text = mGyroscope.attitude.ToString();
            platform.rotation = mGyroscope.attitude * rotation;
        }

        //if (compassEnabled)
        //{
        //    statusText.text = mCompass.rawVector.ToString();
        //    Vector3 rawVector = new Vector3(
        //        Mathf.Abs(mCompass.rawVector.x),
        //        Mathf.Abs(mCompass.rawVector.y),
        //        Mathf.Abs(mCompass.rawVector.z)
        //        );
        //    platform.rotation = Quaternion.Euler(rawVector) * rotation;
        //    compassHead.rotation = Quaternion.Euler(0, -mCompass.magneticHeading, 0);
        //}

        //if (acceloEnabled)
        //{
        //    Vector3 vec3 = Vector3.zero;
        //    vec3.x = Input.acceleration.x;
        //    vec3.y = -Input.acceleration.y;
        //    vec3.z = Input.acceleration.z;

        //    if (vec3.sqrMagnitude > 1)
        //        vec3.Normalize();

        //    statusText.text = vec3.ToString();
        //    statusText.text = Input.acceleration.ToString();
        //}
    }
}
