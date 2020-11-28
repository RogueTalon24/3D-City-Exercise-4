using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSword: MonoBehaviour
{
    public GameObject prop;
    public Transform targetBone;
    public Vector3 positionOffset;
    public Vector3 rotationOffset;
    public bool destroyTrigger = true;
    private bool equipped = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad1))
        {
            //bool addPropCondition = targetBone.IsChildOf() & !AlreadyHalreadyHasChildObject();
            //if (addPropCondition)
                AddProp(prop, targetBone);
            equipped = true;
            if (destroyTrigger)
                Destroy(gameObject);
        }

    }

    private void AddProp(GameObject props, Transform bone)
    {
        GameObject newprop;
        newprop = Instantiate(props, bone.position,
                  bone.rotation) as GameObject;
        
        newprop.AddComponent<BoxCollider>();
        Collider c = newprop.GetComponent<Collider>();
        c.isTrigger = true;

        newprop.name = props.name;
        newprop.transform.parent = bone;
        newprop.transform.localPosition = positionOffset;
        newprop.transform.localEulerAngles = rotationOffset;
        
    }

    private bool AlreadyHalreadyHasChildObject()
    {
        string propName = prop.name;
        foreach (Transform child in targetBone)
        {
            if (child.name == propName)
                return true;
        }
        return false;
    }
}
