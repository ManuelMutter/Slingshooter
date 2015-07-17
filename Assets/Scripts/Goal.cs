using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	// A static field visible from anywhere
	public static bool goalMet = false;

    public int scoreValue;

   private GameController gameController;

	public GameObject particlevar;


    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find GameController Script");
        }
    }
	void OnTriggerEnter(Collider other) {
		// Check if the hit comes from a projectile
		if(other.gameObject.tag == "Projectile") {
			goalMet = true;

            gameController.AddScoreValue(scoreValue);

			Instantiate (particlevar, transform.position, Quaternion.identity);
			Destroy (this.gameObject);
			// Set alpha to higher opacity

		}
	}
}
