using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExplosionScript : MonoBehaviour
{

    //List<BodyData> bodyList;
    List<GameObject> objList;
    GameObject Obj;
    GameObject Sphere;
    public bool isPlayer;
    public float massSizeConstant;
    public float massIncRate;
    public float boundX, boundY, boundZ;
    public float lowerStartMass, upperStartMass;
    public Material mat1, mat2, mat3, mat4, mat5, mat6, mat7, mat8, mat9, mat10, mat11, mat12;

    /*class BodyData
    {
        GameObject gobject;
        string name;
        double[] distance;
        bool player;

        public void SetDistance(double[] inDistance)
        {
            distance = inDistance;
        }

        public BodyData(GameObject obj, string inName, bool isPlayer)
        {
            gobject = obj;
            name = inName;
            player = isPlayer;
        }
    }*/

    void Start()
    {
        objList = new List<GameObject>();



        /*BodyData entry = new BodyData(GameObject.Instantiate(gameObject), string.Concat("body", i.ToString()), false);
        bodyList.Add(entry);*/
        for (int i = 0; i < 35; i++)
        {
            if (gameObject.name == "centralObject")
            {
                GameObject tempOBJ = GameObject.Instantiate(gameObject);
                tempOBJ.transform.position = (new Vector3(Random.Range(-boundX, boundX), Random.Range(-boundY, boundY), Random.Range(-boundZ, boundZ)));
                tempOBJ.layer = 0;
                float mass = Random.Range(lowerStartMass, upperStartMass);
                tempOBJ.GetComponent<Rigidbody>().mass = mass;
                tempOBJ.transform.localScale = (new Vector3(mass, mass, mass));
                tempOBJ.isStatic = false;
                if (Random.Range(0, 1) == 1)
                {
                    this.GetComponent<Renderer>().material = mat1;
                }else
                {
                    this.GetComponent<Renderer>().material = mat2;
                }
                objList.Add(tempOBJ);
            }
        }

    }

    

    void Update()
    {

    }

    void FixedUpdate()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];

        float myMass = contact.thisCollider.GetComponent<Rigidbody>().mass;
        float otherMass = contact.otherCollider.GetComponent<Rigidbody>().mass;
        if (otherMass == myMass)
        {
            if (!isPlayer)
            {
                this.transform.position = new Vector3(Random.Range(500.0f, 1500.0f), Random.Range(00.0f, 500.0f), Random.Range(500.0f, 1500.0f));
            }
        }
        else if (otherMass > myMass)
        {
            this.transform.position = new Vector3(Random.Range(500.0f, 1500.0f), Random.Range(00.0f, 500.0f), Random.Range(500.0f, 1500.0f));
            this.GetComponent<Rigidbody>().mass = myMass * massIncRate;
            this.GetComponent<Rigidbody>().transform.localScale += new Vector3(myMass * massSizeConstant, myMass * massSizeConstant, myMass * massSizeConstant);

            if (isPlayer)
            {
                //implememt game over here

            }
        }
        else
        {
            this.GetComponent<Rigidbody>().mass += contact.otherCollider.GetComponent<Rigidbody>().mass;
            this.GetComponent<Rigidbody>().transform.localScale += new Vector3(myMass * massSizeConstant, myMass * massSizeConstant, myMass * massSizeConstant);
        }

		/*if (myMass > 1200)
        {
            if (myMass > 5000)
            {
                this.GetComponent<Renderer>().material = mat12;
            }else
            {
                switch (Random.Range(3, 11)) {
                    case 3:
                        this.GetComponent<Renderer>().material = mat3;
                        break;
                    case 4:
                        this.GetComponent<Renderer>().material = mat4;
                        break;
                    case 5:
                        this.GetComponent<Renderer>().material = mat5;
                        break;
                    case 6:
                        this.GetComponent<Renderer>().material = mat6;
                        break;
                    case 7:
                        this.GetComponent<Renderer>().material = mat7;
                        break;
                    case 8:
                        this.GetComponent<Renderer>().material = mat8;
                        break;
                    case 9:
                        this.GetComponent<Renderer>().material = mat9;
                        break;
                    case 10:
                        this.GetComponent<Renderer>().material = mat10;
                        break;
                    case 11:
                        this.GetComponent<Renderer>().material = mat11;
                        break;
                }

            }
        }*/
    }
}
