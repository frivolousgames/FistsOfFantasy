using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOpponentIntroScene : MonoBehaviour {

	void LoadOppIntroScene()
    {
        PreviewPlayer.isClickedPlayer = false;
        GameManager.NextMatch();
    }
}
