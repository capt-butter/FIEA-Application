using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class GameStateController : MonoBehaviour
{
    public float roundtime;
    public float timeremaining;
    bool roundactive;

    bool secondround;

    //ui stuff
    public Slider roundtimerUI;
    public TMP_Text startup;
    public TMP_Text ending;

    public Material starter;
    public Material tagger;

    List<GameObject> PlayerChars = new List<GameObject>();
    public GameObject[] Spawnpoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //initialtagger();
        roundactive = false;
        roundtimerUI.maxValue = roundtime;
        

        //ui elements for the text to remind players to connect in
        startup.gameObject.SetActive(true);
        ending.gameObject.SetActive(false);
        roundtimerUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        roundtimer();
        roundtimerUI.value = timeremaining;
    }

    public void StartRound()
    {
        if(secondround ==  true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            goto resetscene;
        }
        if (roundactive == false)
        {
            startup.gameObject.SetActive(false);
            startinglocations();
            roundactive = true;
            PlayerChars.Clear();
            initialtagger();
            Debug.Log("starting round");
            roundtimerUI.gameObject.SetActive(true);
        }
        
        
        resetscene:
        Debug.Log("reset things");
    }



    public void roundtimer()
    {
        if (roundactive == false)
        {

            timeremaining = roundtime;


        }


        if (roundactive == true)
        {
            timeremaining -= Time.deltaTime;
            if (timeremaining <= 0)
            {
                roundactive = false;
                Debug.Log("round is over");
                GameObject roundloser = GameObject.FindWithTag("CurrentTagger");
                Debug.Log(roundloser.name + " was the last tagger");
                foreach (var GameObject in PlayerChars)
                {
                    GameObject.tag = "Player";
                }
                roundtimerUI.gameObject.SetActive(false);
                ending.gameObject.SetActive(true);
                secondround = true;
                //ui to set up restarting the level for new round
            }
        }
    }

    public void initialtagger()
    {
        PlayerChars = new List<GameObject>();
        PlayerChars.Clear();
        PlayerChars.AddRange(GameObject.FindGameObjectsWithTag("Players"));
        foreach (var GameObject in PlayerChars)
        {
            GameObject.tag = "Not It";
            //GameObject.transform.position = new Vector3(10, 10, 10);
            //Debug.Log(GameObject.transform.position);
            //Debug.Log(Spawnpoints[1].transform.position);
            //GameObject.transform.position = Spawnpoints[PlayerChars.Count].transform.position;
        }
        Debug.Log(PlayerChars.Count);
        int i = UnityEngine.Random.Range(0, PlayerChars.Count);
        PlayerChars[i].tag = "CurrentTagger";
        var temp = PlayerChars[i].GetComponent<Renderer>();
        temp.material = tagger;
        //Debug.Log(i);
        foreach (var GameObject in PlayerChars)
        {
            
            Debug.Log("moving player");
        }
    }
    public void startinglocations()
    {
        
    }
}
