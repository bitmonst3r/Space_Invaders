using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public Transform shottingOffset;
    float moveSpeed = 10;

    // Player score 
    public static float score = 0;
    public static float highScore = 0;
    [SerializeField]public Text scoreText;
    [SerializeField]public Text highScoreText;

    // Update is called once per frame
    void Update()
    {
        // Score text format
        scoreText.text = "00" + score;
        highScoreText.text = "00" + highScore;
        if (score > 99)
        {
            scoreText.text = "0" + score;
        }
        if (highScore > 99)
        {
            highScoreText.text = "0" + highScore;
        }

        // Checks for input, if its space bar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // We instantiate a new copy of the bullet prefab
            GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
            Debug.Log("Bang!");
        
            // Shot is destroyed in 3 sec
            Destroy(shot, 3f);
        }

        // Moves player left and right due to axis & transform 
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime);     
    }
}
