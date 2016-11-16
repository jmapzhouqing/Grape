
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace annual {
	public class DataManager : Data {
        void OnEnable()
        {
            //data = new Dictionary<string, List<PerformanceInfo>> ();

            List<PerformanceInfo> list = new List<PerformanceInfo>();
            PerformanceInfo info;

			/*info = new PerformanceInfo (1,"请选择放线的位置",null);
            list.Add (info);*/

			info = new PerformanceInfo (2,"请选择定植沟的深度和宽度",null);
			info.callback = delegate {
				model ["cj02_dimian"].SetActive (false);
				model ["cj02_gou"].SetActive (true);
			};
            list.Add (info);

			info = new PerformanceInfo (3,"请选择秸秆的厚度",null);
            list.Add (info);

			info = new PerformanceInfo (4,"请选择有机肥的厚度",null);
            list.Add (info);

			info = new PerformanceInfo (5,"请选择回填深度",null);
            list.Add (info);

			info = new PerformanceInfo (6,"请选择作畦深度",null);
            list.Add (info);

            info = new PerformanceInfo (7,"请在确认定植穴的间距和大小,并按照双行栽植的方式挖定植穴",null);
            list.Add (info);

            info = new PerformanceInfo(8, "", null);
            list.Add(info);

            info = new PerformanceInfo(9, "请选择定植穴大小", null);
			info.callback = delegate {
				model ["cj02_bom"].SetActive (true);
			};
            list.Add(info);

            info = new PerformanceInfo(10, "请选择苗木", null);
            list.Add(info);

            info = new PerformanceInfo(11, "请开始栽植", null);
			info.callback = delegate {
				model ["xiaomiao"].SetActive (true);
			};
            list.Add(info);

            info = new PerformanceInfo(12, "请选择埋土防寒工具", null);
            list.Add(info);

            info = new PerformanceInfo(13, "请进行埋土防寒操作", null);
			info.callback = delegate {
				model ["cj02_tu"].SetActive (true);
			};
            list.Add(info);

            info = new PerformanceInfo(14, "", null);
            list.Add(info);

            SceneManager.instance.performance = list;
			SceneManager.instance.index = 1;
            SceneManager.instance.scene_key = "annual";
            SceneManager.instance.ExecuteOperation();

			model["cj02_dimian"].SetActive(true);
        }

		public void ResetModel(){
			foreach (KeyValuePair<string,GameObject> pair in model) {
				pair.Value.SetActive(false);
			}
			model ["cj02_dimian"].SetActive (true);
		}


    }
}
