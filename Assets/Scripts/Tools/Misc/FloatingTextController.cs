using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextController : MonoBehaviour
{
    public float time;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, time);
        transform.position += new Vector3(Random.Range(-offset.x, offset.x), Random.Range(-offset.y, offset.y), Random.Range(-offset.z, offset.z));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
