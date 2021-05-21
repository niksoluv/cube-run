using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts {
	[Serializable]
	class Player {
		public int NumOfAttempts { get; set; }
		public int HighScore { get; set; }

		public Player() {

		}

		public Player(int numOfAttempts, int highScore) {
			NumOfAttempts = numOfAttempts;
			HighScore = highScore;
		}
	}
}
