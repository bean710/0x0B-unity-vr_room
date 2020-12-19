using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadButton : MonoBehaviour
{
    public Transform leftHand;
    public Transform rightHand;

    public KeypadController kc;
    public int number;

    public float delay = 500;

    private Bounds bounds;
    private float lastTime;

    // Start is called before the first frame update
    void Start()
    {
        bounds = GetComponent<Collider>().bounds;
        lastTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"TD: {Time.time - lastTime}");
        if ((Time.time - lastTime) > (delay / 1000) && (bounds.Contains(leftHand.position) || bounds.Contains(rightHand.position)))
        {
            kc.EnterNumber(number);
            lastTime = Time.time;
        }
    }
}
