using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;


using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class ArrowFiring : MonoBehaviour {
    //public GameObject gameController;
    // Use this for initialization
    public int powerNum = 50;
    //public Text testdata = null;
    public Text info = null;
    public GameObject myo = null;
    public GameObject head = null;
    //public Vector3 charging = new Vector3(0, 1, 0);
    
    public int flag = 0;
    public Transform spawnPoint;
    public Transform Redirect;

    private Rigidbody rigBod;
    private ThalmicMyo thalmicMyo;

    private Vector3 force = new Vector3(0, 0, 0);
    //private Vector3 displacement = new Vector3(0, 0, 0);
    private Vector3 direction = new Vector3(0, 0, 2);
    private double AccSum;
    public Vector3 bullectSize;
    public Vector3 originalSize = new Vector3(1, 1, 1);
    public float growth;
    public double length;
  

    // Update is called once per frame
    void Start () {
        //gameController.state = 0;
        thalmicMyo = myo.GetComponent<ThalmicMyo>();
        rigBod = GetComponent<Rigidbody>();
        rigBod.useGravity = false;
        info.text = "Welcome, archer.";
        flag = 1;
        //else if(thalmicMyo.pose == Pose.Rest)
    }

    private void FixedUpdate()
    {
        
        thalmicMyo = myo.GetComponent<ThalmicMyo>();
        rigBod = GetComponent<Rigidbody>();
        transform.rotation = spawnPoint.rotation;
        direction = head.transform.position - Redirect.position;
        AccSum = Mathf.Abs(Mathf.Pow(thalmicMyo.accelerometer.x,2) + Mathf.Pow(thalmicMyo.accelerometer.y, 2) + Mathf.Pow(thalmicMyo.accelerometer.z, 2) - 1);
    
        length += Mathf.Pow(Time.deltaTime,2) * 0.5 * AccSum;
        //RawReadings();


        if (thalmicMyo.pose == Pose.Fist && (flag == 1 || flag == 2))//charging
        {
            rigBod.useGravity = false;
            transform.Translate(new Vector3(0, 3, 0) * Time.deltaTime);
            force += (direction * powerNum * Time.deltaTime);
            info.text = "POWER!" + length + "\n";
            flag = 2;
            
        }
        
        else if (thalmicMyo.accelerometer.z > 0.7 && flag == 0)
        {
            flag = 1;
            info.text = "New Ammo!";
            
        }
        else if (flag == 2)
        {
            flag = 0;
            //rigBod.AddForce(force);
            rigBod.useGravity = true;
            //transform.localScale = originalSize;
            info.text = "Shoot!";
            // + " x: " + force.x + " y: " + force.y + " z: " + force.z
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("boundary"))
    //    {
    //        gameObject.SetActive(false);
    //        Destroy(gameObject);
    //    }
    //}

    //public void RawReadings()
    //{
    //    testdata.text = " \nAcc x: " + thalmicMyo.accelerometer.x * 9.8
    //            + " \nAcc y: " + thalmicMyo.accelerometer.y * 9.8
    //            + " \nAcc z: " + thalmicMyo.accelerometer.z * 9.8
    //            + " \n>>>>>>>>>><<<<<<<<<<<"
    //            + " \nGyro x: " + thalmicMyo.gyroscope.x
    //            + " \nGyro y: " + thalmicMyo.gyroscope.y
    //            + " \nGyro z: " + thalmicMyo.gyroscope.z;
    //}

    //public 
}
