using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class text2 : MonoBehaviour {
    Text ss;
    // Use this for initialization
    void Start()
    {
        ss = GameObject.Find("ppku").GetComponent<Text>();

        ss.text = "完毕\n"+
            "现在您已经完成了这一部分实验，你可以点击下一步按钮返回主界面然后休息一下";

    }
    public void clicknext()
    {
        SceneManager.LoadScene("BUILDER2");
    }
    // Update is called once per frame
    void Update () {
		
	}
}
