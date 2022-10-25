using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueMsg : MonoBehaviour
{
    public string msg;
    public GameObject dialoguebox;
    public float msgTime;
    int count = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && count == 0)
        {
            dialoguebox.GetComponentInChildren<TMPro.TextMeshProUGUI>(dialoguebox).text = msg;
            dialoguebox.SetActive(true);
            count++;
            Invoke("disableDialogue", msgTime);
        }
    }


    void disableDialogue()
    {
        dialoguebox.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
