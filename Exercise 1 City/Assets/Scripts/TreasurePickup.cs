using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasurePickup : MonoBehaviour
{
    public GameObject prop;
    public Transform targetBone;
    public Vector3 positionOffset;
    public Vector3 rotationOffset;
    public bool destroyTrigger = true;
    public RawImage image;

    void OnTriggerEnter(Collider collision)
    {
        AddProp();
    }

    private void AddProp()
    {
        RawImage newprop;
        //newprop = Instantiate(prop, targetBone.position,
        //          targetBone.rotation) as GameObject;
        newprop = Instantiate(image, targetBone.position,
                  targetBone.rotation) as RawImage;
        newprop.name = prop.name;
        newprop.transform.parent = targetBone;
        newprop.transform.localPosition = positionOffset;
        newprop.transform.localEulerAngles = rotationOffset;
        if (destroyTrigger)
            Destroy(gameObject);
    }
}
