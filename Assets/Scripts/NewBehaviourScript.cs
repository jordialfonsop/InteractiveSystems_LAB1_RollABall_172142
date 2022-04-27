using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 20f;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    private int count; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
        winTextObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate () {
         float moveHorizontal = Input.GetAxis("Horizontal");
         float moveVertical = Input.GetAxis("Vertical");
         Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical) * speed;
         rb.AddForce(movement);
     }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
    }

    void setCountText(){
        countText.text = "Count: " + count.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")){
            other.gameObject.SetActive(false);
            count++;
            setCountText();
            if (count >= 12){
                winTextObject.SetActive(true);
            }
        } 
    }
}
