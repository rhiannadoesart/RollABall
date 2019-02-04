using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotator : MonoBehaviour {


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(-45, 30, -30) * Time.deltaTime);
    }
}
