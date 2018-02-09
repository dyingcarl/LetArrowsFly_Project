using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;



public class BowController : MonoBehaviour {
    //public GameObject gameController;
    public GameObject bullet = null;
    public GameObject spawnPoint = null;
    public GameObject myo = null;
    public Text testdata = null;


    private ThalmicMyo thalmicMyo;
    private Rigidbody ammoBody;
    private GameObject currentAmmo;
    private int BowState;
    // Use this for initialization
    void Start () {
        thalmicMyo = myo.GetComponent<ThalmicMyo>();
        BowState = 1;
    }
	
	// Update is called once per frame
	void Update () {
        //RawReadings();
        if (thalmicMyo.pose == Pose.Fist)
            testdata.text = "nothing to show State: " + BowState + "Fist";
        else { testdata.text = "nothing to show State: " + BowState; }
        if (BowState == 0 && thalmicMyo.accelerometer.z > 0.7)
        {
            reload(bullet);
            BowState = 1;

            testmsg("arrow refill\n");
        }

        else if((BowState == 1) && (thalmicMyo.pose == Pose.Fist))
        {
           // BowState = 2;
            testmsg("pulling string\n");
        }

        else if((BowState == 1) && (thalmicMyo.pose != Pose.Fist))
        {
            ammoBody.AddForce(0,10,0);
            ammoBody.useGravity = true;
            BowState = 0;
            testmsg("FIRRRREEEEEE\n");
        }
	}

    void reload(GameObject toLoad)
    {
        currentAmmo = Instantiate(toLoad, spawnPoint.transform.position, spawnPoint.transform.rotation,spawnPoint.transform);
        ammoBody = currentAmmo.GetComponent<Rigidbody>();

    }

    public void RawReadings()
    {
        testdata.text = " \nAcc x: " + thalmicMyo.accelerometer.x * 9.8
                + " \nAcc y: " + thalmicMyo.accelerometer.y * 9.8
                + " \nAcc z: " + thalmicMyo.accelerometer.z * 9.8
                + " \n>>>>>>>>>>" + " " + "<<<<<<<<<<<"
                + " \nGyro x: " + thalmicMyo.gyroscope.x
                + " \nGyro y: " + thalmicMyo.gyroscope.y
                + " \nGyro z: " + thalmicMyo.gyroscope.z;
    }

    public void testmsg(string msg)
    {
        testdata.text = msg;
    }
}
