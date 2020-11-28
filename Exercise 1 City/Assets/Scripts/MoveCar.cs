using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.zero;
        float x = 0;//left or right
        float y = 0;//up or down
        float z = 10 * Time.deltaTime;//forward or back

        GameObject wall = GameObject.Find("Wall");
        GameObject wall1 = GameObject.Find("Wall (1)");
        GameObject wall2 = GameObject.Find("Wall (2)");
        GameObject wall3 = GameObject.Find("Wall (3)");

        if (GetComponent<Collider>().bounds.Intersects(wall.GetComponent<Collider>().bounds))
        {
            transform.Rotate(0, 180, 0);
        }

        if (GetComponent<Collider>().bounds.Intersects(wall1.GetComponent<Collider>().bounds))
        {
            transform.Rotate(0, 180, 0);
        }

        if (GetComponent<Collider>().bounds.Intersects(wall2.GetComponent<Collider>().bounds))
        {
            transform.Rotate(0, 180, 0);
        }

        if (GetComponent<Collider>().bounds.Intersects(wall3.GetComponent<Collider>().bounds))
        {
            transform.Rotate(0, 180, 0);
        }

        transform.Translate(x, y, z);
    }
}
