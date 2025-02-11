using UnityEngine;
using UnityEngine.Events;
public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private Transform launchIndicator;

    // name booleans like a question
    private bool isBallLaunched;
    private Rigidbody ballRB;

    void Start()
    {
        //Grabbing a reference to RigidBody
        ballRB = GetComponent<Rigidbody>();
        // Add a listener to the OnSpacePressed event.
        // When the space key is pressed the
        // LaunchBall method will be called.
        inputManager.OnSpacePressed.AddListener(LaunchBall);
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
        ballRB.isKinematic = true;
    }
    private void LaunchBall()
    {
        // now your if check can be framed like a sentence
        // "if ball is launched, then simply return and do nothing"
        if (isBallLaunched) return;
        // "now that the ball is not launched, set it to true and launch the ball"
        isBallLaunched = true;
        transform.parent = null;
        ballRB.isKinematic = false;
        ballRB.AddForce(launchIndicator.forward * force, ForceMode.Impulse);
        launchIndicator.gameObject.SetActive(false);
    }
}