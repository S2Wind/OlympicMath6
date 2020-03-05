using UnityEngine;
using UnityEngine.UI;

public class GameScoreControl : MonoBehaviour
{
    [SerializeField] Text score;
    private void Update()
    {
        score.text = PlayerPrefabConfigs.GetScore().ToString();
    }
}
