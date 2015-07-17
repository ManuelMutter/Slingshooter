using UnityEngine;
using System.Collections;

public class Slingshot : MonoBehaviour {

	// Inspector fields
	public GameObject prefabProjectile;
	public float velocityMult = 10.0f;

    public int shotCount;
	public float turnSpeed = 10.0f;
	//public GameObject cameraReference;

	// Internal fields
	private GameObject launchPoint;
	private bool aimingMode; 

	private Vector3 launchPos;
	private GameObject projectile;
    private GameController gameController;
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


	void Awake() {
		Transform launchPointTrans = transform.Find("Launchpoint");
		launchPoint = launchPointTrans.gameObject;
		launchPoint.SetActive(false);
		launchPos = launchPoint.transform.position;







	}

	void OnMouseEnter() {
		//print ("Slingshot:OnMouseEnter");
		launchPoint.SetActive(true);
	}

	void OnMouseExit() {
		//print ("Slingshot:OnMouseExit");
		if(!aimingMode)
			launchPoint.SetActive(false);
	}

	void OnMouseDown() {
		// Set the game to aiming mode
		aimingMode = true;
        gameController.AddShotsCount(shotCount);

		transform.Rotate(Vector3.right, -turnSpeed * Time.deltaTime);
		// Instantiate a projectile
		projectile = Instantiate ( prefabProjectile ) as GameObject;


		// Position the projectile at the launchPoint
		projectile.transform.position = launchPos;

		// Disable kinematic physics for now
		projectile.GetComponent<Rigidbody>().isKinematic = true;
	

			

		
	}


	void Update() {
		// Check aiming mode
		if(!aimingMode) return;

		// Get the mouse position in 3D space
		Vector3 mousePos2D = Input.mousePosition;
		mousePos2D.z = - Camera.main.transform.position.z;
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

		// Calculate the delta between mouse position and launch point
		Vector3 mouseDelta = mousePos3D - launchPos;

		// Constrain the delta to radius of the sphere collider
		float maxMagnitude = this.GetComponent<SphereCollider>().radius;
		mouseDelta = Vector3.ClampMagnitude(mouseDelta, maxMagnitude);

		// Set the projectile to the new position
		Vector3 projPos = launchPos + mouseDelta;
		projectile.transform.position = projPos;

		// Check mouse button released
		if (Input.GetMouseButtonUp(0)) {



//			Projectiles.s.changeShot();
			aimingMode = false;
			projectile.GetComponent<Rigidbody>().isKinematic = false;

			projectile.GetComponent<Rigidbody>().velocity = - mouseDelta * velocityMult;

		
		}

		//check if projectile is still moving
		/*if (projectile.GetComponent<Rigidbody> ().IsSleeping()) {
			Destroy (projectile);
		}

		//if not, delete projectile

*/



	}




}
