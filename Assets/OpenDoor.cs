using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    private Animator _animateFront;
    public GameObject _frontDoor;


    // Start is called before the first frame update
    void Start()
    {
        _animateFront = _frontDoor.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        _animateFront.SetTrigger("OpenTrigger");


    }
}
