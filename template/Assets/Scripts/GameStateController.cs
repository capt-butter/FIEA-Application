using UnityEngine;

public class GameStateController : MonoBehaviour
{
    public float roundtime;
    public float timeremaining;
    bool roundactive;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialtagger();
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
                //GameObject roundloser = GameObject.FindWithTag("CurrentTagger");
                //Debug.Log(roundloser.name + " was the last tagger");
            }
        }
    }

    void initialtagger()
    {

    }
}
