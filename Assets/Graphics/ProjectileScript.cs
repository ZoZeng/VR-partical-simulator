using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {
	public static List<GameObject> list = new List<GameObject>();
    
    public Vector3 acc=new Vector3();

	// Use this for initialization
	void Start () {
		list.Add(gameObject);
	}
	
	// Update is called once per frame
	void FixedUpdate (){
		foreach(GameObject g in list){
			var distance= g.transform.position-gameObject.transform.position;
			if(distance.magnitude>0.50){
				acc += (distance.normalized*10f*g.GetComponent<Rigidbody>().mass)/(distance.magnitude*distance.magnitude);
			}

		}
		foreach(GameObject g in eletronScript.list){
			var distance= g.transform.position-gameObject.transform.position;
			if(distance.magnitude>0.50){
				acc += (distance.normalized*10f*g.GetComponent<Rigidbody>().mass)/(distance.magnitude*distance.magnitude);
			}

		}
		foreach(GameObject g in protonSc.list){
			var distance= g.transform.position-gameObject.transform.position;
			if(distance.magnitude>0.50){
				acc += (distance.normalized*10f*g.GetComponent<Rigidbody>().mass)/(distance.magnitude*distance.magnitude);
			}

		}
		gameObject.GetComponent<Rigidbody> ().velocity += acc*Time.deltaTime;

	}
}
