﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Obi;

public class MazeManager : MonoBehaviour
{
    [System.Serializable]
    public class ScoreChangedEvent : UnityEvent<int,int> { }

    public ObiSolver solver;
    public ObiEmitter emitter;
    public FluidColorizer[] colorizers;
    public ObiCollider finishLine;

    public float angularAcceleration = 5;

    [Range(0,1)]
    public float angularDrag = 0.2f;

    public Text completionLabel;
    public Text purityLabel;
    public Text finishLabel;

    HashSet<int> finishedParticles = new HashSet<int>();
    HashSet<int> coloredParticles = new HashSet<int>();

    float angularSpeed = 0;
    float angle = 0;

    // Start is called before the first frame update
    void Start()
    {
        solver.OnCollision += Solver_OnCollision;
        emitter.OnEmitParticle += Emitter_OnEmitParticle;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void OnDestroy()
    {
        solver.OnCollision -= Solver_OnCollision;
        emitter.OnEmitParticle -= Emitter_OnEmitParticle;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            angularSpeed += angularAcceleration * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            angularSpeed -= angularAcceleration * Time.deltaTime;
        }
        angularSpeed *= Mathf.Pow(1 - angularDrag, Time.deltaTime);
        angle += angularSpeed * Time.deltaTime;

        transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.rotation = Quaternion.identity;
            angularSpeed = angle = 0;
            finishedParticles.Clear();
            coloredParticles.Clear();
            finishLabel.gameObject.SetActive(false);
            UpdateScore(finishedParticles.Count, coloredParticles.Count);
            emitter.KillAll();
        }
    }

    void Emitter_OnEmitParticle(ObiEmitter em, int particleIndex)
    {
        int k = emitter.solverIndices[particleIndex];
        solver.userData[k] = solver.colors[k];
    }

    private void Solver_OnCollision(ObiSolver s, ObiSolver.ObiCollisionEventArgs e)
    {
        var world = ObiColliderWorld.GetInstance();
        foreach (Oni.Contact contact in e.contacts)
        {
            // look for actual contacts only:
            if (contact.distance < 0.01f)
            {
                var col = world.colliderHandles[contact.other].owner;
                if (colorizers[0].collider == col)
                {
                    solver.userData[contact.particle] = colorizers[0].color;
                    if (coloredParticles.Add(contact.particle))
                        UpdateScore(finishedParticles.Count, coloredParticles.Count);
                }
                else if (colorizers[1].collider == col)
                {
                    solver.userData[contact.particle] = colorizers[1].color;
                    if (coloredParticles.Add(contact.particle))
                        UpdateScore(finishedParticles.Count, coloredParticles.Count);
                }
                else if (finishLine == col)
                {
                    if (finishedParticles.Add(contact.particle))
                        UpdateScore(finishedParticles.Count, coloredParticles.Count);
                }

            }
        }
    }

    void LateUpdate()
    {
        for (int i = 0; i < emitter.solverIndices.Length; ++i)
        {
            int k = emitter.solverIndices[i];
            emitter.solver.colors[k] = emitter.solver.userData[k];
        }
    }

    public void UpdateScore(int finishedParticles, int coloredParticles)
    {
        int completion = Mathf.CeilToInt(finishedParticles / 600.0f * 100);
        int purity = Mathf.CeilToInt((1 - coloredParticles / 600.0f) * 100);

        completionLabel.text = completion + "% Completat";
        purityLabel.text = purity + "% Pur";

        if (completion > 90)
        {
            if (purity > 95)
            {
                finishLabel.text = "Bravo! Ai reusit";
                finishLabel.color = new Color(0.2f, 0.8f, 0.2f);
            }
            else if (purity > 75)
            {
                finishLabel.text = "Super! Destul de bine";
                finishLabel.color = new Color(0.5f, 0.8f, 0.2f);
            }
            else if (purity > 50)
            {
                finishLabel.text = "Bravo! Puteai mai bine";
                finishLabel.color = new Color(0.8f, 0.5f, 0.2f);
            }
            else if (purity > 25)
            {
                finishLabel.text = "Gata.. dar nu chiar asa de bine";
                finishLabel.color = new Color(0.8f, 0.2f, 0.2f);
            }
            else
            {
                finishLabel.text = "Mai incearca odata";
                finishLabel.color = new Color(0.2f, 0.2f, 0.2f);
            }
            finishLabel.gameObject.SetActive(true);
        }
    }
}
