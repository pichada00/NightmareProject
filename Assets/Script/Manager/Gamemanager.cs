using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class Gamemanager : MonoBehaviour
{
    public static Gamemanager gamemanager { get; private set; }
    private float Min = 10;
    public float Count = 0;
    public bool entrance = false;
    public bool DoorDestroy = false;
    public bool CupboardDestroy = false;
    public List<GameObject> thisDoor = new List<GameObject>();
    public List<GameObject> cupboard = new List<GameObject>();    
    public GameObject Ghost;
    public GameObject Ghost2;
    private GameObject DoorItDestroy;
    private GameObject CupboardItDestroy;
    private FieldOfView field;

    public GameObject waypointStarter;
    public GameObject waypointSecond;
    //backpack
    public GameObject BP;
    public bool open = false;
    public bool control = false;    

    [Space]
    public GameObject PanelSetting;
    private bool PanelSettingOpen;
    private void Awake()
    {
        if(gamemanager == null)
        {
            gamemanager = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Destroy(gameObject);
        }
    }
    void Start()
    {        
        if(PanelSetting)
        PanelSetting.SetActive(PanelSettingOpen);
        field = FieldOfView.field;
        if(BP)
        BP.SetActive(open);
        if (SoundManager.Instance)
        {
            SoundManager.Instance.PlayBGM();
        }
        if(HealthSystem.healthSystem == null)
        {
            control = true;
        }
    }
    public void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            SettingGame();
        }
        if(control == false)
        {
            Lockmouse();
        }
        else 
        {
            UnlockMouse();
        }
        if (Input.GetButtonDown("BP"))
        {
            open = !open;            
        }
        if (open == true && BP!=null)
        {
            OpenBP();
        }
        else if(open == false && BP != null)
        {
            BP.SetActive(false);
        }

    }
    
    public IEnumerator FindPlayerAnimation()
    {
        //playanimator
        yield return new WaitForSeconds(5f);
        //gotowaypoint forloop
    }

    private void Destroyanything(GameObject gameObject)
    {
        for (int i = 0; i < thisDoor.Count; i++)
        {
            //Vector3 nearTarget = (waypointTarget[i].position - transform.position);
            float nearTarget = Vector3.Distance(Ghost.transform.position, thisDoor[i].transform.position);
            if (nearTarget < Min)
            {
                gameObject = thisDoor[i];
            }
        }
    }
    public void ChangeScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    public void SettingGame()
    {
        PanelSettingOpen = !PanelSettingOpen;
        if (PanelSetting)
        {
            PanelSetting.SetActive(PanelSettingOpen);
        }        
        control = !control;        
    }
    public void Lockmouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;       
    }
    public void ChangeBoolOnButton()
    {
        control = false;
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void OpenBP()
    {        
        BP.SetActive(true);
        Debug.Log("open");
    }
    
    public void SpawnGhost(int Count)
    {
        switch (Count)
        {
            case 0:
                Instantiate(Ghost, waypointStarter.transform.position, waypointStarter.transform.rotation);
                break;
            case 1:
                Instantiate(Ghost2, waypointSecond.transform.position, waypointSecond.transform.rotation);
                break;
            default:
                Debug.Log("");
                break;
        }
    }
}
