using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceTrigger : MonoBehaviour
{
    public ChessPuzzle chessPuzzle;

    private void OnCollisionEnter(Collision other) {
        chessPuzzle.CheckSolution();
    }
}
