using System;
using UnityEngine;

namespace GameSystems {
    public static class ScoreSystem {
        public static Action<int> OnScoreChanged;

        private static int _score { // This saves the score to the PlayerPrefs
            get => PlayerPrefs.GetInt("score", 0); 
            set => PlayerPrefs.SetInt("score", value);
        }

        public static void AddScore(int score) {
            _score += score;
            OnScoreChanged?.Invoke(_score);
        }
        
        public static void RemoveScore(int scoreToRemove) {
            if (_score < scoreToRemove) return;
            _score -= scoreToRemove;
            OnScoreChanged?.Invoke(_score);
        }
        
        public static int GetScore() => _score;
    }
}