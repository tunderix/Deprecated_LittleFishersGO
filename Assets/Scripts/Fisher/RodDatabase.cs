using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RodDatabase : MonoBehaviour {
	public List<Rod> rods = new List<Rod>();
	
	void Start()
	{
		rods.Add (new Rod ("Papa's Old Fishing Rod",0,"Used but good",0,0,10));
		rods.Add (new Rod ("x11",1,"Basic rod for amateurs",150,0,15));
		rods.Add (new Rod ("HugeCatcher 3k",2,"Professional usage rod",400,1,20));
		rods.Add (new Rod ("MegaCatcher",3,"Professional Only",600,3,30));
	}
}
