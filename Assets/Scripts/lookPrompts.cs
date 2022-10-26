using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookPrompts : MonoBehaviour
{
    public string tags;
    public string thisthis;
    public GameObject dialoguebox;
    public float msgTime;
    // Start is called before the first frame update
    void Start()
    {

    }


    private void OnMouseExit()
    {
        dialoguebox.SetActive(false);
    }
    private void OnMouseEnter()
    {
        dialoguebox.GetComponentInChildren<TMPro.TextMeshProUGUI>(dialoguebox).text = "Press 'E' to Interact";
        dialoguebox.SetActive(true);
        if (Input.GetKeyDown(KeyCode.E))
        {
            dialoguebox.GetComponentInChildren<TMPro.TextMeshProUGUI>(dialoguebox).text = thisthis;
        }
    }


    // Update is called once per frame
    void Update()
    {
       
    }
}
