using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class text1 : MonoBehaviour {
    Text ss;
    // Use this for initialization
    void Start()
    {
        ss = GameObject.Find("ppku").GetComponent<Text>();

        /*ss.text = "INSTRUCTION\n" +
            "In the following experiment, you will observe a series of physical events" +
"in an immersive virtual environment. After each trial is finished you will be" +
"asked to make a series of judgments. " +
"Press the Next button when you are ready to begin.\n" +
"在下面的实验中，你会在沉浸式的虚拟环境中观测到一系列的物理事件。每个观察结束后，你将会被要求做出一系列判断。如果你准备好了，请点击“下一步”按钮开始";*/
		ss.text = "说明\n在下面的实验中，你会在沉浸式的虚拟环境中观测到一系列的物理事件。每个观察结束后，请根据小球的运动来做出判断。如果你准备好了，请点击“下一步”按钮开始";
    }
    public void clicknext()
    {
        SceneManager.LoadScene("3dset");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
