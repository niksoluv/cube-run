using Assets.Scripts;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public float restartDelay = 1f;
	public GameObject completeLevelUI;

	public void CompleteLevel() {
		completeLevelUI.SetActive(true);
		Debug.Log("Level Complete!");
	}

	public void EndGame() {
		
		BinaryFormatter formatter = new BinaryFormatter();

		using (FileStream fs = new FileStream("player.dat", FileMode.OpenOrCreate)) {
			Player p = (Player)formatter.Deserialize(fs);

			int highScore = FindObjectOfType<Score>().GetScore();
			if (p.HighScore < highScore)
				p.HighScore = highScore;
			p.NumOfAttempts++;

			formatter.Serialize(fs, p);
		}

		Debug.Log("Game Over!");
		Invoke("Restart", restartDelay);
	}

	private void Restart() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}