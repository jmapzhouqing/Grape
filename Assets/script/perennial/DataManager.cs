using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace perennial{
	public class DataManager : Data {
		void OnEnable()
		{
			//data = new Dictionary<string, List<PerformanceInfo>> ();
			
			List<PerformanceInfo> list = new List<PerformanceInfo>();
			PerformanceInfo info;
			
			info = new PerformanceInfo (1,"接下来进行葡萄上架环节，请回答葡萄上架的时间",null);
            list.Add (info);
			
			info = new PerformanceInfo (2,"接下来进行撤土操作，请选择撤土工具",null);
			list.Add (info);
			
			info = new PerformanceInfo (3,"请进行葡萄上架操作",null);
			list.Add (info);
			
			info = new PerformanceInfo (4,"接下来进行追肥灌水环节",null);
			list.Add (info);
			
			info = new PerformanceInfo (5,"请选择肥料种类",null);
			list.Add (info);
			
			info = new PerformanceInfo (6,"请选择肥料的数量",null);
			list.Add (info);
			
			info = new PerformanceInfo (7,"请使用滴管设施，进行追肥灌水操作",null);
			list.Add (info);
			
			info = new PerformanceInfo(8, "上架后萌芽前及时喷药,请选择农药", null);
			list.Add(info);
			
			info = new PerformanceInfo(9, "请输入石硫合剂浓度", null);

			list.Add(info);
			
			info = new PerformanceInfo(10, "石硫合剂原液浓度为30波美度,若要配制5波美度的石硫合剂药液50kg,需加入多少kg石硫合剂", null);
			list.Add(info);
			
			info = new PerformanceInfo(11, "请配置药剂", null);
			list.Add(info);
			
			/*info = new PerformanceInfo(12, "", null);
			list.Add(info);*/
			
			info = new PerformanceInfo(13, "在葡萄生长过程中，施肥的步骤必不可少，追肥分为3个阶段，先进行开花前追肥", null);

			list.Add(info);
			
			info = new PerformanceInfo(14, "现在进行坐果期追肥", null);
			list.Add(info);

			info = new PerformanceInfo(15, "现在进行转色期追肥", null);
			list.Add(info);

			info = new PerformanceInfo(16, "葡萄生长过程中要随时注意病害防治，在认识病害前，先要认识打药机的种类", null);
			list.Add(info);

			info = new PerformanceInfo(17, "请问图中是何种病害", null);
			list.Add(info);

			info = new PerformanceInfo(18, "请选择药剂", null);
			list.Add(info);

			info = new PerformanceInfo(19, "请选择药剂倍数", null);
			list.Add(info);

			info = new PerformanceInfo(20, "葡萄坐果期需要进行上袋操作", null);
			list.Add(info);

			info = new PerformanceInfo(21, "部分品种葡萄在上袋后数日还要进行开口操作", null);
			list.Add(info);

			info = new PerformanceInfo(22, "葡萄已经进入采收期，请进行采收", null);
			list.Add(info);

			info = new PerformanceInfo(23, "葡萄采收后应尽早施入基肥", null);
			list.Add(info);


			SceneManager.instance.performance = list;
			SceneManager.instance.index = 22;
			SceneManager.instance.scene_key = "perennial";
			SceneManager.instance.ExecuteOperation();
		}
		
		public void ResetModel(){
			foreach (KeyValuePair<string,GameObject> pair in model) {
				pair.Value.SetActive(false);
			}
		}
	}
}
