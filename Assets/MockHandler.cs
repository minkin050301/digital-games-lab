using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MockHandler : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick() {
        Debug.Log("Mock clicked");
        text.SetText("I said don't!");
    }
}
