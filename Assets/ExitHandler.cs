using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExitHandler : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnClick() {
        Debug.Log("Exit clicked");
        text.SetText("Exiting...");
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
