using UnityEngine;
using System.Collections;

public class Projectiles : MonoBehaviour {
	public static Projectiles s;
	public GameObject particlevarx;

	public bool shot;

   

    private GameController gameController;

	public float turnSpeed = 50.0f;
	void Start(){
		s = this;

		shot = false;

		InvokeRepeating("Particle", 0, 1);
       
	}


	// Update is called once per frame
	void Particle () {

		Instantiate (particlevarx,this.transform.position,Quaternion.identity);

	}
	//check if shot

	//
	void Update() {
		transform.Rotate(Vector3.right, -turnSpeed * Time.deltaTime);
		//if (this.GetComponent<Rigidbody>().IsSleeping ()) {

        
			Destroy (this.gameObject, 8.0f);
			//return;
		}
	}

	//public void changeShot () {
//		shot = true;


//	}






