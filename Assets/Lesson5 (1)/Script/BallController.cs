using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    int score = 0;

    private float visiblePosZ = -6.5f;

    private GameObject gameoverText;

    private GameObject ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        this.gameoverText = GameObject.Find("GameOverText");
        this.ScoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.z < this.visiblePosZ)
        {
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }


    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "LargeStarTag") 
        {
            score += 10;
            this.ScoreText.GetComponent<Text>().text = "Score " + score.ToString();
        }
        if (other.gameObject.tag == "SmallStarTag")
        {
            score += 50;
            this.ScoreText.GetComponent<Text>().text = "Score" + score.ToString();
        }
        if (other.gameObject.tag == "SmallCloudTag")
        {
            score += 20;
            this.ScoreText.GetComponent<Text>().text = "Score" + score.ToString();
        }
        if (other.gameObject.tag == "LargeCloudTag")
        {
            score += 40;
            this.ScoreText.GetComponent<Text>().text = "Score" + score.ToString();
        }
        
    }
}
