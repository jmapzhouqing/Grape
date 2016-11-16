using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace framework
{
	public class DataManager : Data
    {
        //public static Dictionary<string,List<PerformanceInfo>> data;

      

        void OnEnable()
        {
            //data = new Dictionary<string, List<PerformanceInfo>> ();

            List<PerformanceInfo> list = new List<PerformanceInfo>();
            PerformanceInfo info;

            info = new PerformanceInfo(1, "请选择适合的葡萄园土壤", null);
            list.Add(info);

            info = new PerformanceInfo(2, "对于架势的选择，在北方平原寒冷地带，多采用小棚架便于埋土防寒。请选择适用于小棚架的架材", null);
            list.Add(info);

            info = new PerformanceInfo(3, "请根据小棚架的搭建原则，搭建小棚架", null);
            list.Add(info);

            info = new PerformanceInfo(4, "请选择立杆的行距", null);
            info.callback = delegate{
                model["jc01_jia03"].SetActive(true);
            };
            list.Add(info);

            info = new PerformanceInfo(5, "请选择立杆的间距", null);
            info.callback = delegate {
                model["cj01_jia02"].SetActive(true);
            };
            list.Add(info);

            info = new PerformanceInfo(6, "请选择棚架的宽度", null);
            info.callback = delegate {
                model["cj01_jia01"].SetActive(true);
            };
            list.Add(info);

            info = new PerformanceInfo(7, "请选择拉线的间距和数量", null);
            info.callback = delegate {
                model["cj01_ts"].SetActive(true);
            };
            list.Add(info);

            info = new PerformanceInfo(8, "", null);
            list.Add(info);

            info = new PerformanceInfo(9, "你已完成立架操作，请接下来进行一年期栽植管理或者再次练习立架操作", null);
            list.Add(info);

            //data.Add ("framework",list);

            SceneManager.instance.performance = list;
            SceneManager.instance.index = 1;
            SceneManager.instance.scene_key= "framework";
            SceneManager.instance.ExecuteOperation();

            /*
            info = new PerformanceInfo (1,"请放线并挖掘定植沟,根据土质选择定植沟的深度和宽度");
            list.Add (info);

            info = new PerformanceInfo (2,"");
            list.Add (info);

            info = new PerformanceInfo (3,"请在定植沟内铺设底肥,并埋土回填");
            list.Add (info);

            info = new PerformanceInfo (4,"");
            list.Add (info);

            info = new PerformanceInfo (5,"");
            list.Add (info);

            info = new PerformanceInfo (6,"");
            list.Add (info);

            info = new PerformanceInfo (7,"请在确认定植穴的间距和大小,并按照双行栽植的方式挖定植穴");
            list.Add (info);

            SceneManager.instance.performance = list;*/
        }
    }
}
