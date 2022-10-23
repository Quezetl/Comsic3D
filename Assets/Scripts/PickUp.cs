using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    GameObject Item;
    public GameObject prompt;

    // Start is called before the first frame update
    void Start()
    {
        Item = this.gameObject;
        prompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseExit()
    {

        prompt.SetActive(false);
    }

    private void OnMouseOver()
    {
        prompt.SetActive(true);
        if (Input.GetKey(KeyCode.E))
        {
            Item.SetActive(false);
            prompt.SetActive(false);
        }
    }

}
