using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Collider TaggingBox;
    private string mytag;
    public bool IsIt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mytag = gameObject.tag;
        
    }

    void tagcheck()
    {
        TaggingBox.enabled = false;
        Collider[] detection = Physics.OverlapSphere(TaggingBox.transform.position, 0.5f);
        foreach (Collider test in detection)
        {
            Debug.Log( test.name + " is in the detection sphere");
            if(test.TryGetComponent<PlayerScript>(out PlayerScript TaggedPlayer))
            {
                TaggedPlayer.setrole();
            }
            else
            {
                Debug.Log("this isnt a player to tag");
            }
            
        }
        TaggingBox.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("starting tag check");
            tagcheck();
        }
    }
    void setrole()
    {

    }
}
