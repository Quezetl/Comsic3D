using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doNotPassGo : MonoBehaviour
{
    public GameObject dialoguebox;
    public float msgTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            dialoguebox.GetComponentInChildren<TMPro.TextMeshProUGUI>(dialoguebox).text = "I think I should check out the ship first";
            dialoguebox.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Invoke("disableDialogue", msgTime);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
