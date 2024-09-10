using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Spawn : MonoBehaviour
{
    //get door animation
    private Animator _animateFront;
    //create's a field we can drag objects into on the unity interface
    public GameObject _frontDoor;
    public GameObject _bottle;
    public GameObject _suitcase;
    public GameObject _hat;
    public GameObject _book;
    public AudioSource _doorSound;

    public GameObject _spawnTrain;
    public GameObject _spawnTrainSS;
    public GameObject _spawnTrainCC;
    public GameObject _spawnTrainHR;
    public Vector3 _trainOffset;
    float TzVal;

    //get the position of the spawn points by making a field on the unity interface we can drag the points into
    public Vector3 _sPoint1;
    public Vector3 _sPoint2;
    public Vector3 _sPoint3;
    public Vector3 _sPoint4;
    public Vector3 _sPoint5;
    public Vector3 _sPoint6;
    public Vector3 _sPoint7;
    public Vector3 _sPoint8;
    public Vector3 _sPoint9;
    public Vector3 _sPoint10;
    public Vector3 _sPoint11;
    public Vector3 _sPoint12;

    public List<Transform> _spawnPts = new List<Transform>();
    public static List<GameObject> _trainList = new List<GameObject>();
    public static List<GameObject> _propsList = new List<GameObject>();
    public List<GameObject> _nextTrain = new List<GameObject>();

    bool hasSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        TzVal = 6.15f;
        _trainOffset = new Vector3(0, 0, TzVal);

        _animateFront = _frontDoor.GetComponent<Animator>();
        _doorSound = GetComponent<AudioSource>();
    }

    //prepping next cart to spawn objects
    public void spawnProps()
    {
        
        int bottleRoll = Random.Range(1, 4);
        if (bottleRoll == 1)
        {
            //Spawn bottle as a gameobject as a child of the train's transform
            GameObject temp = (GameObject)Instantiate(_bottle,this.transform.parent) as GameObject;
            //Overwrite the bottle's position and rotation from the train's transform to its own, bc by default it's set to world space so we can change it at will
            temp.transform.position = _spawnPts[Random.Range(0, _spawnPts.Count)].position;
            temp.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        }
        else if (bottleRoll == 2)
        {
            ;
        }

        int suitcaseRoll = Random.Range(1, 4);
        if (suitcaseRoll == 1)
        {
            GameObject temp = (GameObject)Instantiate(_suitcase, this.transform.parent) as GameObject;
            temp.transform.position = _spawnPts[Random.Range(0, _spawnPts.Count)].position;
            temp.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        }
        else if (suitcaseRoll == 2)
        {
            ;
        }

        int hatRoll = Random.Range(1, 4);
        if (hatRoll == 1)
        {
            GameObject temp = (GameObject)Instantiate(_hat, this.transform.parent) as GameObject;
            temp.transform.position = _spawnPts[Random.Range(0, _spawnPts.Count)].position;
            temp.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        }
        else if (hatRoll == 2)
        {
            ;
        }

        int bookRoll = Random.Range(1, 5);
        if (bookRoll == 1)
        {
            GameObject temp = (GameObject)Instantiate(_book, this.transform.parent) as GameObject;
            temp.transform.position = _spawnPts[Random.Range(0, _spawnPts.Count)].position;
            temp.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        }
        else if (bookRoll == 2)
        {
            ;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && hasSpawned == false)
        {
            _trainList.Add(this.transform.parent.gameObject);
            GameObject tempSpawned = (GameObject)Instantiate(_spawnTrainSS, this.transform.parent.position + _trainOffset, Quaternion.identity) as GameObject;
            tempSpawned.GetComponentInChildren<Spawn>().spawnProps();
            hasSpawned = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && hasSpawned == false)
        {
            _trainList.Add(this.transform.parent.gameObject);
            GameObject tempSpawned = (GameObject)Instantiate(_spawnTrainCC, this.transform.parent.position + _trainOffset, Quaternion.identity) as GameObject;
            tempSpawned.GetComponentInChildren<Spawn>().spawnProps();
            hasSpawned = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && hasSpawned == false)
        {
            _trainList.Add(this.transform.parent.gameObject);
            GameObject tempSpawned = (GameObject)Instantiate(_spawnTrainHR, this.transform.parent.position + _trainOffset, Quaternion.identity) as GameObject;
            tempSpawned.GetComponentInChildren<Spawn>().spawnProps();
            hasSpawned = true;
        }
    }

    //when run into spawn trigger do these things
    private void OnTriggerEnter(Collider collision)
    {
        _animateFront.SetTrigger("OpenTrigger");
        if (hasSpawned == false)
        {
            _doorSound.Play();

            //add the train that did the spawning to the list
            _trainList.Add(this.transform.parent.gameObject);

            int trainRoll = Random.Range(1, 9);
            if (trainRoll < 3 && !_spawnTrainSS.activeInHierarchy)
            {
                GameObject tempSpawned = (GameObject)Instantiate(_spawnTrainSS, this.transform.parent.position + _trainOffset, Quaternion.identity) as GameObject;
                tempSpawned.GetComponentInChildren<Spawn>().spawnProps();
            } 
            else if (trainRoll < 5 && !_spawnTrainCC.activeInHierarchy)
            {
                GameObject tempSpawned = (GameObject)Instantiate(_spawnTrainCC, this.transform.parent.position + _trainOffset, Quaternion.identity) as GameObject;
                tempSpawned.GetComponentInChildren<Spawn>().spawnProps();
            }
            else if (trainRoll < 8)
            {
                GameObject tempSpawned = (GameObject)Instantiate(_spawnTrain, this.transform.parent.position + _trainOffset, Quaternion.identity) as GameObject;
                tempSpawned.GetComponentInChildren<Spawn>().spawnProps();
            }
            else if (trainRoll > 7 && !_spawnTrainHR.activeInHierarchy)
            {
                GameObject tempSpawned = (GameObject)Instantiate(_spawnTrainHR, this.transform.parent.position + _trainOffset, Quaternion.identity) as GameObject;
                tempSpawned.GetComponentInChildren<Spawn>().spawnProps();
            } 
            else 
            {
                GameObject tempSpawned = (GameObject)Instantiate(_spawnTrain, this.transform.parent.position + _trainOffset, Quaternion.identity) as GameObject;
                tempSpawned.GetComponentInChildren<Spawn>().spawnProps();
            }


            //spawn next cart as a gameobject
            //GameObject tempSpawned = (GameObject)Instantiate(_spawnTrain, this.transform.parent.position + _trainOffset, Quaternion.identity) as GameObject;

            //get the spawn script in the next cart to play the spawnProps function
            //tempSpawned.GetComponentInChildren<Spawn>().spawnProps();
            
            hasSpawned = true;
      
        }

    }



}
