using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBob : MonoBehaviour
{
    private Transform arrow;
    [SerializeField] private float oscillation;
    [SerializeField] private float oscillationSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        arrow = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        arrow.Translate(new Vector3(0,oscillation * Mathf.Cos(Time.time * oscillationSpeed), 0));
        arrow.Rotate(new Vector3(0, 1, 0));



    }
}
