using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
    //Areferencetoour ballController
    [SerializeField] private BallController ball;
    //Areferenceforour PinCollectionprefabwemade inSection 2.2
    [SerializeField] private GameObject pinCollection;
    //Areferenceforan emptyGameObject whichwe'll
    //useto spawnour pincollection prefab
    [SerializeField] private Transform pinAnchor;
    //Areferenceforour inputmanager
    [SerializeField] private InputManager inputManager;
    [SerializeField] private TextMeshProUGUI scoreText;
    private FallTrigger[] fallTriggers;
    private GameObject pinObjects;

    private void Start()
    {
        //Adding theHandleReset functionas alistener toour
        //newly addedOnResetPressedEvent
        inputManager.OnResetPressed.AddListener(HandleReset);
        SetPins();
        pinCollection.SetActive(false);
    }

    private void HandleReset()
    {
        ball.ResetBall();
        pinCollection.SetActive(true);
        SetPins();
        pinCollection.SetActive(false);
    }

    private void SetPins()
    {
        //We firstmake surethat allthe previouspins havebeen destroyed
        //this isso thatwe don'tcreate anew collectionof
        //standing pinsontop ofalready fallenpins

        if (pinObjects)
        {
            foreach (Transform child in pinObjects.transform)
            {
                Destroy(child.gameObject);
            }
            Destroy(pinObjects);
        }

        // We then instatiate a new set of pins to our pin anchor transform
        pinObjects = Instantiate(pinCollection, pinAnchor.position, pinAnchor.rotation);

        // We add the Increment Score function as a listener to
        // the OnPinFall event each of new pins
        fallTriggers = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (FallTrigger pin in fallTriggers)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }
    }

    private void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }
}
