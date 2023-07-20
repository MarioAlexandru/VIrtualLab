using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BucketController : MonoBehaviour
{

	public GameObject particleEffect;
	public Obi.ObiEmitter emitter;
	public GameObject area;
	private bool ok = false;
	public GameObject sfera;
	public GameObject panel;
	

	// Update is called once per frame
	//uih
	void Awake()
	{
		emitter.speed = 0;
	}
	void Update()
	{

		if (Input.GetKey(KeyCode.Space))
		{
			ok = true;
			emitter.speed = 1.5f;
		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.AngleAxis(90, -transform.forward), Time.deltaTime * 50);
			particleEffect.SetActive(false);
		}
		else
		{
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.identity, Time.deltaTime * 100);
		}

		if (Input.GetKey(KeyCode.R))
		{
			//emitter.KillAll();
			Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);

		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			panel.SetActive(true);

		}
		if (Input.GetKeyUp(KeyCode.E))
		{
			panel.SetActive(false);

		}



	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "sphere")
		{
			if (ok)
			{
				//particleEffect.SetActive(True);
				Debug.Log("enter");
				particleEffect.SetActive(true);




			}
		}
	}
	private void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.tag == "sphere")
		{
			Debug.Log("exit");

		}
	}
	IEnumerator MyFunction()
	{

		yield return new WaitForSeconds(6);
		sfera.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
	}
	void Solver_OnCollision(object sender, Obi.ObiSolver.ObiCollisionEventArgs e)
	{
		Debug.Log("enter");
	}

}
