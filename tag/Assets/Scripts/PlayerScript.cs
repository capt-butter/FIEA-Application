using UnityEditor.UI;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Collider TaggingBox;
    private string mytag;
    public bool IsIt;
    bool cantag;
    public float taglockoutlength;
    float taglockouttimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (IsIt == true) 
        {
            gameObject.tag = "CurrentTagger";
        }
        
    }

 
    // Update is called once per frame
    void Update()
    {
        tagantispam();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (IsIt == true && cantag == true)
            {
                Debug.Log("starting tag check");
                tagcheck();
            }
            
        }
        

    }
    void tagcheck()
    {
        TaggingBox.enabled = false;
        Collider[] detection = Physics.OverlapSphere(TaggingBox.transform.position, 0.5f);
        foreach (Collider test in detection)
        {
            Debug.Log(test.name + " is in the detection sphere");
            if (test.TryGetComponent<PlayerScript>(out PlayerScript TaggedPlayer))
            {
                TaggedPlayer.setrole();
                gameObject.tag = "Not It";
            }
            else
            {
                Debug.Log("this isnt a player to tag");
            }
            
        }
        TaggingBox.enabled = true;
        cantag = false;
        taglockouttimer = taglockoutlength;
    }
    void tagantispam()
    {
        if (taglockouttimer <=0)
        {
            cantag = true;
        }
        else 
        {
            taglockouttimer -= Time.deltaTime;
        }
        
    }
    void setrole()
    {
        gameObject.tag = "CurrentTagger";
        Debug.Log("changed the tagger");
    }
}
