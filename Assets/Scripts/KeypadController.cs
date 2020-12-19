using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeypadController : MonoBehaviour
{
    public GameObject screenText;
    public Animator glassDoor;
    public string password = "314159";

    private string entered = "000000";

    private TextMeshPro tm;
    private bool unlocked = false;

    // Start is called before the first frame update
    void Start()
    {
        tm = screenText.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (entered == password)
        {
            unlocked = true;
            entered = "<color=\"green\">314159</color>";
            tm.text = entered;
            glassDoor.SetBool("character_nearby", true);
        }
        
        if (!unlocked)
            tm.text = entered;
    }

    public void EnterNumber(int num)
    {
        if (!unlocked)
            entered = entered.Substring(1) + num.ToString();
    }
}
