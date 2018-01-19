using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;



public class BowController : MonoBehaviour {
    public GameObject bullet = null;
    public GameObject spawnPoint = null;
    public GameObject myo = null;
    public Text testdata = null;


    private ThalmicMyo thalmicMyo;
    private bool reloadFlag;
    // Use this for initialization
    void Start () {
        thalmicMyo = myo.GetComponent<ThalmicMyo>();
        reloadFlag = false;
    }
	
	// Update is called once per frame
	void Update () {
        RawReadings();

        if (reloadFlag == true && thalmicMyo.accelerometer.z > 0.7)
        {
            reload(bullet);
            reloadFlag = false;
        }
        else if(reloadFlag == false && thalmicMyo.pose == Pose.Fist)
        {
            reloadFlag = true;
        }
	}

    void reload(GameObject toLoad)
    {
        Instantiate(bullet, spawnPoint.transform.position, spawnPoint.transform.rotation,spawnPoint.transform);

    }

    public void RawReadings()
    {
        testdata.text = " \nAcc x: " + thalmicMyo.accelerometer.x * 9.8
                + " \nAcc y: " + thalmicMyo.accelerometer.y * 9.8
                + " \nAcc z: " + thalmicMyo.accelerometer.z * 9.8
                + " \n>>>>>>>>>><<<<<<<<<<<"
                + " \nGyro x: " + thalmicMyo.gyroscope.x
                + " \nGyro y: " + thalmicMyo.gyroscope.y
                + " \nGyro z: " + thalmicMyo.gyroscope.z;
    }
}
