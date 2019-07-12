using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
   private Rigidbody2D rb2d;
   public float speed;
   public Text countText, winText;

   private int count;
       void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        count = 0;
        countText.text = "Count: " + count.ToString ();
        winText.text = "";

        if (count >= 8)
        {
            winText.text = "You Win!";
        }
    }

   
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moverVertical = Input.GetAxis ("Vertical");
        Vector2 movement = new Vector2 (moveHorizontal, moverVertical);
        rb2d.AddForce (movement * speed);
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("PickUp"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            countText.text = "Count: " + count.ToString();
        }
           if (count >= 8)
        {
            winText.text = "You Win!";
        }
    }

}
