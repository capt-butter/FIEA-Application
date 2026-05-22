using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    public float roundtime;
    public float timeremaining;
    bool roundactive;

    List<GameObject> PlayerChars = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //initialtagger();
        roundactive = false;
    }

    // Update is called once per frame
    void Update()
    {
        roundtimer();
    }

    public void StartRound()
    {
        roundactive = true;
        PlayerChars.Clear();
        initialtagger();
        Debug.Log("starting round");
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
        }
        Debug.Log(PlayerChars.Count);
        int i = UnityEngine.Random.Range(0, PlayerChars.Count);
        PlayerChars[i].tag = "CurrentTagger";
        Debug.Log(i);
    }
}
