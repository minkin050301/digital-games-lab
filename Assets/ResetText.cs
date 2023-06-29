using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResetText : MonoBehaviour
{

    public TextMeshProUGUI text;
    private string lastText = "";
    // Start is called before the first frame update
    void Start()
    {
        text.SetText("");
    }

    // Update is called once per frame
    float timer = 0;
    bool timerReached = false;

    void Update() {
        if (!lastText.Equals(text.text)) {
            timer = 0;
            timerReached = false;
            lastText = text.text;
            Debug.Log("Reset last text");
            return;
        }
        if (!timerReached) {
            timer += Time.deltaTime;
            Debug.Log("Time is " + timer);
        }

        if (!timerReached && timer > 5) {
            text.SetText("");
            timerReached = true;
            Debug.Log("Reached time");
        }
    }
}
