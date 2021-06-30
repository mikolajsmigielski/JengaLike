using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameControler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int CountBlocks(bool special)
    {
        return FindObjectsOfType<Block>().Count(block => block.Enabled && block.IsSpecial == special);
    }
    public void OnTriggerEnter(Collider other)
    {
        var block = other.GetComponent<Block>();
        if (block == null) return;
        block.Enabled = false;
        if (block.IsSpecial)
        {
            Debug.Log("You DeD");
        }
        else if (CountBlocks(special: false) == 0)
        {
            Debug.Log("Wygrales");
        }
        Destroy(block.gameObject);
    }
}
