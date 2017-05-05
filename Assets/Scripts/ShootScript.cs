using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using System.Linq;

public class ShootScript : MonoBehaviour {
	public GameObject eletronPrefab;
    public GameObject projectilePrefab;
	public GameObject protonPrefab;
    public float speed;
    public float startTime;
    public float deltaTime;
    private bool bottonWasDown;
    private float bottonDownTime;
    private int i=1;
	// Use this for initialization
	void Start () {
		bottonWasDown=false;
	}
	
	// Update is called once per frame
	void Update ()
	{

		var joystickNames = Input.GetJoystickNames ();

		if (Input.GetButton ("Fire") || Input.GetButton ("Jump")) {
			if(!bottonWasDown){
				bottonDownTime = Time.time;
			}
			bottonWasDown = true;
				
			// Shoot stuff
			//var projectile = Instantiate (projectilePrefab, transform.position, Quaternion.identity) as GameObject;
			//var projBody = projectile.GetComponent<Rigidbody> ();
			//projBody.velocity = transform.forward * speed;
			//speed++;
		} else if(bottonWasDown) {
			bottonWasDown = false;
			float dt = Time.time - bottonDownTime;
			if(i%2==0){
				var projectile = Instantiate (projectilePrefab, transform.position, Quaternion.identity) as GameObject;
				var projBody = projectile.GetComponent<Rigidbody> ();
				projBody.velocity = transform.forward * speed*dt;
			}else if(i%3==0){
				var proton = Instantiate (protonPrefab, transform.position, Quaternion.identity) as GameObject;
				var protonBody = proton.GetComponent<Rigidbody> ();
				protonBody.velocity = transform.forward * speed*dt;
			}
			else{
				var eletron = Instantiate (eletronPrefab, transform.position, Quaternion.identity) as GameObject;
				var eleBody = eletron.GetComponent<Rigidbody> ();
				eleBody.velocity = transform.forward * speed*dt;
			}
			i++;

		}

        }
	}
