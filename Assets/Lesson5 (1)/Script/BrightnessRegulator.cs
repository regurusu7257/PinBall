using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessRegulator : MonoBehaviour
{
    Material myMaterial;

    private float minEmission = 0.2f;

    private float magEmission = 2.0f;

    private int degree = 0;

    private int speed = 5;

    Color defautColor = Color.white;
    // Start is called before the first frame update
    void Start()
    {
        if(tag == "SmallStarTag")
        {
            this.defautColor = Color.white;
        }
        else if (tag == "LargeStarTag")
        {
            this.defautColor = Color.yellow;
        }
        else if (tag == "SmallcloudTag" || tag == "LargeCloudTag")
        {
            this.defautColor = Color.cyan;
        }

        this.myMaterial = GetComponent<Renderer>().material;

        myMaterial.SetColor("_EmissionColor", this.defautColor*minEmission);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.degree >= 0)
        {
            Color emissionColor = this.defautColor * (this.minEmission + Mathf.Sin(this.degree * Mathf.Deg2Rad) * this.magEmission);

            myMaterial.SetColor("_EmissionColor", emissionColor);

            this.degree -= this.speed;
            
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        this.degree = 180;
    }
}
