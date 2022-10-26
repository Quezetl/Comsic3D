using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lookPrompts : MonoBehaviour
{
    public string tags;
    public string msg;
    public GameObject dialoguebox;
    public float msgTime;
    public string level;

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
    }


    // Update is called once per frame
    void Update()
    { 
    }
}
