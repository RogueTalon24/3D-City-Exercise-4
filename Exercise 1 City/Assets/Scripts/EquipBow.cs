using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EquipBow : MonoBehaviour
{
    public GameObject prop;
    public GameObject prop2;
    public Transform targetBone;
    public Transform targetBone2;
    public Transform targetBone1;
    public Vector3 positionOffset;
    public Vector3 rotationOffset;
    public Vector3 positionOffset2;
    public Vector3 rotationOffset2;
    public Vector3 positionOffset1;
    public Vector3 rotationOffset1;
    public bool destroyTrigger = true;
    public float thrust = 1.0f;
    public bool equipped = false;

    public GameObject projectile;
    
    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.Keypad2))
        {
            AddProp(prop, targetBone, positionOffset, rotationOffset);
            AddProp(prop2, targetBone2, positionOffset2, rotationOffset2);
            equipped = true;
            
            if (destroyTrigger)
                Destroy(gameObject);
        }
        //if (equipped == true)
        //{
            //if (Input.GetButtonDown("Fire1"))
            //{
            //    GameObject arrow = Instantiate(prop2, targetBone1.position, targetBone1.rotation) as GameObject;
            //    arrow.name = prop2.name;
            //    arrow.transform.parent = targetBone1;
            //    arrow.transform.localPosition = positionOffset1;
            //    arrow.transform.localEulerAngles = rotationOffset1;
                
            //    arrow.AddComponent<Rigidbody>();

            //    Rigidbody r = arrow.GetComponent<Rigidbody>();
            //    r.AddRelativeForce(new Vector3(0, thrust, 0));
            //    //r.AddForce(transform.forward * thrust);
            //    //r.AddForce(0, 10f, thrust, ForceMode.Impulse);
            //    //r.AddForce(0, 10f, thrust, ForceMode.Force);

            //}
        //}
            
    }

    private void AddProp(GameObject props, Transform bone, Vector3 position, Vector3 rotation)
    {
        GameObject newprop;
        newprop = Instantiate(props, bone.position,
                  bone.rotation) as GameObject;

        //newprop.AddComponent<BoxCollider>();
        Collider c = newprop.GetComponent<Collider>();
        c.isTrigger = true;

        newprop.name = props.name;
        newprop.transform.parent = bone;
        newprop.transform.localPosition = position;
        newprop.transform.localEulerAngles = rotation;

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
