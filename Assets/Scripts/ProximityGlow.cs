using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityGlow : MonoBehaviour
{
    public Transform leftHand;
    public Transform rightHand;

    public float maxDist;
    public float minDist;

    public Color baseColor;
    public float maxBrightness;

    private Renderer r;
    private Material m;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();
        m = r.material;
    }

    // Update is called once per frame
    void Update()
    {
        float nearest = Mathf.Min(Vector3.Distance(transform.position, leftHand.position), Vector3.Distance(transform.position, rightHand.position));
        float v = 1 - ((nearest - minDist) / (maxDist - minDist));

        v = Mathf.Clamp(v, 0, maxBrightness);

        Color finalColor = baseColor * Mathf.LinearToGammaSpace(v);

        Debug.Log($"Distance: {nearest}");
        Debug.Log($"V: {v}");

        m.SetColor("_EmissionColor", finalColor);
    }
}
