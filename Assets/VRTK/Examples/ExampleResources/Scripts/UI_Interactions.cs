namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    using System.Collections;
    using UnityEngine.SceneManagement;
    public class UI_Interactions : MonoBehaviour
    {
        private const int EXISTING_CANVAS_COUNT = 4;
        int cnt_red = 0;
        int cnt_pinkwhole = 0;
        int cnt_black = 0;
        int cnt_white = 0;
       /* GameObject g2d1;
        GameObject g2d2;
        GameObject g2d3;
        GameObject[] g3d;
        GameObject g3d1;
        GameObject g3d2;
        GameObject g3d3;
        GameObject g3d4;
        GameObject g3d5;
        GameObject g3d6;
        GameObject gvr;
        */
        private void Start()
        {
          /*  g2d1 = GameObject.Find("2D1");
            g2d2 = GameObject.Find("2D2");
            g2d3 = GameObject.Find("2D3");
            g3d = GameObject.FindGameObjectsWithTag("3d");
            g3d1 = GameObject.Find("3D11");
            g3d2 = GameObject.Find("3D12");
            g3d3 = GameObject.Find("3D13");
            g3d4 = GameObject.Find("3D21");
            g3d5 = GameObject.Find("3D22");
            g3d6 = GameObject.Find("3D23");
            gvr = GameObject.Find("VR");
            foreach (GameObject g3d in g3d)
            {
                g3d.gameObject.SetActive(false);
            }
            g2d1.SetActive(false);
            g2d2.SetActive(false);
            g2d3.SetActive(false);
            */
        }
        public void Button_Red()
        {
            VRTK_Logger.Info("Red Button Clicked");
            /*  if(cnt_red%2==0)
            {
                cnt_red++;
                g2d1.SetActive(true);
                g2d2.SetActive(true);
                g2d3.SetActive(true);
            }
              else
            {
                cnt_red++;
                g2d1.SetActive(false);
                g2d2.SetActive(false);
                g2d3.SetActive(false);
            }
            */
            //SceneManager.LoadScene("collision");
        }
        public void Button_Red1()
        {
            SceneManager.LoadScene("collisioninstant");
        }
        public void Button_Red2()
        {
            SceneManager.LoadScene("collisionahead");
        }
        public void Button_Red3()
        {
            SceneManager.LoadScene("collisiondelay");
        }
        public void Button_Pink()
        {
            VRTK_Logger.Info("Pink Button Clicked");
           /* if(cnt_pinkwhole%2==0)
            {
                cnt_pinkwhole++;
                foreach (GameObject g3d in g3d)
                {
                    g3d.gameObject.SetActive(true);
                }
            }
            else
            {
                foreach (GameObject g3d in g3d)
                {
                    g3d.gameObject.SetActive(false);
                }
                cnt_pinkwhole++;
            }
            */
        }
        public void Button_Blue()
        {
          //  SceneManager.LoadScene("GAME");
        }
        public void Button_Black1()
        {
            SceneManager.LoadScene("regularshapeahead");
        }
        public void Button_Black2()
        {
            SceneManager.LoadScene("regularshapeinstant");
        }
        public void Button_Black3()
        {
            SceneManager.LoadScene("regularshapedelay");
        }
        public void Button_White1()
        {
            SceneManager.LoadScene("iregularshapeinstant");
        }
        public void Button_White2()
        {
            SceneManager.LoadScene("iregularshapeahead");
        }
        public void Button_White3()
        {
            SceneManager.LoadScene("iregularshapedelay");
        }
        public void Toggle(bool state)
        {
            VRTK_Logger.Info("The toggle state is " + (state ? "on" : "off"));
        }

        public void Dropdown(int value)
        {
            VRTK_Logger.Info("Dropdown option selected was ID " + value);
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