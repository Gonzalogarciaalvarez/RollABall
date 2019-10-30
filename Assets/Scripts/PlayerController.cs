using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Text loseText;

    private Rigidbody rb;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = " ";
        loseText.text = " ";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);

    }

    void OnTriggerEnter(Collider other)
    {
        Renderer rend = other.GetComponent<Renderer>();
        Material m = rend.material;

        if (other.gameObject.CompareTag("Coleccionable"))
        {
            m.color = Color.cyan;
            other.tag = "Going";
            count = count +1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Going")){
            m.color = Color.gray;
            other.tag = "Gone";
            count = count +1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Gone")){
            other.gameObject.SetActive(false);
            count = count +1;
            SetCountText();
        }
    }

        void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Enemigo") {
            Destroy (gameObject, .1f);
            winText.text = "Perdiste";
        }
    }

    void SetCountText()
    {
        countText.text = "Puntos: " + count.ToString();
        if (count >= 36)
        {
            winText.text = "¡GANASTE!";
        }
    }

}
