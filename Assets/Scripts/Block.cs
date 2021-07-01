using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public bool IsSpecial = false;
    public bool Enabled = true;
    public Material NormalMaterial;
    public Material SpecialMaterial;
    // Start is called before the first frame update
    void Start()
    {
        SetMaterial();
        Enabled = true;
    }

    // Update is called once per frame
    private void OnValidate()
    {
        SetMaterial();
    }
    void SetMaterial()
    {
        GetComponent<Renderer>().material = IsSpecial ? SpecialMaterial : NormalMaterial;
        
    }
    private void OnMouseDrag()
    {
        if (FindObjectOfType<GameControler>().IsPlaying == false) return;
        var cameraPosition = FindObjectOfType<Camera>().transform.position;
        var direction = (cameraPosition - transform.position).normalized;

        GetComponent<Rigidbody>().AddForce(direction * 50f);
    }
}
