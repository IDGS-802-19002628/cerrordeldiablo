using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEditor.Progress;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    // Start is called before the first frame update
    private float heartSize = 16f;
    public TextMeshProUGUI textLifeCount;
    public RectTransform hearUI;
    private Explode explode;
    void Start()
    {
        explode = GetComponent<Explode>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            health = health - 1;
            if (health == 0)
            {
                Destroy(gameObject);
                explode.OnExplode();
                
            }
            textLifeCount.text = health.ToString();
            hearUI.sizeDelta = new Vector2(heartSize * health, heartSize);
        }
        if (collision.tag == "Life")
        {
            Destroy(collision.gameObject);
            health = health + 1;
            if (health >= 0)
            {
                health = 3;   
            }
            textLifeCount.text = health.ToString();    
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
