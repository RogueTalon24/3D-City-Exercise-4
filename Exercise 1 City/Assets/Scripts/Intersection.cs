using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intersection : MonoBehaviour
{
    //keep track of what car hits intersection first
    public GameObject first;
    public GameObject second;
    public GameObject third;
    public GameObject fourth;
    public bool crossing = false;
    public int order = 0;

    private bool wait1 = false;
    private bool wait2 = false;
    private bool wait3 = false;
    private bool wait4 = false;

    public GameObject car1;
    public GameObject car2;
    public GameObject car3;
    public GameObject car4;

    // Start is called before the first frame update
    void Start()
    {
        car1 = GameObject.Find("Car1");
        car2 = GameObject.Find("Car7");
        car3 = GameObject.Find("Car8");
        car4 = GameObject.Find("Car3");
        first = car3;
        second = car4;
        third = car1;
        fourth = car2;
    }

    // Update is called once per frame
    void Update()
    {
        //stops car when gets to intersection
        if (GetComponent<Collider>().bounds.Intersects(car1.GetComponent<Collider>().bounds))
        {
            float z = -10 * Time.deltaTime;
            float x = 0;
            float y = 0;
            car1.transform.Translate(x, y, z);
            wait1 = true;
        }
        if (GetComponent<Collider>().bounds.Intersects(car2.GetComponent<Collider>().bounds))
        {
            float z = -10 * Time.deltaTime;
            float x = 0;
            float y = 0;
            car2.transform.Translate(x, y, z);
            wait2 = true;
        }
        if (GetComponent<Collider>().bounds.Intersects(car3.GetComponent<Collider>().bounds))
        {
            float z = -10 * Time.deltaTime;
            float x = 0;
            float y = 0;
            car3.transform.Translate(x, y, z);
            wait3 = true;
        }
        if (GetComponent<Collider>().bounds.Intersects(car4.GetComponent<Collider>().bounds))
        {
            float z = -10 * Time.deltaTime;
            float x = 0;
            float y = 0;
            car4.transform.Translate(x, y, z);
            wait4 = true;
        }

        if(wait1==true||wait2==true||wait3==true||wait4 == true)
        {
            cross();
        }
        
    }

    void cross()
    {
        //move 1 car at time across intersection
        switch (order)
        {
            case (0):
                crossing = true;
                if (crossing == true)
                {
                    float x = 0;
                    float y = 0;
                    float z = 10 * Time.deltaTime;
                    first.transform.Translate(x, y, z);
                    crossing = true;
                    wait1 = false;
                }
                if (first.GetComponent<Collider>().bounds.Intersects(GetComponent<Collider>().bounds) == false)
                {
                    crossing = false;
                    order = 1;
                }

                break;
            case (1):
                crossing = true;
                if (crossing == true)
                {
                    float x = 0;
                    float y = 0;
                    float z = 10 * Time.deltaTime;
                    second.transform.Translate(x, y, z);
                    crossing = true;
                    wait2 = false;
                }
                if (second.GetComponent<Collider>().bounds.Intersects(GetComponent<Collider>().bounds) == false)
                {
                    crossing = false;
                    order = 2;
                }

                break;
            case (2):
                crossing = true;
                if (crossing == true)
                {
                    float x = 0;
                    float y = 0;
                    float z = 10 * Time.deltaTime;
                    third.transform.Translate(x, y, z);
                    crossing = true;
                    wait3 = false;
                }
                if (third.GetComponent<Collider>().bounds.Intersects(GetComponent<Collider>().bounds) == false)
                {
                    crossing = false;
                    order = 3;
                }

                break;
            case (3):
                crossing = true;
                if (crossing == true)
                {
                    float x = 0;
                    float y = 0;
                    float z = 10 * Time.deltaTime;
                    fourth.transform.Translate(x, y, z);
                    crossing = true;
                    wait4 = false;
                }
                if (fourth.GetComponent<Collider>().bounds.Intersects(GetComponent<Collider>().bounds) == false)
                {
                    crossing = false;
                    order = 0;
                }

                break;
        }
    }
}
