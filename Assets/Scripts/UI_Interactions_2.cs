namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    using System.Collections;
    using UnityEngine.SceneManagement;
    using System.IO;
    public class UI_Interactions_2 : MonoBehaviour
    {
        private const int EXISTING_CANVAS_COUNT = 4;
        public static int cnt_red;
        public static int cnt_pinkwhole;
        public static int cnt_pinkonly;
        public static int cnt_vr;
        public static int cnt_multiple;
        int cnt2;
        int cnt3;
        int cnt1;
        GameObject tp;
        GameObject tp2;
        GameObject tp3;
        GameObject tpfinished;
        GameObject mass;
        GameObject ir;
        StreamWriter sp;
        //public int tp_int;
        public static int random_2d_0;
        public static int random_2d_1;
        public static int random_2d_2;
        public  static int random_3d_0;
        public static int random_3d_1;
        public static int random_3d_2;
        public static int random_3dmass_0;
        public static int random_3dmass_1;
        public static int random_3dmass_2;
        public static int random_multiple;
        private void Awake()
        {
            cnt_red = returncontrol2d.cnt;
            cnt_pinkwhole =returncontroll3dir.cnt;
            cnt_pinkonly = returncontrol3d.cnt;
            cnt_multiple = returncontrolmultiple.cnt;
            print(cnt_red);
            //tp = GameObject.Find("empty");
        }
        private void Start()
        {
            if (cnt_red == 0)
            {
                random_2d_0 = Random.Range(1, 4);
                random_2d_1 = Random.Range(1, 4);
                random_2d_2 = Random.Range(1, 4);
            }
            if (cnt_pinkwhole == 0)
            {
                random_3d_0 = Random.Range(1, 4);
                random_3d_1 = Random.Range(1, 4);
                random_3d_2 = Random.Range(1, 4);
            }
            if(cnt_pinkonly==0)
            {
                random_3dmass_0 = Random.Range(1, 4);
                random_3dmass_1 = Random.Range(1, 4);
                random_3dmass_2 = Random.Range(1, 4);
            }
            if(cnt_multiple==0)
            {
                random_multiple = Random.Range(1, 6);
            }


            if (cnt_multiple == 0 && cnt_pinkonly == 0 && cnt_pinkwhole == 0 && cnt_red == 0)
            {

                sp = File.CreateText("c:/upennVR/RECORD.TXT");
            }
            else
            {
                sp = File.AppendText("c:/upennVR/RECORD.TXT");
            }
            
            tp = GameObject.Find("2D2");
            tp.SetActive(false);
            tp2 = GameObject.Find("3D2");
            tp2.SetActive(false);
            tp3 = GameObject.Find("VRTXT");
            tp3.SetActive(false);
            tpfinished = GameObject.Find("finish");
            tpfinished.SetActive(false);
            ir = GameObject.Find("3D24");
            ir.SetActive(false);

        }
        public void Button_Red()
        {
             
            print(random_2d_0);
            print(random_2d_1);
            print(random_2d_2);
            if (cnt_red == 0)     //cai yong hash suiji diyige dian suijixuanqu ranhou houmian yici xiangjia, zheyangyefangbian caiji1 meigeren1yehuibutong
            {
                switch (random_2d_0)
                {
                    case 1: SceneManager.LoadScene("collisionahead");  break;
                    case 2: SceneManager.LoadScene("collisiondelay");  break;
                    case 3: SceneManager.LoadScene("collisioninstant"); break;

                }
             
                cnt_red++;
            }
            else
            {    
                if(cnt_red==3)
                {
                     /*if(tp.activeSelf==false)
                    {
                        //sp = File.AppendText("c:/upennVR/RECORD.TXT");
                        sp.WriteLine("2d : The distance is " + targetmove2d.distance + "Meters");
                       // sp.Close();
                    }
                    */
                    tp.SetActive(true);
                   
                }
                else
                {
                    if (cnt_red == 1)
                    {
                        switch (random_2d_1)
                        {
                            case 1: SceneManager.LoadScene("collisionahead"); break;
                            case 2: SceneManager.LoadScene("collisiondelay"); break;
                            case 3: SceneManager.LoadScene("collisioninstant"); break;
                                // case 4: SceneManager.LoadScene("collisionahead");  break;
                                // case 5:  SceneManager.LoadScene("collisiondelay");  break;
                        }
                        cnt_red++;
                    }
                    else
                    {
                           if(cnt_red==2)
                        {
                            switch (random_2d_2)
                            {
                                case 1: SceneManager.LoadScene("collisionahead"); break;
                                case 2: SceneManager.LoadScene("collisiondelay"); break;
                                case 3: SceneManager.LoadScene("collisioninstant");break;
                                    // case 4: SceneManager.LoadScene("collisionahead");  break;
                                    // case 5:  SceneManager.LoadScene("collisiondelay");  break;
                            }
                            cnt_red++;
                        }
                    }
                }
            }
        }
        private void Update()
        {
           
            if(cnt_red==3&&/*cnt_pinkwhole==3&&*/cnt_multiple==5&&cnt_pinkonly==3)
            {
                tpfinished.SetActive(true);
                sp.Close();
            }

            if(cnt_red==3)
            {
                tp.SetActive(true);
                //sp.WriteLine("2d : The distance is " + targetmove2d.distance + "Meters");
                //sp.Close();
                
            }
            if(cnt_pinkwhole==3)
            {
                ir.SetActive(true);
            }
            if(cnt_pinkonly==3)
            {
                tp2.SetActive(true);
            }
            if(cnt_multiple==5)
            {
                tp3.SetActive(true);
            }


        }
        public void Button_Red1()
        {
           
        }
        public void Button_Red2()
        {
            
        }
        public void Button_Red3()
        {
            
        }
        public void Button_Pink()  //ir
        {   

            if (cnt_pinkwhole == 0)
            {
                
                switch (random_3d_0)
                {
                    case 1: SceneManager.LoadScene("iregularshapeahead"); break;
                    case 2: SceneManager.LoadScene("iregularshapedelay"); break;
                    case 3: SceneManager.LoadScene("iregularshapeinstant"); break;

                }
                //sp.WriteLine("3d-Irregular shape : The distance is " +circletrack3d.radius*circletrack3d.angle_now+"m");
                cnt_pinkwhole++;
            }
            else
            {
                if (cnt_pinkwhole == 3)
                {
                   /* if (ir.activeSelf == false)
                    {
                        //sp = File.AppendText("c:/upennVR/RECORD.TXT");
                        sp.WriteLine("3d-Irregular shape : The distance is " + circletrack3d.radius * circletrack3d.angle_now + "Meters");
                        //sp.Close();
                    }*/
                    ir.SetActive(true);
                    
                }
                else
                {
                    if (cnt_pinkwhole == 1)
                    {
                        switch (random_3d_1)
                        {
                            case 1: SceneManager.LoadScene("iregularshapeahead"); break;
                            case 2: SceneManager.LoadScene("iregularshapedelay"); break;
                            case 3: SceneManager.LoadScene("iregularshapeinstant"); break;
                           // case 4: SceneManager.LoadScene("iregularshapeahead"); break;
                          //  case 5: SceneManager.LoadScene("iregularshapedelay"); break;
                           // case 6: SceneManager.LoadScene("iregularshapeinstant"); break;

                        }
                        cnt_pinkwhole++;
                    }
                    else
                    {
                          if(cnt_pinkwhole==2)
                        {
                             switch(random_3d_2)
                            {
                                case 1: SceneManager.LoadScene("iregularshapeahead"); break;
                                case 2: SceneManager.LoadScene("iregularshapedelay"); break;
                                case 3: SceneManager.LoadScene("iregularshapeinstant"); break;
                                //case 4: SceneManager.LoadScene("iregularshapeahead"); break;
                               // case 5: SceneManager.LoadScene("iregularshapedelay"); break;
                               // case 6: SceneManager.LoadScene("iregularshapeinstant"); break;
                            }
                            cnt_pinkwhole++;
                        }
                    }
                }
            }
        }
        public void Button_Pinkonly()   //mass
        {
            if(cnt_pinkonly==0)
            {
                switch(random_3dmass_0)
                {
                    case 1: SceneManager.LoadScene("regularshapeinstant");break;
                    case 2: SceneManager.LoadScene("regularshapeahead");break;
                    case 3: SceneManager.LoadScene("regularshapedelay");break;
                   
                }
                cnt_pinkonly++;
            }
            else
            {
                 if(cnt_pinkonly==3)
                {
                    /*if (tp2.activeSelf == false)
                    {   
                       // sp= File.AppendText("c:/upennVR/RECORD.TXT");
                        sp.WriteLine("3d-regular shape : The distance is " + circletrack3d.radius * circletrack3d.angle_now + "Meters");
                       // sp.Close();
                    }
                    */
                    tp2.SetActive(true);
                }
                 else
                {
                    if (cnt_pinkonly == 1)
                    {
                        switch (random_3dmass_1)
                        {
                            case 1: SceneManager.LoadScene("regularshapeinstant"); break;
                            case 2: SceneManager.LoadScene("regularshapeahead"); break;
                            case 3: SceneManager.LoadScene("regularshapedelay"); break;
                           // case 4: SceneManager.LoadScene("regularshapeinstant"); break;
                           // case 5: SceneManager.LoadScene("regularshapeahead"); break;
                           // case 6: SceneManager.LoadScene("regularshapedelay"); break;

                        }
                        cnt_pinkonly++;
                    }
                    else
                    {
                         if(cnt_pinkonly==2)
                        {
                            switch (random_3dmass_2)
                            {
                                case 1: SceneManager.LoadScene("regularshapeinstant"); break;
                                case 2: SceneManager.LoadScene("regularshapeahead"); break;
                                case 3: SceneManager.LoadScene("regularshapedelay"); break;
                               // case 4: SceneManager.LoadScene("regularshapeinstant"); break;
                               // case 5: SceneManager.LoadScene("regularshapeahead"); break;
                               // case 6: SceneManager.LoadScene("regularshapedelay"); break;

                            }
                            cnt_pinkonly++;

                        }
                    }
                }
            }
        }
        public void Button_Blue()
        {
            if (cnt_vr == 0)
            {
                cnt_vr++;
                SceneManager.LoadScene("Game2");
            }
            else
            {
                tp3.SetActive(true);
            }
        }
        public void Button_Black()
        {
            if(cnt_multiple==0)
            {
                switch(random_multiple)
                {
                    case 1: SceneManager.LoadScene("MULTIPLE");break;
                    case 2: SceneManager.LoadScene("MULTIPLE 1"); break;
                    case 3: SceneManager.LoadScene("MULTIPLE 2"); break;
                    case 4: SceneManager.LoadScene("MULTIPLE 3"); break;
                    case 5: SceneManager.LoadScene("MULTIPLE 4"); break;

                }
                cnt_multiple++;
            }
            else
            {
                 if(cnt_multiple==5)
                {
                    tp3.SetActive(true);
                }
                 else
                {
                    switch(random_multiple+cnt_multiple)
                    {
                        case 1: SceneManager.LoadScene("MULTIPLE"); break;
                        case 2: SceneManager.LoadScene("MULTIPLE 1"); break;
                        case 3: SceneManager.LoadScene("MULTIPLE 2"); break;
                        case 4: SceneManager.LoadScene("MULTIPLE 3"); break;
                        case 5: SceneManager.LoadScene("MULTIPLE 4"); break;
                        case 6: SceneManager.LoadScene("MULTIPLE"); break;
                        case 7: SceneManager.LoadScene("MULTIPLE 1"); break;
                        case 8: SceneManager.LoadScene("MULTIPLE 2"); break;
                        case 9: SceneManager.LoadScene("MULTIPLE 3"); break;
                        case 10: SceneManager.LoadScene("MULTIPLE 4"); break;
                    }
                    cnt_multiple++;
                }
            }
        }
        public void Button_Black2()
        {
           
        }
        public void Button_Black3()
        {
            
        }
        public void Button_White1()
        {
            
        }
        public void Button_White2()
        {
           
        }
        public void Button_White3()
        {
            
        }
        public void Toggle(bool state)
        {
            
        }

        public void Dropdown(int value)
        {
            
        }

        public void SetDropText(BaseEventData data)
        {
            var pointerData = data as PointerEventData;
            var textObject = GameObject.Find("ActionText");
            if (textObject)
            {
                var text = textObject.GetComponent<Text>();
                text.text = pointerData.pointerDrag.name + " Dropped On " + pointerData.pointerEnter.name;
            }
        }

        public void CreateCanvas()
        {
            StartCoroutine(CreateCanvasOnNextFrame());
        }

        private IEnumerator CreateCanvasOnNextFrame()
        {
            yield return null;

            var canvasCount = FindObjectsOfType<Canvas>().Length - EXISTING_CANVAS_COUNT;
            var newCanvasGO = new GameObject("TempCanvas");
            newCanvasGO.layer = 5;
            var canvas = newCanvasGO.AddComponent<Canvas>();
            var canvasRT = canvas.GetComponent<RectTransform>();
            canvasRT.position = new Vector3(-4f, 2f, 3f + canvasCount);
            canvasRT.sizeDelta = new Vector2(300f, 400f);
            canvasRT.localScale = new Vector3(0.005f, 0.005f, 0.005f);
            canvasRT.eulerAngles = new Vector3(0f, 270f, 0f);

            var newButtonGO = new GameObject("TempButton", typeof(RectTransform));
            newButtonGO.transform.SetParent(newCanvasGO.transform);
            newButtonGO.layer = 5;

            var buttonRT = newButtonGO.GetComponent<RectTransform>();
            buttonRT.position = new Vector3(0f, 0f, 0f);
            buttonRT.anchoredPosition = new Vector3(0f, 0f, 0f);
            buttonRT.localPosition = new Vector3(0f, 0f, 0f);
            buttonRT.sizeDelta = new Vector2(180f, 60f);
            buttonRT.localScale = new Vector3(1f, 1f, 1f);
            buttonRT.localEulerAngles = new Vector3(0f, 0f, 0f);

            newButtonGO.AddComponent<Image>();
            var canvasButton = newButtonGO.AddComponent<Button>();
            var buttonColourBlock = canvasButton.colors;
            buttonColourBlock.highlightedColor = Color.red;
            canvasButton.colors = buttonColourBlock;

            var newTextGO = new GameObject("BtnText", typeof(RectTransform));
            newTextGO.transform.SetParent(newButtonGO.transform);
            newTextGO.layer = 5;

            var textRT = newTextGO.GetComponent<RectTransform>();
            textRT.position = new Vector3(0f, 0f, 0f);
            textRT.anchoredPosition = new Vector3(0f, 0f, 0f);
            textRT.localPosition = new Vector3(0f, 0f, 0f);
            textRT.sizeDelta = new Vector2(180f, 60f);
            textRT.localScale = new Vector3(1f, 1f, 1f);
            textRT.localEulerAngles = new Vector3(0f, 0f, 0f);

            var txt = newTextGO.AddComponent<Text>();
            txt.text = "New Button";
            txt.color = Color.black;
            txt.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;

            newCanvasGO.AddComponent<VRTK_UICanvas>();
        }
    }
}