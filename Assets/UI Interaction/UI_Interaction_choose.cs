namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    using System.Collections;
    using UnityEngine.SceneManagement;
    using System.IO;
    public class UI_Interaction_choose : MonoBehaviour
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
        int scrollvalue;
        int redrandom;
        int pinkonlyrandom;
        int gauge = 27;
        int maxvalue;
        static int cntwrite=0;
        /* void Awake()
         {
             cnt_red = returncontrol2d.cnt;
             cnt_pinkwhole = returncontroll3dir.cnt;
             cnt_pinkonly = returncontrol3d.cnt;
             cnt_multiple = returncontrolmultiple.cnt;
             print(cnt_red);
             redrandom = 1;
             pinkonlyrandom = 1;
             maxvalue = 9;
         }
         */

        public void instruction_2d()
        {
			if (cnt_red != 54) {
				sp = File.CreateText ("c:/upennVR/RECORD2dtrial.TXT");
				sp.WriteLine ("2D-Scene :   Rolling Sound     Time Delay   Collision Sound   Probability");
				sp.Close ();
				SceneManager.LoadScene ("Instruction_2d");
			}
          //  SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        public void instruction_3d()
        {
			if (cnt_pinkonly != 54) {
				sp = File.CreateText ("c:/upennVR/RECORD3dtrial.TXT");
				sp.WriteLine ("3D - Scene :   Rolling Sound     Time Delay    Collision Sound   Probability");
				sp.Close ();
				SceneManager.LoadScene ("Instruction_3d");
			}
        }
		public void instruction_spatial()
		{
			if (cnt_multiple != 120) {
				sp = File.CreateText ("c:/upennVR/RECORDspatial.TXT");
				sp.WriteLine ("spatial - Scene :   Rolling Sound     Time Delay     Angle   Collision Sound   Probability");
				sp.Close ();
				SceneManager.LoadScene ("Instruction_spatial");
			}
		}
        private void Update()
        {

            if (cnt_red == 54)
            {
                tp.SetActive(true);
                if (cntwrite == 0)
                {
                    sp = File.CreateText("c:/upennVR/RECORD2d.TXT");
                    for (int i = 0; i < 54; i++)
                    {
						sp.WriteLine(VRTK.Examples.UI_interaction_set.recording_2d[i].timedelay + "   " + VRTK.Examples.UI_interaction_set.recording_2d[i].rating+ "   "+VRTK.Examples.UI_interaction_set.recording_2d[i].sound);
                    }
                    sp.Close();
                    cntwrite++;
                }
            }
            if (cnt_pinkonly == 54)   // consequent complete , do not close the program
            {
                tp2.SetActive(true);
                if (cntwrite == 1)
                {
                    sp = File.CreateText("c:/upennVR/RECORD3d.TXT");
                    for (int i = 0; i < 54; i++)
                    {
						sp.WriteLine(VRTK.Examples.UI_interaction_set.recording_3d[i].timedelay + "   " + VRTK.Examples.UI_interaction_set.recording_3d[i].rating+"    "+VRTK.Examples.UI_interaction_set.recording_3d[i].sound);
                    }
                    sp.Close();
                    cntwrite++;
                }
            }
            if (cnt_multiple == 120)
            {
                tp3.SetActive(true);
				if (cntwrite == 0) {
					sp = File.CreateText ("c:/upennVR/RECORD3dspatial.TXT");
					for (int i = 0; i < 120; i++)
					{
						sp.WriteLine(VRTK.Examples.UI_interaction_set.recording_spatial[i].timedelay + "   "+VRTK.Examples.UI_interaction_set.recording_spatial[i].angle+"   "+VRTK.Examples.UI_interaction_set.recording_spatial[i].rating+"   "+ VRTK.Examples.UI_interaction_set.recording_spatial[i].sound);
					}
					sp.Close();
					cntwrite++;
				}
            }
        }
        void Start()
        {
            tp = GameObject.Find("2D2");
            tp.SetActive(false);
            tpfinished = GameObject.Find("finish");
            tpfinished.SetActive(false);
            tp2 = GameObject.Find("3D2");
            tp2.SetActive(false);
            tp3 = GameObject.Find("VRTXT");
            tp3.SetActive(false);
            cnt_red = VRTK.Examples.UI_interaction_set.cnt_red;
            cnt_pinkonly = VRTK.Examples.UI_interaction_set.cnt_pinkonly;
            cnt_multiple = VRTK.Examples.UI_interaction_set.cnt_multiple;
			if (cnt_red == 54 &&/*cnt_pinkwhole==3&&*/cnt_multiple == 120 && cnt_pinkonly == 54)
			{
				tpfinished.SetActive(true);
				// sp.Close();
			}
			//cnt_multiple=120;
  //          print(cnt_red);
//            print(cnt_pinkonly);

        }
        public void Toggle(bool state)
        {

        }

        public void Dropdown(int value)
        {

        }
        public void scrollvaluechange()
        {
            Scrollbar now;
            Text ss;
            now = GameObject.Find("choose").GetComponent<Scrollbar>();
            float tmp;
            tmp = now.value * maxvalue;
            scrollvalue = (int)tmp;
            ss = GameObject.Find("rate").GetComponent<Text>();
            ss.text = "Rating :" + scrollvalue;
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