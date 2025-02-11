using UnityEngine;

public class Gutter : MonoBehaviour
{
    private void OnTriggerEnter(Collider triggeredBody)
    {
        if (triggeredBody.CompareTag("Ball"))
        {
            // we first get the rigidbody of the ball
            // and store it in a local variable ballRigidBody
            Rigidbody ballRigidBody = triggeredBody.GetComponent<Rigidbody>();
            //We store the velocity magnitude before resetting the velocity
            float velocityMagnitude = ballRigidBody.linearVelocity.magnitude;
            //It is important to reset the linear AND angular velocity
            //This is because the ball is rotating on the ground when moving
            ballRigidBody.linearVelocity = Vector3.zero;
            ballRigidBody.angularVelocity = Vector3.zero;
            //Now we add force in the forward direction of the gutter
            //We use the cached velocity magnitude to keep it a little realistic
            ballRigidBody.AddForce(transform.forward * velocityMagnitude, ForceMode.VelocityChange);
        }
    }
}
