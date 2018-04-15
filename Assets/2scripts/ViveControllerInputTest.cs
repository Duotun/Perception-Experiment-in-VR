﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveControllerInputTest : MonoBehaviour {

    private SteamVR_TrackedObject  trackedObj;
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }
	void Awake()
   {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

	// Update is called once per frame
	void Update () {
		if(Controller.GetAxis()!=Vector2.zero)
        {
            Debug.Log(gameObject.name + Controller.GetAxis());
        }
        if(Controller.GetHairTriggerDown())
        {
            Debug.Log(gameObject.name + "trigger press");
        }
        if(Controller.GetHairTriggerUp())
        {
            Debug.Log(gameObject.name + "trigger release");

        }
        if(Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            Debug.Log(gameObject.name + "grip press");
        }
        if(Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
        {
            Debug.Log(gameObject.name + "grip release");

        }

	}
}
