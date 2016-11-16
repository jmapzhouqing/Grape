using UnityEngine;
using System.Collections;
using System;
public class PerformanceInfo {
	public string describe{ get; set;}
	public int key{ get; set;}
	public Action callback{ get; set;}

	public PerformanceInfo(int key,string describe,Action callback){
		this.key = key;
		this.describe = describe;
		this.callback = callback;
	}
}
