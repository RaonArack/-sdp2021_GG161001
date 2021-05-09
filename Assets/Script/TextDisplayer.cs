using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplayer : MonoBehaviour
{
    // Update is called once per frame
    public Text[] texts;
    string textName;
    void Update()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            textName = InputSetting.keys[(KeyAction)i].ToString();
            if (textName == "None") { texts[i].text = "--"; }
            else if (textName == "Return") { texts[i].text = "Enter"; }
            else { texts[i].text = textName; }
        }
    }
}