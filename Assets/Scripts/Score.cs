using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts {
    public class Score : MonoBehaviour {
        public Text scoreText;
        public double score;

        private void Start() {
            scoreText.text = "0";
            score = 0;            
        }

        private void Update() {            
            scoreText.text = score.ToString();
        }
    }
}
