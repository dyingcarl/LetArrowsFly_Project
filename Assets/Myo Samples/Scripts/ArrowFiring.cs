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
    public int powerNum = 50;
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
  

    // Update is called once per frame
    void Start () {
        thalmicMyo = myo.GetComponent<ThalmicMyo>();
        rigBod = GetComponent<Rigidbody>();
        rigBod.useGravity = false;
        info.text = "Welcome, archer.";
        flag = 1;
        //enabled = false;


        //else if(thalmicMyo.pose == Pose.Rest)
    }

    private void FixedUpdate()
    {

        thalmicMyo = myo.GetComponent<ThalmicMyo>();
        rigBod = GetComponent<Rigidbody>();
        transform.rotation = spawnPoint.rotation;
        //transform.position = spawnPoint.position;// + displacement;
        //Vector3 direction = new Vector3(spawnPoint.transform.forward.x, 0, spawnPoint.transform.forward.z);
        //Vector3 direction = new Vector3(0,0,2);
        direction = head.transform.position - Redirect.position;

        if (thalmicMyo.pose == Pose.Fist && (flag == 1 || flag == 2))
        {
            //powerNum++;
            //transform.Translate(Vector3.forward);
            rigBod.useGravity = false;
            transform.Translate(new Vector3(0, 3, 0) * Time.deltaTime);
            //displacement += new Vector3(0, 0, 3) * Time.deltaTime;
            force += (direction * powerNum * Time.deltaTime);
            info.text = "POWER!" + " \n" + force.x + " \n" + force.y + " \n" + force.z;
            flag = 2;
            //transform.Translate(position);
        }

        //else if(flag == 0 && thalmicMyo.pose == Pose.WaveIn)
       // {
        //    Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        //}
        else if (thalmicMyo.pose == Pose.WaveIn)
        {
            flag = 1;
            info.text = "New Ammo!";
            
        }
        else if (flag == 2)
        {
            flag = 0;
            rigBod.AddForce(force);
            rigBod.useGravity = true;
            info.text = "Shoot!" + " x: " + force.x + " y: " + force.y + " z: " + force.z;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("boundary"))
        {
            gameObject.SetActive(false);
        }
    }
}
