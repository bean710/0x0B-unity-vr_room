using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPuzzle : MonoBehaviour
{
    public List<Transform> pieces;
    public List<Collider> boxes;

    public GameObject projectorParticles;
    public Animator door;

    private bool activated = false;
    private ParticleSystem projPartSys;

    // Start is called before the first frame update
    void Start()
    {
        projPartSys = projectorParticles.GetComponent<ParticleSystem>();
    }

    public void CheckSolution()
    {
        //QuestDebug.Instance.Log("Checking Solution");
        if (activated)
            return;

        for (int i = 0; i < pieces.Count; i++)
        {
            bool pieceIn = boxes[i].bounds.Contains(pieces[i].position);
            //QuestDebug.Instance.Log($"Piece {i} is {(pieceIn ? "" : "not")} in");
            if (!pieceIn)
                return;
        }

        //QuestDebug.Instance.Log("Activating projector");
        activated = true;
        projectorParticles.SetActive(true);
        projPartSys.Play();
        door.SetBool("character_nearby", true);
    }
}
