using UnityEngine;

public class worldcontrollerscript : MonoBehaviour
{
    public float roundtime;
    public float timeremaining;
    bool roundactive;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialtagger();
    }

    // Update is called once per frame
    void Update()
    {
        roundtimer();
    }



    void roundtimer()
    {
        if (Input.GetKeyDown(KeyCode.P) && roundactive == false)
        {

            roundactive = true;
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
                Debug.Log( roundloser.name + " was the last tagger");
            }
        }
    }

    void initialtagger()
    {

    }
}
