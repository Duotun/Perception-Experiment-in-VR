namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.UI;

    public class UI_Keyboard : MonoBehaviour
    {
        private InputField input;
        private AudioClip pp;
        private AudioClip pp1;
        private AudioClip pp2;
        public void ClickKey(string character)
        {
            input.text += character;
            AudioSource.PlayClipAtPoint(pp, input.gameObject.transform.position, 1.0f);
        }

        public void Backspace()
        {
            if (input.text.Length > 0)
            {
                input.text = input.text.Substring(0, input.text.Length - 1);
                AudioSource.PlayClipAtPoint(pp2, input.gameObject.transform.position, 1.0f);
            }
            AudioSource.PlayClipAtPoint(pp2, input.gameObject.transform.position, 1.0f);
        }

        public void Enter()
        {
            VRTK_Logger.Info("You've typed [" + input.text + "]");
            AudioSource.PlayClipAtPoint(pp1, input.gameObject.transform.position, 1.0f);
            input.text = "";
        }

        private void Start()
        {
            input = GetComponentInChildren<InputField>();
            pp = GameObject.Find("Floor").GetComponent<AudioSource>().clip;
            pp1 = GameObject.Find("ExampleWorldObjects").GetComponent<AudioSource>().clip;
            pp2 = GameObject.Find("WorldKeyboard").GetComponent<AudioSource>().clip;
        }
    }
}