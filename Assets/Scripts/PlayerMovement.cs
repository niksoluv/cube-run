using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewayForce = 500f;

    public bool gameOver = true;

    void FixedUpdate() {

        if (Input.GetKey("space")) {
            gameOver = false;
        }

        if (gameOver == false) {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);

            if (Input.GetKey("d") || Input.GetKey("right")) {
                rb.AddForce(sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            if (Input.GetKey("a") || Input.GetKey("left")) {
                rb.AddForce(-sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }

            if (rb.position.y < -1f) {
                FindObjectOfType<GameManager>().EndGame();
            }
        }
    }
}
