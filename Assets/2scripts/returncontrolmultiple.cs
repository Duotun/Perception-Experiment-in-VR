using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class returncontrolmultiple : MonoBehaviour {
    public static int cnt = 0;
    int pcnt;
    GameObject tp;
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }
    // Use this for initialization
    void Start()
    {
        tp = GameObject.Find("empty");
        cnt = VRTK.Examples.UI_interaction_set.cnt_multiple;
    }
    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
    // Update is called once per frame
    public void grip()
    {
       /* if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            SceneManager.LoadScene("BUILDER2");
            /* pcnt++;
             cnt += 1;
             if (cnt > 6)
             {
                 cnt = 1;
             }

             if (pcnt == 6)
             {
                 SceneManager.LoadScene("BUILDER2");
             }
             else
             {
                 switch (cnt)
                 {
                     case 1: tp.SendMessage("record1", cnt); tp.SendMessage("record2", pcnt); SceneManager.LoadScene("iregularshapeahead"); break;
                     case 2: tp.SendMessage("record1", cnt); tp.SendMessage("record2", pcnt); SceneManager.LoadScene("iregularshapedelay"); break;
                     case 3: tp.SendMessage("record1", cnt); tp.SendMessage("record2", pcnt); SceneManager.LoadScene("iregularshapeinstant"); break;
                     case 4: tp.SendMessage("record1", cnt); tp.SendMessage("record2", pcnt); SceneManager.LoadScene("regularshapedelay"); break;
                     case 5: tp.SendMessage("record1", cnt); tp.SendMessage("record2", pcnt); SceneManager.LoadScene("regularshapeahead"); break;
                     case 6: tp.SendMessage("record1", cnt); tp.SendMessage("record2", pcnt); SceneManager.LoadScene("regularshapeinstant"); break;

                 }
             }
        }
	*/
    }

    void Update()
    {
        grip();
    }
}
