using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private Animator _animateBack;
    public GameObject _backDoor;
    Spawn _trainList;
    Spawn _propList;
    public AudioSource _doorSound;

    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        _animateBack = _backDoor.GetComponent<Animator>();
        _doorSound = GetComponent<AudioSource>();
    }



    private void OnTriggerEnter(Collider collision)
    {
        _animateBack.SetTrigger("CloseTrigger");

        /*if (Spawn._propsList != null)
        {
            for (int i = 0; i < Spawn._propsList.Count; i++)
            {
                Destroy(Spawn._propsList[i].gameObject);
            }
            Spawn._propsList.Clear();
        }*/

        if (Spawn._trainList != null)
        {
            
            for (int i = 0; i < Spawn._trainList.Count; i++)
            {
                _doorSound.Play();
                Destroy(Spawn._trainList[i].gameObject);
            }
            Spawn._trainList.Clear();
        }
        

    }
}
