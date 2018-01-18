using System;

using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics.PerformanceData;
using System.Linq;
//using UnityEditor;
using UnityEngine;
using UnityEngine.VR.WSA;


public class towersScript : MonoBehaviour
{
	//public Rigidbody rb;
	public float speed = 1f;
	[SerializeField]private int current = 0;
	
	private Vector3 mot;
	private Vector3 mot1;
	private float mydisk;
	
	private int current1 = 0;
	public  GameObject[] dsk = new GameObject[3];        // the disks
	public GameObject elana3ayzo;
	private Vector3[][] mohamed;
	private Vector3[] transes = new Vector3[21];
	private int f;

	
	
	
	public Transform []p;     // target postions on the screen
	private Vector3[] mypos=new Vector3[3];          // the vectors that represent the path
	//private double diff1 = double.MaxValue;//dsk[0].gameObject.transform.position.y - p[1].gameObject.transform.position.y;
	private int i = 0;

	
	
	

	 void towersOfHanoi(int n , Vector3 source , Vector3 dest, Vector3 temp)
	{


		
		double min = double.MaxValue;
		
		if (n == 0)
		{
			//print(n);

			//print("move from"+source.z+"  to destination"+dest.z);
		
			

			/*for (int i = 0; i < dsk.Length; i++)
			{
				if ( source.y - dsk[i].transform.position.y < diff1)
				{
					
				}
			}

			 mydisk = gameObject.transform.position.y;*/
			/*for (int i = 0; i < dsk.Length ; i++)
			{
				if (dsk[i].transform.position.y - (source.y + 10) == min)
				{

				}
				
			}*/
			FindPath( source, dest);
			min = double.MaxValue;
			
			
			for (int i = 0; i < dsk.Length; i++)
			{
				if (dsk[i].transform.position.z==mypos[0].z)
				{
					if ((mypos[0].y) - dsk[i].transform.position.y < min)
					{
						min = (mypos[0].y)-dsk[i].transform.position.y;
						elana3ayzo=dsk[i];
						f = i;

						
					}
						
					

				}
				
			}
			LateUpdate();
			
			//print(f);

		//	print(elana3ayzo.gameObject.name);
			//print(mypos[0].z+"to "+mypos[1].z + "and" + mypos[2].z);
			/*for (int i = 0; i < 7; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					mohamed[i][j] = mypos[j];

				}
				
			}
			for (int i = 0; i < 7; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					print(mohamed[i][j].z);
				}
			}*/
			//performMovement(dsk[i]);
			


		}
		else
		{
			towersOfHanoi(n-1 ,  source ,  temp, dest);
			//print(n);

			towersOfHanoi(0, source , dest, temp);
			towersOfHanoi(n-1 ,temp, dest, source);

		}
		
		
	}

	[SerializeField] private int count = 0;
	
		
	void FindPath(Vector3 begin ,Vector3 target)
	{
		mypos[0] = begin+new Vector3(0,10,0);
		mypos[1]=target + new Vector3(0, 10, 0);
		mypos[2] = target;
	
		if (count < 7)
		{
			for (int i = 0; i < 3; i++)
			{
				mohamed[count][i]=mypos[i];
				print( mohamed[count][i]);
				
			}
			
		}
		count++;


		//specifyObject(dd);


		//if (rb.transform.position == p[3].position)
		//{
		/*begin = dd.transform.position;
		End = p[p.Length - 1].transform.position;*/

		//}

		/*if (rb.transform.position != p[current1].position)
		{
			mot = Vector3.MoveTowards(rb.transform.position, p[current1%p.Length].position, speed * Time.fixedDeltaTime);
			rb.MovePosition(mot);

			
		}*/
		//else
		//{
		//	current1 += 1;
		//}


	}
	void performMovement(GameObject dd)
	{
		if (current > 2)
		{
			//return;
			print("eh da");
			i = i + 1;
			dd = dsk[i%dsk.Length];
			elana3ayzo = dd;
			print(elana3ayzo.gameObject.name);
			print("MsA");
			current = 0;
		}
		else
		{
			if (dd.transform.position != mypos[current])
			{
				mot = Vector3.MoveTowards(dd.transform.position, mypos[current], speed * Time.fixedDeltaTime);
				dd.gameObject.GetComponent<Rigidbody>().MovePosition(mot);

			}

			else
			{
				current =(current+ 1);

			
		
			
			}
			
		}
		
		
		
	}

	// Use this for initialization
	void Start ()
	{
		mohamed=new Vector3 [7][];
		for (int i = 0; i < 7; i++)
		{
			mohamed[i]=new Vector3[3];
		}
		
		towersOfHanoi(dsk.Length-1, p[0].position, p[5].position,p[3].position);
		/*elana3ayzo = dsk[0];
		mypos[0] = p[1].position;
		mypos[1] = p[4].position;
		mypos[2] = p[5].position;*/





	}
	
	// Update is called once per frame
	void Update () {
	}

	private void LateUpdate()
	{
		performMovement(elana3ayzo);

	}

	private void FixedUpdate()
	{
		
		
		
			





	}
}
