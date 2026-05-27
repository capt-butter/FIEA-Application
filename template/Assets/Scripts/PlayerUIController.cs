using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    PlayerController playerController;
    Canvas PlayerHUD;
    public TMP_Text playerstatus;
    public Slider sprintbar;
    //text
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        PlayerHUD = GetComponentInChildren<Canvas>();
        //playerstatus.SetText (gameObject.name);
        sprintbar.maxValue = playerController.sprintlength;
    }

    // Update is called once per frame
    void Update()
    {
        //playerstatus.SetText(gameObject.tag);
        sprintbar.value = playerController.sprintleft;
    }

    public void TaggedUIChange()
    {

    }
}
