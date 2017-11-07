using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class ArrowFiring : MonoBehaviour {

    // Use this for initialization
    public int powerNum = 0;
    public Text info;
    public GameObject myo = null;
    //public Vector3 charging = new Vector3(0, 1, 0);
    public Vector3 force = new Vector3(0, 0, 0);
    public int flag = 0;
    public Transform spawnPoint;

    private Rigidbody rigBod;
    private ThalmicMyo thalmicMyo;

    // Update is called once per frame
    void Start () {
        thalmicMyo = myo.GetComponent<ThalmicMyo>();
        rigBod = GetComponent<Rigidbody>();
        rigBod.useGravity = false;
        info.text = "welcome my archer.";
        //enabled = false;


        //else if(thalmicMyo.pose == Pose.Rest)
    }

    private void FixedUpdate()
    {

        thalmicMyo = myo.GetComponent<ThalmicMyo>();
        rigBod = GetComponent<Rigidbody>();

        if (thalmicMyo.pose == Pose.Fist && (flag == 1 || flag == 2))
        {
            //powerNum++;
            //transform.Translate(Vector3.forward);
            rigBod.useGravity = false;
            transform.Translate(new Vector3(0, 3, 0) * Time.deltaTime);
            force += ((spawnPoint.rotation)*Vector3.forward*15 * Time.deltaTime);
            info.text = "POWER!" + force.x + force.y + force.z;
            flag = 2;
            //transform.Translate(position);
        }
        else if (thalmicMyo.pose == Pose.WaveOut)
        {
            flag = 1;
            //if(enabled == false)
           // {
            //    enabled = true;
            //}
        }
        else if (flag == 2)
        {
            flag = 0;
            rigBod.AddForce(force);
            rigBod.useGravity = true;
            info.text = "POWER!" + force.x + force.y + force.z;
        }
    }
}
