using UnityEngine;
using UnityEngine.Events;
public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    // name booleans like a question
    private bool isBallLaunched;
    private Rigidbody ballRB;
    private InputManager inputManager;
    void Start()
    {
        ballRB = GetComponent<Rigidbody>();
        inputManager.OnSpacePressed.AddListener(LaunchBall);
    }
    private void LaunchBall()
    {
        // now your if check can be framed like a sentence
        // "if ball is launched, then simply return and do nothing"
        if (isBallLaunched) return;
        // "now that the ball is not launched, set it to true and launch the ball"
        isBallLaunched = true;
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
    }
}