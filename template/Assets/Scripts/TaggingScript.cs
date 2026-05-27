using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TaggingScript : MonoBehaviour
{
    public Collider TaggingBox;
    bool cantag;
    public float taglockoutlength;
    float taglockouttimer;

    public Material starter;
    public Material tagger;
    public TMP_Text statustext;

    //public PlayerUIController PlayerHUD;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        taglockouttimer = taglockoutlength;
        //PlayerHUD = gameObject.GetComponent<PlayerUIController>();
    }

    // Update is called once per frame
    void Update()
    {
        tagantispam();
    }

    public void tagcheck(InputAction.CallbackContext context)
    {
        
        if (context.performed) 
        {
            Debug.Log("buttonpress");
            if (cantag == true && gameObject.tag == "CurrentTagger")
            {
                Debug.Log("starting tag attempt");
                TaggingBox.enabled = false;
                Collider[] detection = Physics.OverlapSphere(TaggingBox.transform.position, 0.5f);
                foreach (Collider test in detection)
                {
                    Debug.Log(test.name + " is in the detection sphere");
                    if (test.TryGetComponent<TaggingScript>(out TaggingScript TaggedPlayer))
                    {
                        TaggedPlayer.TaggerChange();
                        gameObject.tag = "Not It";
                        gameObject.GetComponent<MeshRenderer>().material = starter;
                        statustext.text = "runner";
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
            
        }
    }
    void tagantispam()
    {
        
        if (taglockouttimer <= 0)
        {
            cantag = true;
        }
        else
        {
            taglockouttimer -= Time.deltaTime;
        }
        //Debug.Log(taglockouttimer);
    }

    public void TaggerChange()
    {
        gameObject.tag = "CurrentTagger";
        statustext.text = "tagger";
        gameObject.GetComponent<MeshRenderer>().material = tagger;
    }
}
