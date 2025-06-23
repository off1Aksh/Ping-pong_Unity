using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_member : MonoBehaviour
{

    int[] posX = new int[] { 0, -20, -40, -60, -80,};
    int idx = 0;

    // Use this for initialization
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (idx < posX.Length - 1)
            {
                idx++;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (idx > 0)
            {
                idx--;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(posX[idx], transform.position.y), 35 * Time.deltaTime);
    }
}