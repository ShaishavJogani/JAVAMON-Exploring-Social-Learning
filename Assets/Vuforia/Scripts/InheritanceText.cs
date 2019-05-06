using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InheritanceText : MonoBehaviour {

	private GameObject c1;
	private GameObject c2;
	private GameObject c3;
	public Text content;

	string c1Text = null;
	string c2Text = null;
	string c3Text = null;



	// Use this for initialization
	void Start () {
		c1 = GameObject.Find("Charmander");
		c2 = GameObject.Find("Charmeleon");
		c3 = GameObject.Find("Charizard");

		c1Text = "Inheritance is an important pillar of OOP(Object Oriented Programming). It is the mechanism in java by which one class is allow to inherit the features(fields and methods) of another class.";
	    c1Text = c1Text + "\n\nSuper Class: The class whose features are inherited is known as super class(or a base class or a parent class).\n\n";
		c1Text = c1Text + "\tpublic class Charmander {\n";
		c1Text = c1Text + "\t\tint power = 50;\n";
		c1Text = c1Text + "\t}";


		c2Text = "Sub Class: The class that inherits the other class is known as sub class(or a derived class, extended class, or child class). The subclass can add its own fields and methods in addition to the superclass fields and methods.\n\n";
		c2Text = c2Text + "\tpublic class Charmeleon extends Charmander {" + "\n";
		c2Text = c2Text + "\t\tint power = 100;" + "\n";
		c2Text = c2Text + "\t\tFire getFire() { return OrangeFlame; };" + "\n";
		c2Text = c2Text + "\t}" + "\n";


		c3Text = "Reusability: Inheritance supports the concept of “reusability”, i.e. when we want to create a new class and there is already a class that includes some of the code that we want, we can derive our new class from the existing class. By doing this, we are reusing the fields and methods of the existing class.\n\n";
		c3Text = c3Text + "\tpublic class Charizard extends Charmeleon implements Flyable{" + "\n";
		c3Text = c3Text + "\t\tint power = 200;" + "\n";
		c3Text = c3Text + "\t\tboolean canFly = true;" + "\n";
		c3Text = c3Text + "\t\tFire getFire() { return blueFlame;};" + "\n";
		c3Text = c3Text + "\t}" + "\n";


	}

	// Update is called once per frame
	void Update () {
		if(c1.activeSelf) {
			content.text = c1Text;
		} else if(c2.activeSelf) {
			content.text = c2Text;
		} else {
			content.text = c3Text;
		}
	}
}
