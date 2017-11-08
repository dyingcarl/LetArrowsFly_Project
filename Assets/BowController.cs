using UnityEngine;
using System.Collections;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;



public class BowController : MonoBehaviour {
    public GameObject bullet = null;
    public GameObject spawnPoint = null;
    public GameObject myo = null;



    private ThalmicMyo thalmicMyo;
    private bool reloadFlag;
    // Use this for initialization
    void Start () {
        thalmicMyo = myo.GetComponent<ThalmicMyo>();
        reloadFlag = false;
    }
	
	// Update is called once per frame
	void Update () {
		if(reloadFlag == true && thalmicMyo.pose == Pose.WaveIn)
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
        Instantiate(bullet, spawnPoint.transform.position, spawnPoint.transform.rotation);

    }
}
