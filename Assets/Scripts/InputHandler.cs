using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public GameObject rConObject;
    public GameObject touchSphere;

    public float maxDist = 100;

    private Transform rConTransform;
    private Transform touchSphereTransform;

    private GameObject contact = null;
    private GameObject lastContact = null;

    // Start is called before the first frame update
    void Start()
    {
        rConTransform = rConObject.transform;
        touchSphereTransform = touchSphere.transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckContact();

        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            if (contact != null)
            {
                PointerClick pc = contact.GetComponent<PointerClick>();

                if (pc != null)
                    pc.Click();
            }
        }
    }

    private void CheckContact() {
        int layerMask = 1;

        RaycastHit hit;
        
        lastContact = contact;

        if (Physics.Raycast(rConTransform.position,
                    rConTransform.TransformDirection(Vector3.forward),
                    out hit, maxDist))
        {
            touchSphere.SetActive(true);
            touchSphereTransform.position = hit.point;

            contact = hit.transform.gameObject;

            /*
            Debug.Log(lastContact == null ? "null" : lastContact.name);
            Debug.Log(contact == null ? "null" : contact.name);
            Debug.Log("");
            */
        }
        else
        {
            touchSphere.SetActive(false);
            contact = null;
        }

        if (!GameObject.ReferenceEquals(contact, lastContact))
        {
            Debug.Log("Object point changed");
            if (lastContact != null)
                lastContact.GetComponent<PointerClick>().UnHover();

            if (contact != null)
                contact.GetComponent<PointerClick>().Hover();
        }
    }
}
