using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class returncontroltrain : MonoBehaviour {
    private SteamVR_TrackedObject trackedObj;
    public static int cnt = 0;
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }
    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
    // Use this for initialization
    void Start()
    {
        cnt = VRTK.Examples.UI_Interactions_2.cnt_vr;
    }

    // Update is called once per frame
    void Update()
    {
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {

            /*   pcnt++;
               cnt ++;
               print(cnt);
               if(cnt>3)
               {
                   cnt = 1;
               }

               if (pcnt == 3)
               {
                   SceneManager.LoadScene("BUILDER2");
               }
               else
               {
                    switch(cnt)
                   {
                       case 1:  tp.SendMessage("record1", cnt); tp.SendMessage("record2", pcnt); SceneManager.LoadScene("collisionahead"); break;
                       case 2:  tp.SendMessage("record1", cnt); tp.SendMessage("record2", pcnt); SceneManager.LoadScene("collisiondelay"); break;
                       case 3:  tp.SendMessage("record1", cnt); tp.SendMessage("record2", pcnt); SceneManager.LoadScene("collisioninstant"); break;

                   }
               }
               */
            SceneManager.LoadScene("BUILDER-TRAINING");
        }
    }
}
