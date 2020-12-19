using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPuzzle : MonoBehaviour
{
    public List<Transform> pieces;
    public List<Collider> boxes;

    public GameObject projectorParticles;

    private bool activated = false;
    private ParticleSystem projPartSys;

    // Start is called before the first frame update
    void Start()
    {
        projPartSys = projectorParticles.GetComponent<ParticleSystem>();
    }

    public void CheckSolution()
    {
        if (activated)
            return;

        for (int i = 0; i < pieces.Count; i++)
        {
            if (!boxes[i].bounds.Contains(pieces[i].position))
                return;
        }

        activated = true;
        projectorParticles.SetActive(true);
        projPartSys.Play();
    }
}
