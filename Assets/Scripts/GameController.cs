using UnityEngine;
using System.Collections;
using UnityEngine.UI;

enum GameState {
	idle,
	playing,
	levelEnd
}

public class GameController : MonoBehaviour {
	public static GameController S;

	// Public Inspector Fields
	public GameObject[] castles;


	public Vector3 castlePos;

	// Private internal fields

	private int level;
	private int levelMax;
	private int shotsTaken;

	private GameObject castle;

	private GameState state;

	private string showing = "Slingshot";
    public Text txtshotsTaken;
    public Text scoreText;
    private int score;
    private int shotstaken;

    public bool gameWon;

    public GameObject winEffect1;
    public GameObject winEffect2;

    public GameObject winText1;
    public GameObject wintext2;

	void Awake() {
		S = this;

        gameWon = false;
        winText1.SetActive(false);
        wintext2.SetActive(false);

		// Initialize stuff (e.g. level, level Max)
        shotstaken = 0;
        score = 8;
        UpdateScore();
		StartLevel();

	}

	void Update () {
        

         if (score == 0 && gameWon == false){
            gameWon = true;
            print(gameWon);
            Instantiate(winEffect1, this.transform.position, Quaternion.identity);
            Instantiate(winEffect2, this.transform.position, Quaternion.identity);
            winText1.SetActive(true);
            wintext2.SetActive(true);

        
        }
        
	}

	void StartLevel(){

		// If there is a castle, destroy it

		// Destroy all remaining projectiles

		// Instantiate new castle and reset shotsTaken


		// Reset Camera
		SwitchView("Both");

	
	}

	public void SwitchView(string view) {


		// Switch over all possible view "Both", "Castle", "Slingshot"

			// Set the poi of the FollowCam to according value


	}

    void UpdateShotsTaken()
    {
        txtshotsTaken.text = "Shots Taken: " + shotstaken;
    }

    public void AddShotsCount(int newShotCount)
    {
        shotstaken += newShotCount;
        UpdateShotsTaken();

    }


    void UpdateScore()
    {

        scoreText.text = "SHROOMS LEFT: " + score;
    }

    public void AddScoreValue(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();

    }


}
