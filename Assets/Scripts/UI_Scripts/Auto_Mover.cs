using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_Mover : MonoBehaviour
{
    public Rigidbody2D Character;
    private float keepTrack;

    void Start()
    {
        Character = GetComponent<Rigidbody2D>();
        keepTrack = 120.0f;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * 7.0f * Time.deltaTime;
        keepTrack -= 1 * Time.deltaTime;

        if (keepTrack <= 0.0f)
        {
            transform.position = new Vector3 (0.0f, -1.0f, 0.0f);
            keepTrack = 120.0f;
        }
    }
}
