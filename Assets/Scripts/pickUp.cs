using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickUp : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject[] inventoryIcons;
    public Text coyoteCount;
    private int coyoteNum;

    public void ObjectPicked(string name)
    {
        switch (name)
        {
            case "coyote":
                coyoteNum++;
                coyoteCount.text = coyoteCount.ToString();

                   
                break;

            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
         foreach (Transform child in inventoryPanel.transform)
        {
            if (child.gameObject.name == collision.gameObject.name)
            {
                string c = child.Find("Text").GetComponent<Text>().text;
                int tcount = System.Int32.Parse(c) + 1;
                child.Find("Text").GetComponent<Text>().text = "" + tcount;

            }
        }

        GameObject i;
        if (collision.gameObject.name == "blueJay try 3")
        {
            i = Instantiate(inventoryIcons[0]);
            i.transform.SetParent(inventoryPanel.transform);
        }

    }
 
}
