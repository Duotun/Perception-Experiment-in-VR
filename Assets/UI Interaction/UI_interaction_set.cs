namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine.SceneManagement;
    using System.IO;
    public class UI_interaction_set : MonoBehaviour
    {
        private const int EXISTING_CANVAS_COUNT = 4;
        public static int cnt_red;
        public static int cnt_pinkwhole;
        public static int cnt_pinkonly;
        public static int cnt_vr;
        public static int cnt_multiple;
        int cnt2;
        int cnt3;
        int cnt1;
        GameObject tp;
        GameObject tp2;
        GameObject tp3;
        GameObject tpfinished;
        GameObject mass;
        GameObject ir;
        StreamWriter sp;
        int gauge = 27;
        //public int tp_int;
        public static int random_2d_0;
        public static int random_2d_1;
        public static int random_2d_2;
        public static int random_3d_0;
        public static int random_3d_1;
        public static int random_3d_2;
        public static int random_3dmass_0;
        public static int random_3dmass_1;
        public static int random_3dmass_2;
        public static int random_multiple;
        public static int delaytime;
        public static int soundset;
		public static int angleset;
        int redrandom;
        public struct timeandrating
        {
            public float timedelay;
            public float rating;
			public float sound;
        };
		public struct spatialrating
		{
			public float timedelay;
			public float rating;
			public float angle;
			public float sound;
		}
        public static timeandrating[] recording_2d;
        public static timeandrating[] recording_3d;
		public static spatialrating[] recording_spatial;
        int pinkonlyrandom;
		int multiplerandom;
       // public static int[] usedvalues2d;
        //public static int[] usedvalues3d;
         List<int> usedvalues2d = new List<int>();
         List<int> usedvalues3d = new List<int>();
		 List<int> usedvaluesspatial = new List<int>();
        public static int[] used2d;
        public static int[] used3d;
		public static int[] usedspatial;
        public static int scrollvalue=0;
        public static float nowvalue=50;
        int maxvalue;
        private void Awake()
        {
           
            cnt_red = returncontrol2d.cnt;
           // cnt_pinkwhole = returncontroll3dir.cnt;
            cnt_pinkonly = returncontrol3d.cnt;
            cnt_multiple = returncontrolmultiple.cnt;
            //print(cnt_red);
//            print(cnt_pinkonly);
            redrandom = 1;
            pinkonlyrandom = 1;
			multiplerandom = 1;
            maxvalue = 9;
            //tp = GameObject.Find("empty");
        }
        public void bubblesort_2d()
        {
            int i, j;
            float tmptime;
            float tmprating;
			float tmpsound;
            bool exchange;
            for (i = 0; i < recording_2d.Length-1; i++)
            {
                exchange = false;
				for (j = 0; j < recording_2d.Length-1-i; j++)
                {
                    if (recording_2d[j].timedelay > recording_2d[j+1].timedelay)
                    {
                        tmptime = recording_2d[j + 1].timedelay;
                        tmprating = recording_2d[j + 1].rating;
						tmpsound = recording_2d [j + 1].sound;
                        recording_2d[j + 1].timedelay = recording_2d[j].timedelay;
                        recording_2d[j + 1].rating = recording_2d[j].rating;
						recording_2d [j + 1].sound = recording_2d [j].sound;
                        recording_2d[j].timedelay = tmptime;
                        recording_2d[j].rating = tmprating;
						recording_2d [j].sound = tmpsound;
						exchange = true;
                    }
                }
                if (!exchange)
                {
                    break;
                }
            }
			/*
			for (i = 0; i < 9; i++)
			{
				exchange = false;
				for (j = 0; j < 9-i; j++)
				{
					if (recording_2d[j].timedelay > recording_2d[j+1].timedelay)
					{
						tmptime = recording_2d[j + 1].timedelay;
						tmprating = recording_2d[j + 1].rating;
						recording_2d[j + 1].timedelay = recording_2d[j].timedelay;
						recording_2d[j + 1].rating = recording_2d[j].rating;
						recording_2d[j].timedelay = tmptime;
						recording_2d[j].rating = tmprating;
						exchange = true;
					}
				}
				if (!exchange)
				{
					break;
				}
			}
			*/
        }
        public void bubblesort_3d()
        {
            int i, j;
            float tmptime;
            float tmprating;
			float tmpsound;
            bool exchange;
            for (i = 0; i < recording_3d.Length-1; i++)
            {
                exchange = false;
				for (j = 0; j < recording_3d.Length-1-i; j++)
                {
                    if (recording_3d[j + 1].timedelay < recording_3d[j].timedelay)
                    {
                        tmptime = recording_3d[j + 1].timedelay;
                        tmprating = recording_3d[j + 1].rating;
						tmpsound = recording_3d [j + 1].sound;
                        recording_3d[j + 1].timedelay = recording_3d[j].timedelay;
                        recording_3d[j + 1].rating = recording_3d[j].rating;
						recording_3d [j + 1].sound = recording_3d [j].sound;
                        recording_3d[j].timedelay = tmptime;
                        recording_3d[j].rating = tmprating;
						recording_3d [j].sound = tmpsound;
						exchange = true;
                    }
                }
                if (!exchange)
                {
                    break;
                }
            }
        }
		public void bubblesort_spatial()
		{
			int i, j;
			float tmptime;
			float tmprating;
			float tmpangle;
			float tmpsound;
			bool exchange;
			for (i = 0; i < recording_spatial.Length; i++)
			{
				exchange = false;
				for (j = 0; j < recording_spatial.Length-i-1; j++)
				{
					if (recording_spatial[j + 1].timedelay < recording_spatial[j].timedelay)
					{
						tmptime = recording_spatial[j + 1].timedelay;
						tmprating = recording_spatial[j + 1].rating;
						tmpangle = recording_spatial [j + 1].angle;
						tmpsound = recording_spatial [j + 1].sound;
						recording_spatial[j + 1].timedelay = recording_spatial[j].timedelay;
						recording_spatial[j + 1].rating = recording_spatial[j].rating;
						recording_spatial [j + 1].angle = recording_spatial [j].angle;
						recording_spatial [j + 1].sound = recording_spatial [j].sound;
						recording_spatial[j].timedelay = tmptime;
						recording_spatial[j].rating = tmprating;
						recording_spatial [j].angle = tmpangle;
						recording_spatial [j].sound = tmpsound;
						exchange = true;
					}
				}
				if (!exchange)
				{
					break;
				}
			}

		/*	for (i = 0; i <9; i++)
			{
				exchange = false;
				for (j = 0; j < 9-i; j++)
				{
					if (recording_spatial[j + 1].timedelay < recording_spatial[j].timedelay)
					{
						tmptime = recording_spatial[j + 1].timedelay;
						tmprating = recording_spatial[j + 1].rating;
						tmpangle = recording_spatial [j + 1].angle;
						recording_spatial[j + 1].timedelay = recording_spatial[j].timedelay;
						recording_spatial[j + 1].rating = recording_spatial[j].rating;
						recording_spatial [j + 1].angle = recording_spatial [j].angle;
						recording_spatial[j].timedelay = tmptime;
						recording_spatial[j].rating = tmprating;
						recording_spatial [j].angle = tmpangle;
						exchange = true;
					}
				}
				if (!exchange)
				{
					break;
				}
			}
			*/
		}

		public void vedio_2d()
		{
			delaytime = 0;
			SceneManager.LoadScene ("2dvedio");
		}
		public void vedio_3d()
		{
			delaytime = 0;
			SceneManager.LoadScene ("3dvedio");
		}
		public void vedio_2ddelay()
		{
			delaytime = 8;
			SceneManager.LoadScene ("2dvediodelay");
		}
		public void vedio_3ddelay()
		{
			delaytime = 8;
			SceneManager.LoadScene ("3dvediodelay");
		}
		public void vedio_spatial()
		{
			delaytime = 0;
			SceneManager.LoadScene ("spatialvedio");
		}
		public void vedio_spatialdelay()
		{
			delaytime = 8;
			SceneManager.LoadScene ("spatialvediodelay");
		}
		public void begin_2d()
		{
			SceneManager.LoadScene ("Instruction_2dbegin");
		}
		public void begin_3d()
		{
			SceneManager.LoadScene ("Instruction_3dbegin");
		}
		public void begin_spatial(){
			SceneManager.LoadScene ("Instruction_spatialbegin");
		}
        public  void nextscene_2d()
        {
            
            //StartCoroutine(wait_2d());
            
            if (used2d[cnt_red] <= 27)
            {
                // print(usedvalues2d[cnt_red]);
                //sp.WriteLine("Rating is" + scrollvalue);
                //sp.Close();
                print(cnt_red);
                switch (used2d[cnt_red])
                {
                    case 1: soundset = 0; delaytime = 0; SceneManager.LoadScene("2dset"); break;
                    case 2: soundset = 0; delaytime = 1; SceneManager.LoadScene("2dset"); break;
                    case 3: soundset = 0; delaytime = 2; SceneManager.LoadScene("2dset"); break;
                    case 4: soundset = 0; delaytime = 3; SceneManager.LoadScene("2dset"); break;
                    case 5: soundset = 0; delaytime = 4; SceneManager.LoadScene("2dset"); break;
                    case 6: soundset = 0; delaytime = 5; SceneManager.LoadScene("2dset"); break;
                    case 7: soundset = 0; delaytime = 6; SceneManager.LoadScene("2dset"); break;
                    case 8: soundset = 0; delaytime = 7; SceneManager.LoadScene("2dset"); break;
                    case 9: soundset = 0; delaytime = 8; SceneManager.LoadScene("2dset"); break;
                    case 10: soundset = 1; delaytime = 0; SceneManager.LoadScene("2dset"); break;
                    case 11: soundset = 1; delaytime = 1; SceneManager.LoadScene("2dset"); break;
                    case 12: soundset = 1; delaytime = 2; SceneManager.LoadScene("2dset"); break;
                    case 13: soundset = 1; delaytime = 3; SceneManager.LoadScene("2dset"); break;
                    case 14: soundset = 1; delaytime = 4; SceneManager.LoadScene("2dset"); break;
                    case 15: soundset = 1; delaytime = 5; SceneManager.LoadScene("2dset"); break;
                    case 16: soundset = 1; delaytime = 6; SceneManager.LoadScene("2dset"); break;
                    case 17: soundset = 1; delaytime = 7; SceneManager.LoadScene("2dset"); break;
                    case 18: soundset = 1; delaytime = 8; SceneManager.LoadScene("2dset"); break;
                    case 19: soundset = 2; delaytime = 0; SceneManager.LoadScene("2dset"); break;
                    case 20: soundset = 2; delaytime = 1; SceneManager.LoadScene("2dset"); break;
                    case 21: soundset = 2; delaytime = 2; SceneManager.LoadScene("2dset"); break;
                    case 22: soundset = 2; delaytime = 3; SceneManager.LoadScene("2dset"); break;
                    case 23: soundset = 2; delaytime = 4; SceneManager.LoadScene("2dset"); break;
                    case 24: soundset = 2; delaytime = 5; SceneManager.LoadScene("2dset"); break;
                    case 25: soundset = 2; delaytime = 6; SceneManager.LoadScene("2dset"); break;
                    case 26: soundset = 2; delaytime = 7; SceneManager.LoadScene("2dset"); break;
                    case 27: soundset = 2; delaytime = 8; SceneManager.LoadScene("2dset"); break;

                }
                cnt_red++;
            }
            else
            {
                //  print(usedvalues2d[cnt_red]);
                // sp.WriteLine("Rating is" + scrollvalue);
                // sp.Close();
                print(cnt_red);
                switch (used2d[cnt_red] - 27)
                {

                    case 1: soundset = 0; delaytime = 0; SceneManager.LoadScene("2dset"); break;
                    case 2: soundset = 0; delaytime = 1; SceneManager.LoadScene("2dset"); break;
                    case 3: soundset = 0; delaytime = 2; SceneManager.LoadScene("2dset"); break;
                    case 4: soundset = 0; delaytime = 3; SceneManager.LoadScene("2dset"); break;
                    case 5: soundset = 0; delaytime = 4; SceneManager.LoadScene("2dset"); break;
                    case 6: soundset = 0; delaytime = 5; SceneManager.LoadScene("2dset"); break;
                    case 7: soundset = 0; delaytime = 6; SceneManager.LoadScene("2dset"); break;
                    case 8: soundset = 0; delaytime = 7; SceneManager.LoadScene("2dset"); break;
                    case 9: soundset = 0; delaytime = 8; SceneManager.LoadScene("2dset"); break;
                    case 10: soundset = 1; delaytime = 0; SceneManager.LoadScene("2dset"); break;
                    case 11: soundset = 1; delaytime = 1; SceneManager.LoadScene("2dset"); break;
                    case 12: soundset = 1; delaytime = 2; SceneManager.LoadScene("2dset"); break;
                    case 13: soundset = 1; delaytime = 3; SceneManager.LoadScene("2dset"); break;
                    case 14: soundset = 1; delaytime = 4; SceneManager.LoadScene("2dset"); break;
                    case 15: soundset = 1; delaytime = 5; SceneManager.LoadScene("2dset"); break;
                    case 16: soundset = 1; delaytime = 6; SceneManager.LoadScene("2dset"); break;
                    case 17: soundset = 1; delaytime = 7; SceneManager.LoadScene("2dset"); break;
                    case 18: soundset = 1; delaytime = 8; SceneManager.LoadScene("2dset"); break;
                    case 19: soundset = 2; delaytime = 0; SceneManager.LoadScene("2dset"); break;
                    case 20: soundset = 2; delaytime = 1; SceneManager.LoadScene("2dset"); break;
                    case 21: soundset = 2; delaytime = 2; SceneManager.LoadScene("2dset"); break;
                    case 22: soundset = 2; delaytime = 3; SceneManager.LoadScene("2dset"); break;
                    case 23: soundset = 2; delaytime = 4; SceneManager.LoadScene("2dset"); break;
                    case 24: soundset = 2; delaytime = 5; SceneManager.LoadScene("2dset"); break;
                    case 25: soundset = 2; delaytime = 6; SceneManager.LoadScene("2dset"); break;
                    case 26: soundset = 2; delaytime = 7; SceneManager.LoadScene("2dset"); break;
                    case 27: soundset = 2; delaytime = 8; SceneManager.LoadScene("2dset"); break;

                }
                cnt_red++;
            }

        }
        public  void nextscene_3d()
        {
          //  cnt_pinkonly++;
           
            if (used3d[cnt_pinkonly] <= 27)
            {
               // sp.WriteLine("Rating is" + scrollvalue);
               // sp.Close();
                switch (used3d[cnt_pinkonly])
                {
                    case 1: soundset = 0; delaytime = 0; SceneManager.LoadScene("3dset"); break;
                    case 2: soundset = 0; delaytime = 1; SceneManager.LoadScene("3dset"); break;
                    case 3: soundset = 0; delaytime = 2; SceneManager.LoadScene("3dset"); break;
                    case 4: soundset = 0; delaytime = 3; SceneManager.LoadScene("3dset"); break;
                    case 5: soundset = 0; delaytime = 4; SceneManager.LoadScene("3dset"); break;
                    case 6: soundset = 0; delaytime = 5; SceneManager.LoadScene("3dset"); break;
                    case 7: soundset = 0; delaytime = 6; SceneManager.LoadScene("3dset"); break;
                    case 8: soundset = 0; delaytime = 7; SceneManager.LoadScene("3dset"); break;
                    case 9: soundset = 0; delaytime = 8; SceneManager.LoadScene("3dset"); break;
                    case 10: soundset = 1; delaytime = 0; SceneManager.LoadScene("3dset"); break;
                    case 11: soundset = 1; delaytime = 1; SceneManager.LoadScene("3dset"); break;
                    case 12: soundset = 1; delaytime = 2; SceneManager.LoadScene("3dset"); break;
                    case 13: soundset = 1; delaytime = 3; SceneManager.LoadScene("3dset"); break;
                    case 14: soundset = 1; delaytime = 4; SceneManager.LoadScene("3dset"); break;
                    case 15: soundset = 1; delaytime = 5; SceneManager.LoadScene("3dset"); break;
                    case 16: soundset = 1; delaytime = 6; SceneManager.LoadScene("3dset"); break;
                    case 17: soundset = 1; delaytime = 7; SceneManager.LoadScene("3dset"); break;
                    case 18: soundset = 1; delaytime = 8; SceneManager.LoadScene("3dset"); break;
                    case 19: soundset = 2; delaytime = 0; SceneManager.LoadScene("3dset"); break;
                    case 20: soundset = 2; delaytime = 1; SceneManager.LoadScene("3dset"); break;
                    case 21: soundset = 2; delaytime = 2; SceneManager.LoadScene("3dset"); break;
                    case 22: soundset = 2; delaytime = 3; SceneManager.LoadScene("3dset"); break;
                    case 23: soundset = 2; delaytime = 4; SceneManager.LoadScene("3dset"); break;
                    case 24: soundset = 2; delaytime = 5; SceneManager.LoadScene("3dset"); break;
                    case 25: soundset = 2; delaytime = 6; SceneManager.LoadScene("3dset"); break;
                    case 26: soundset = 2; delaytime = 7; SceneManager.LoadScene("3dset"); break;
                    case 27: soundset = 2; delaytime = 8; SceneManager.LoadScene("3dset"); break;
                }
                cnt_pinkonly++;
            }
            else
            {
                //sp.WriteLine("Rating is" + scrollvalue);
               // sp.Close();
                switch (used3d[cnt_pinkonly] - 27)
                {
                    case 1: soundset = 0; delaytime = 0; SceneManager.LoadScene("3dset"); break;
                    case 2: soundset = 0; delaytime = 1; SceneManager.LoadScene("3dset"); break;
                    case 3: soundset = 0; delaytime = 2; SceneManager.LoadScene("3dset"); break;
                    case 4: soundset = 0; delaytime = 3; SceneManager.LoadScene("3dset"); break;
                    case 5: soundset = 0; delaytime = 4; SceneManager.LoadScene("3dset"); break;
                    case 6: soundset = 0; delaytime = 5; SceneManager.LoadScene("3dset"); break;
                    case 7: soundset = 0; delaytime = 6; SceneManager.LoadScene("3dset"); break;
                    case 8: soundset = 0; delaytime = 7; SceneManager.LoadScene("3dset"); break;
                    case 9: soundset = 0; delaytime = 8; SceneManager.LoadScene("3dset"); break;
                    case 10: soundset = 1; delaytime = 0; SceneManager.LoadScene("3dset"); break;
                    case 11: soundset = 1; delaytime = 1; SceneManager.LoadScene("3dset"); break;
                    case 12: soundset = 1; delaytime = 2; SceneManager.LoadScene("3dset"); break;
                    case 13: soundset = 1; delaytime = 3; SceneManager.LoadScene("3dset"); break;
                    case 14: soundset = 1; delaytime = 4; SceneManager.LoadScene("3dset"); break;
                    case 15: soundset = 1; delaytime = 5; SceneManager.LoadScene("3dset"); break;
                    case 16: soundset = 1; delaytime = 6; SceneManager.LoadScene("3dset"); break;
                    case 17: soundset = 1; delaytime = 7; SceneManager.LoadScene("3dset"); break;
                    case 18: soundset = 1; delaytime = 8; SceneManager.LoadScene("3dset"); break;
                    case 19: soundset = 2; delaytime = 0; SceneManager.LoadScene("3dset"); break;
                    case 20: soundset = 2; delaytime = 1; SceneManager.LoadScene("3dset"); break;
                    case 21: soundset = 2; delaytime = 2; SceneManager.LoadScene("3dset"); break;
                    case 22: soundset = 2; delaytime = 3; SceneManager.LoadScene("3dset"); break;
                    case 23: soundset = 2; delaytime = 4; SceneManager.LoadScene("3dset"); break;
                    case 24: soundset = 2; delaytime = 5; SceneManager.LoadScene("3dset"); break;
                    case 25: soundset = 2; delaytime = 6; SceneManager.LoadScene("3dset"); break;
                    case 26: soundset = 2; delaytime = 7; SceneManager.LoadScene("3dset"); break;
                    case 27: soundset = 2; delaytime = 8; SceneManager.LoadScene("3dset"); break;
                }
                cnt_pinkonly++;
            }
        }
		public void nextscene_spatial()
		{
			if (usedspatial[cnt_multiple]<=60) {
				//sp.WriteLine("    可能性 : " + nowvalue+"%");
				//sp.Close();
				switch (usedspatial [cnt_multiple]) {
				case 1:
					soundset = 0;
					delaytime = 0;
					angleset = 1;
					SceneManager.LoadScene ("spatial");  break;
				case 2:
					soundset = 0;
					delaytime = 0;
					angleset = 2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 3:
					soundset = 0;
					delaytime = 0;
					angleset = 3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 4:
					soundset = 0;
					delaytime = 0;
					angleset = -1;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 5:
					soundset = 0;
					delaytime = 0;
					angleset = -2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 6:
					soundset = 0;
					delaytime = 0;
					angleset = -3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 7:
					soundset = 0;
					delaytime = 1;
					angleset = 1; 
					SceneManager.LoadScene ("spatial"); break;
				case 8:
					soundset = 0;
					delaytime = 1;
					angleset = 2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 9:
					soundset = 0;
					delaytime = 1;
					angleset = 3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 10:
					soundset = 0;
					delaytime = 0;
					angleset = -1;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 11:
					soundset = 0;
					delaytime = 0;
					angleset = -2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 12:
					soundset = 0;
					delaytime = 1;
					angleset = -3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 13:
					soundset = 0;
					delaytime = 2;
					angleset = 1;   
					SceneManager.LoadScene ("spatial"); break;
				case 14:
					soundset = 0;
					delaytime = 2;
					angleset = 2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 15:
					soundset = 0;
					delaytime = 2;
					angleset = 3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 16:
					soundset = 0;
					delaytime = 2;
					angleset = -1;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 17:
					soundset = 0;
					delaytime = 2;
					angleset = -2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 18:
					soundset = 0;
					delaytime = 2;
					angleset = -3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 19:
					soundset = 0;
					delaytime = 4;
					angleset = 1;   
					SceneManager.LoadScene ("spatial"); break;
				case 20:
					soundset = 0;
					delaytime = 4;
					angleset = 2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 21:
					soundset = 0;
					delaytime = 4;
					angleset = 3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 22:
					soundset = 0;
					delaytime = 4;
					angleset = -1;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 23:
					soundset = 0;
					delaytime = 4;
					angleset = -2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 24:
					soundset = 0;
					delaytime = 4;
					angleset = -3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 25:
					soundset = 0;
					delaytime = 8;
					angleset = 1;   
					SceneManager.LoadScene ("spatial"); break;
				case 26:
					soundset = 0;
					delaytime = 8;
					angleset = 2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 27:
					soundset = 0;
					delaytime = 8;
					angleset = 3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 28:
					soundset = 0;
					delaytime = 8;
					angleset = -1;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 29:
					soundset = 0;
					delaytime = 8;
					angleset = -2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 30:
					soundset = 0;
					delaytime = 8;
					angleset = -3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 31:
					soundset = 2;
					delaytime = 0;
					angleset = 1;  
					SceneManager.LoadScene ("spatial"); break;
				case 32:
					soundset = 2;
					delaytime = 0;
					angleset = 2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 33:
					soundset = 2;
					delaytime = 0;
					angleset = 3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 34:
					soundset = 2;
					delaytime = 0;
					angleset = -1;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 35:
					soundset = 2;
					delaytime = 0;
					angleset = -2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 36:
					soundset = 2;
					delaytime = 0;
					angleset = -3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 37:
					soundset = 2;
					delaytime = 1;
					angleset = 1;  
					SceneManager.LoadScene ("spatial"); break;
				case 38:
					soundset = 2;
					delaytime = 1;
					angleset = 2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 39:
					soundset = 2;
					delaytime = 1;
					angleset = 3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 40:
					soundset = 2;
					delaytime = 0;
					angleset = -1;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 41:
					soundset = 2;
					delaytime = 0;
					angleset = -2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 42:
					soundset = 2;
					delaytime = 1;
					angleset = -3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 43:
					soundset = 2;
					delaytime = 2;
					angleset = 1;   
					SceneManager.LoadScene ("spatial"); break;
				case 44:
					soundset = 2;
					delaytime = 2;
					angleset = 2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 45:
					soundset = 2;
					delaytime = 2;
					angleset = 3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 46:
					soundset = 2;
					delaytime = 2;
					angleset = -1;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 47:
					soundset = 2;
					delaytime = 2;
					angleset = -2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 48:
					soundset = 2;
					delaytime = 2;
					angleset = -3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 49:
					soundset = 2;
					delaytime = 4;
					angleset = 1;   
					SceneManager.LoadScene ("spatial"); break;
				case 50:
					soundset = 2;
					delaytime = 4;
					angleset = 2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 51:
					soundset = 2;
					delaytime = 4;
					angleset = 3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 52:
					soundset = 2;
					delaytime = 4;
					angleset = -1;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 53:
					soundset = 2;
					delaytime = 4;
					angleset = -2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 54:
					soundset = 2;
					delaytime = 4;
					angleset = -3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 55:
					soundset = 2;
					delaytime = 8;
					angleset = 1;   
					SceneManager.LoadScene ("spatial"); break;
				case 56:
					soundset = 2;
					delaytime = 8;
					angleset = 2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 57:
					soundset = 2;
					delaytime = 8;
					angleset = 3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 58:
					soundset = 2;
					delaytime = 8;
					angleset = -1;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 59:
					soundset = 2;
					delaytime = 8;
					angleset = -2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 60:
					soundset = 2;
					delaytime = 8;
					angleset = -3;
					SceneManager.LoadScene ("spatial"); 
					break;
				}
				cnt_multiple++;
			}
			else {
				//sp.WriteLine("    可能性 : " + nowvalue+"%");
				//sp.Close();
				switch (usedspatial [cnt_multiple] - 60) {
				case 1:
					soundset = 0;
					delaytime = 0;
					angleset = 1;
					SceneManager.LoadScene ("spatial");  break;
				case 2:
					soundset = 0;
					delaytime = 0;
					angleset = 2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 3:
					soundset = 0;
					delaytime = 0;
					angleset = 3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 4:
					soundset = 0;
					delaytime = 0;
					angleset = -1;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 5:
					soundset = 0;
					delaytime = 0;
					angleset = -2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 6:
					soundset = 0;
					delaytime = 0;
					angleset = -3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 7:
					soundset = 0;
					delaytime = 1;
					angleset = 1; 
					SceneManager.LoadScene ("spatial"); break;
				case 8:
					soundset = 0;
					delaytime = 1;
					angleset = 2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 9:
					soundset = 0;
					delaytime = 1;
					angleset = 3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 10:
					soundset = 0;
					delaytime = 0;
					angleset = -1;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 11:
					soundset = 0;
					delaytime = 0;
					angleset = -2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 12:
					soundset = 0;
					delaytime = 1;
					angleset = -3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 13:
					soundset = 0;
					delaytime = 2;
					angleset = 1;   
					SceneManager.LoadScene ("spatial"); break;
				case 14:
					soundset = 0;
					delaytime = 2;
					angleset = 2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 15:
					soundset = 0;
					delaytime = 2;
					angleset = 3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 16:
					soundset = 0;
					delaytime = 2;
					angleset = -1;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 17:
					soundset = 0;
					delaytime = 2;
					angleset = -2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 18:
					soundset = 0;
					delaytime = 2;
					angleset = -3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 19:
					soundset = 0;
					delaytime = 4;
					angleset = 1;   
					SceneManager.LoadScene ("spatial"); break;
				case 20:
					soundset = 0;
					delaytime = 4;
					angleset = 2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 21:
					soundset = 0;
					delaytime = 4;
					angleset = 3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 22:
					soundset = 0;
					delaytime = 4;
					angleset = -1;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 23:
					soundset = 0;
					delaytime = 4;
					angleset = -2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 24:
					soundset = 0;
					delaytime = 4;
					angleset = -3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 25:
					soundset = 0;
					delaytime = 8;
					angleset = 1;   
					SceneManager.LoadScene ("spatial"); break;
				case 26:
					soundset = 0;
					delaytime = 8;
					angleset = 2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 27:
					soundset = 0;
					delaytime = 8;
					angleset = 3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 28:
					soundset = 0;
					delaytime = 8;
					angleset = -1;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 29:
					soundset = 0;
					delaytime = 8;
					angleset = -2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 30:
					soundset = 0;
					delaytime = 8;
					angleset = -3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 31:
					soundset = 2;
					delaytime = 0;
					angleset = 1;  
					SceneManager.LoadScene ("spatial"); break;
				case 32:
					soundset = 2;
					delaytime = 0;
					angleset = 2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 33:
					soundset = 2;
					delaytime = 0;
					angleset = 3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 34:
					soundset = 2;
					delaytime = 0;
					angleset = -1;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 35:
					soundset = 2;
					delaytime = 0;
					angleset = -2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 36:
					soundset = 2;
					delaytime = 0;
					angleset = -3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 37:
					soundset = 2;
					delaytime = 1;
					angleset = 1;  
					SceneManager.LoadScene ("spatial"); break;
				case 38:
					soundset = 2;
					delaytime = 1;
					angleset = 2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 39:
					soundset = 2;
					delaytime = 1;
					angleset = 3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 40:
					soundset = 2;
					delaytime = 0;
					angleset = -1;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 41:
					soundset = 2;
					delaytime = 0;
					angleset = -2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 42:
					soundset = 2;
					delaytime = 1;
					angleset = -3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 43:
					soundset = 2;
					delaytime = 2;
					angleset = 1;   
					SceneManager.LoadScene ("spatial"); break;
				case 44:
					soundset = 2;
					delaytime = 2;
					angleset = 2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 45:
					soundset = 2;
					delaytime = 2;
					angleset = 3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 46:
					soundset = 2;
					delaytime = 2;
					angleset = -1;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 47:
					soundset = 2;
					delaytime = 2;
					angleset = -2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 48:
					soundset = 2;
					delaytime = 2;
					angleset = -3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 49:
					soundset = 2;
					delaytime = 4;
					angleset = 1;   
					SceneManager.LoadScene ("spatial"); break;
				case 50:
					soundset = 2;
					delaytime = 4;
					angleset = 2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 51:
					soundset = 2;
					delaytime = 4;
					angleset = 3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 52:
					soundset = 2;
					delaytime = 4;
					angleset = -1;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 53:
					soundset = 2;
					delaytime = 4;
					angleset = -2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 54:
					soundset = 2;
					delaytime = 4;
					angleset = -3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 55:
					soundset = 2;
					delaytime = 8;
					angleset = 1;   
					SceneManager.LoadScene ("spatial"); break;
				case 56:
					soundset = 2;
					delaytime = 8;
					angleset = 2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 57:
					soundset = 2;
					delaytime = 8;
					angleset = 3;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 58:
					soundset = 2;
					delaytime = 8;
					angleset = -1;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 59:
					soundset = 2;
					delaytime = 8;
					angleset = -2;
					SceneManager.LoadScene ("spatial"); 
					break;
				case 60:
					soundset = 2;
					delaytime = 8;
					angleset = -3;
					SceneManager.LoadScene ("spatial"); 
					break;

				}
				cnt_multiple++;
			}
		}
         void Start()
        {
			nowvalue = 50;
			if (cnt_red == 0 && cnt_pinkonly == 0&&cnt_multiple==0)
            {
				recording_spatial = new spatialrating[120];
                recording_2d = new timeandrating[54];
                recording_3d = new timeandrating[54];
            }


            if (cnt_red == 0)
            {
                //usedvalues2d = new int[60];
                //random_2d_0 = Random.Range(1, 4);
                //random_2d_1 = Random.Range(1, 4);
                // random_2d_2 = Random.Range(1, 4);
                // print("ff");
                used2d = new int[60];
                int countnow = 54;
                while (redrandom<=54)
                {
                    usedvalues2d.Add(uniquerandomint2d(1,55));
                   // usedvalues2d.Add(countnow--);
                    redrandom++;
                }
                int i = 0;
               
                  foreach(int a in usedvalues2d)
                 {
                     used2d[i++] = a;
                 }
                 
              
               /*  for(; i<54;i++)
                {
                    used2d[i++] = countnow--;
                    print(used2d[i - 1]);
                }
                */
            }
            /*if (cnt_pinkwhole == 0)
            {
                random_3d_0 = Random.Range(1, 4);
                random_3d_1 = Random.Range(1, 4);
                random_3d_2 = Random.Range(1, 4);
            }
            */
            if (cnt_pinkonly == 0)
            {
                // usedvalues3d = new int[60];
                //random_3dmass_0 = Random.Range(1, 4);
                // random_3dmass_1 = Random.Range(1, 4);
                // random_3dmass_2 = Random.Range(1, 4);
                used3d = new int[60];
                int countnow = 54;
               while(pinkonlyrandom<=54)
                {
                    usedvalues3d.Add(uniquerandomint3d(1, 55));
                   // usedvalues3d.Add(countnow--);
                    pinkonlyrandom++;
                }
                int i = 0;
                   foreach (int a in usedvalues3d)
                   {
                       used3d[i++] = a;
                   }
               
               /* for (i = 0; i < 54; i++)
                {
                    used3d[i++] = countnow--;
                    
                }*/
            }
            if (cnt_multiple == 0)
            {
                //random_multiple = Random.Range(1, 6);
				usedspatial = new int[125];
				int countnow = 120;
				while(multiplerandom<=120)
				{
					usedvaluesspatial.Add(uniquerandomintspatial(1, 121));
					// usedvaluesspatial.Add(countnow--);
					multiplerandom++;
				}
				int i = 0;
				foreach (int a in usedvaluesspatial)
				{
					usedspatial[i++] = a;
				}

            }


            /*if (cnt_multiple == 0 && cnt_pinkonly == 0 && cnt_pinkwhole == 0 && cnt_red == 0)
             {

                 sp = File.CreateText("c:/upennVR/RECORD.TXT");
             }
             */
            /* else
            {
                 sp = File.AppendText("c:/upennVR/RECORD.TXT");
             }
			*/
		
            /*  tp = GameObject.Find("2D2");
              tp.SetActive(false);
              tpfinished = GameObject.Find("finish");
              tpfinished.SetActive(false);
              tp2 = GameObject.Find("3D2");
              tp2.SetActive(false);      
              tp3 = GameObject.Find("VRTXT");
              tp3.SetActive(false);
             */

            // ir = GameObject.Find("3D24");
            // ir.SetActive(false);
            if (SceneManager.GetActiveScene().name =="submit_2d")
            {
                Scrollbar now;
                now = GameObject.Find("choose").GetComponent<Scrollbar>();
                now.value = 0.5f;
                Text ss;
                ss = GameObject.Find("RATE").GetComponent<Text>();
                ss.text = "可能性 : " + now.value*100f + "%";
                sp = File.AppendText("c:/upennVR/RECORD2dtrial.TXT");
            }
			if (SceneManager.GetActiveScene ().name == "submit_3d") {
				Scrollbar now;
				now = GameObject.Find("choose").GetComponent<Scrollbar>();
				now.value = 0.5f;
				Text ss;
				ss = GameObject.Find("RATE").GetComponent<Text>();
				ss.text = "可能性 : " + now.value*100f + "%";
				sp = File.AppendText("c:/upennVR/RECORD3dtrial.TXT");
			}
			if (SceneManager.GetActiveScene ().name == "submit_spatial") {
				Scrollbar now;
				now = GameObject.Find("choose").GetComponent<Scrollbar>();
				now.value = 0.5f;
				Text ss;
				ss = GameObject.Find("RATE").GetComponent<Text>();
				ss.text = "可能性 : " + now.value*100f + "%";
				sp = File.AppendText("c:/upennVR/RECORDspatial.TXT");
			}

        }
        public void scrollvaluechange()
        {
            Scrollbar now;
            Text ss;
            now = GameObject.Find("choose").GetComponent<Scrollbar>();
            float tmp;
            tmp = now.value * 9;
            scrollvalue = (int)tmp+1;
            ss = GameObject.Find("RATE").GetComponent<Text>();
             nowvalue = Mathf.Round(now.value*100);
           // nowvalue = scrollvalue * 10;
            ss.text = "可能性 : " + nowvalue+"%";
        }
        
        public void submitvalueandnext_2d()
        {
            
            sp.WriteLine("Rating is " + scrollvalue);
            if(cnt_red==54)
            {
                SceneManager.LoadScene("finish");
            }
            sp.Close();
           
        }
        public void submitvalueandnext_3d()
        {
            
            sp.WriteLine("Rating is " + scrollvalue);
            if (cnt_pinkonly == 54)
            {
                SceneManager.LoadScene("finish");
            }
            sp.Close();

        }
        
        public int uniquerandomint2d(int min,int max)
        {
            int val=Random.Range(min,max);
            while(usedvalues2d.Contains(val))
            {
                val = Random.Range(min, max);
            }
            return val;
        }
        public int uniquerandomint3d(int min, int max)
        {
            int val = Random.Range(min, max);
            while (usedvalues3d.Contains(val))
            {
                val = Random.Range(min, max);
            }
            return val;
        }
		public int uniquerandomintspatial(int min, int max)
		{
			int val = Random.Range(min, max);
			while (usedvaluesspatial.Contains(val))
			{
				val = Random.Range(min, max);
			}
			return val;
		}
        public void instruction_2d()
        {
            SceneManager.LoadScene("Instruction");
        }
        public void instruction_3d()
        {
            SceneManager.LoadScene("Instruction1");
        }
        public  void Button_Red()
        {

            //  print(random_2d_0);
            // print(random_2d_1);
            //   print(random_2d_2);
            /*if (cnt_red == 0)     //cai yong hash suiji diyige dian suijixuanqu ranhou houmian yici xiangjia, zheyangyefangbian caiji1 meigeren1yehuibutong
             {
                 switch (random_2d_0)
                 {
                     case 1: SceneManager.LoadScene("collisionahead"); break;
                     case 2: SceneManager.LoadScene("collisiondelay"); break;
                     case 3: SceneManager.LoadScene("collisioninstant"); break;

                 }

                 cnt_red++;
             }
             else
             {
                 if (cnt_red == 3)
                 {
                     if(tp.activeSelf==false)
                    {
                        //sp = File.AppendText("c:/upennVR/RECORD.TXT");
                        sp.WriteLine("2d : The distance is " + targetmove2d.distance + "Meters");
                       // sp.Close();
                    }

                     tp.SetActive(true);

                 }
                 else
                 {
                     if (cnt_red == 1)
                     {
                         switch (random_2d_1)
                         {
                             case 1: SceneManager.LoadScene("collisionahead"); break;
                             case 2: SceneManager.LoadScene("collisiondelay"); break;
                             case 3: SceneManager.LoadScene("collisioninstant"); break;
                                 // case 4: SceneManager.LoadScene("collisionahead");  break;
                                 // case 5:  SceneManager.LoadScene("collisiondelay");  break;
                         }
                         cnt_red++;
                     }
                     else
                     {
                         if (cnt_red == 2)
                         {
                             switch (random_2d_2)
                             {
                                 case 1: SceneManager.LoadScene("collisionahead"); break;
                                 case 2: SceneManager.LoadScene("collisiondelay"); break;
                                 case 3: SceneManager.LoadScene("collisioninstant"); break;
                                     // case 4: SceneManager.LoadScene("collisionahead");  break;
                                     // case 5:  SceneManager.LoadScene("collisiondelay");  break;
                             }
                             cnt_red++;
                         }
                     }
                 }
             }
     */
            StartCoroutine(wait_2d());
           
        }
        private void Update()
        {

           // if (cnt_red == 54 &&/*cnt_pinkwhole==3&&*/cnt_multiple == 5 && cnt_pinkonly == 54)
           // {
            //    tpfinished.SetActive(true);
           //     sp.Close();
          //  }
           
          /*  if (cnt_red == 54)
            {
                tp.SetActive(true);
                //sp.WriteLine("2d : The distance is " + targetmove2d.distance + "Meters");
                //sp.Close();

            }
          /*  if (cnt_pinkwhole == 3)
            {
                ir.SetActive(true);
            }
            
            if (cnt_pinkonly == 54)
            {
                tp2.SetActive(true);
            }
            if (cnt_multiple == 5)
            {
                tp3.SetActive(true);
            }
            */

        }
        public void Button_Red1()
        {

        }
        public void Button_Red2()
        {

        }
        public void Button_Red3()
        {

        }
        public void Button_Pink()  //ir
        {

            if (cnt_pinkwhole == 0)
            {

                switch (random_3d_0)
                {
                    case 1: SceneManager.LoadScene("iregularshapeahead"); break;
                    case 2: SceneManager.LoadScene("iregularshapedelay"); break;
                    case 3: SceneManager.LoadScene("iregularshapeinstant"); break;

                }
                //sp.WriteLine("3d-Irregular shape : The distance is " +circletrack3d.radius*circletrack3d.angle_now+"m");
                cnt_pinkwhole++;
            }
            else
            {
                if (cnt_pinkwhole == 3)
                {
                    /* if (ir.activeSelf == false)
                     {
                         //sp = File.AppendText("c:/upennVR/RECORD.TXT");
                         sp.WriteLine("3d-Irregular shape : The distance is " + circletrack3d.radius * circletrack3d.angle_now + "Meters");
                         //sp.Close();
                     }*/
                    ir.SetActive(true);

                }
                else
                {
                    if (cnt_pinkwhole == 1)
                    {
                        switch (random_3d_1)
                        {
                            case 1: SceneManager.LoadScene("iregularshapeahead"); break;
                            case 2: SceneManager.LoadScene("iregularshapedelay"); break;
                            case 3: SceneManager.LoadScene("iregularshapeinstant"); break;
                                // case 4: SceneManager.LoadScene("iregularshapeahead"); break;
                                //  case 5: SceneManager.LoadScene("iregularshapedelay"); break;
                                // case 6: SceneManager.LoadScene("iregularshapeinstant"); break;

                        }
                        cnt_pinkwhole++;
                    }
                    else
                    {
                        if (cnt_pinkwhole == 2)
                        {
                            switch (random_3d_2)
                            {
                                case 1: SceneManager.LoadScene("iregularshapeahead"); break;
                                case 2: SceneManager.LoadScene("iregularshapedelay"); break;
                                case 3: SceneManager.LoadScene("iregularshapeinstant"); break;
                                    //case 4: SceneManager.LoadScene("iregularshapeahead"); break;
                                    // case 5: SceneManager.LoadScene("iregularshapedelay"); break;
                                    // case 6: SceneManager.LoadScene("iregularshapeinstant"); break;
                            }
                            cnt_pinkwhole++;
                        }
                    }
                }
            }
        }
        public void Button_Pinkonly()   //mass
        {
            /*  if (cnt_pinkonly == 0)
              {
                  switch (random_3dmass_0)
                  {
                      case 1: SceneManager.LoadScene("regularshapeinstant"); break;
                      case 2: SceneManager.LoadScene("regularshapeahead"); break;
                      case 3: SceneManager.LoadScene("regularshapedelay"); break;

                  }
                  cnt_pinkonly++;
              }
              else
              {
                  if (cnt_pinkonly == 3)
                  {
                      /*if (tp2.activeSelf == false)
                      {   
                         // sp= File.AppendText("c:/upennVR/RECORD.TXT");
                          sp.WriteLine("3d-regular shape : The distance is " + circletrack3d.radius * circletrack3d.angle_now + "Meters");
                         // sp.Close();
                      }

                      tp2.SetActive(true);
                  }
                  else
                  {
                      if (cnt_pinkonly == 1)
                      {
                          switch (random_3dmass_1)
                          {
                              case 1: SceneManager.LoadScene("regularshapeinstant"); break;
                              case 2: SceneManager.LoadScene("regularshapeahead"); break;
                              case 3: SceneManager.LoadScene("regularshapedelay"); break;
                                  // case 4: SceneManager.LoadScene("regularshapeinstant"); break;
                                  // case 5: SceneManager.LoadScene("regularshapeahead"); break;
                                  // case 6: SceneManager.LoadScene("regularshapedelay"); break;

                          }
                          cnt_pinkonly++;
                      }
                      else
                      {
                          if (cnt_pinkonly == 2)
                          {
                              switch (random_3dmass_2)
                              {
                                  case 1: SceneManager.LoadScene("regularshapeinstant"); break;
                                  case 2: SceneManager.LoadScene("regularshapeahead"); break;
                                  case 3: SceneManager.LoadScene("regularshapedelay"); break;
                                      // case 4: SceneManager.LoadScene("regularshapeinstant"); break;
                                      // case 5: SceneManager.LoadScene("regularshapeahead"); break;
                                      // case 6: SceneManager.LoadScene("regularshapedelay"); break;

                              }
                              cnt_pinkonly++;

                          }
                      }
                  }
              }*/
            StartCoroutine(wait_3d());
            
        }
		public void Button_multiple()
		{
			StartCoroutine(wait_spatial());
		}
       /* public void Button_Blue()
        {
            if (cnt_vr == 0)
            {
                cnt_vr++;
                SceneManager.LoadScene("Game2");
            }
            else
            {
                tp3.SetActive(true);
            }
        }*/
        IEnumerator wait_2d()
        {
            yield return new WaitForSeconds(2f);
            if (cnt_red < 54)
            {
				/*if (cnt_red == 10) {
					bubblesort_2d ();
					for (int i = 0; i < 10; i++) {
					
						print (recording_2d [i].timedelay);
					}
				}*/
                //  print(usedvalues2d.Count);
                if (used2d[cnt_red] <= 27)
                {
                    //print(usedvalues2d[cnt_red]);
                    //  sp.WriteLine("Rating is" + scrollvalue);
                    // sp.Close();
                    recording_2d[cnt_red - 1].timedelay = 0.05f * delaytime;
                    recording_2d[cnt_red - 1].rating = nowvalue;
					recording_2d [cnt_red - 1].sound = soundset;
					sp.WriteLine("    可能性 : " + nowvalue+"%");
                    sp.Close();
                    print(used2d[cnt_red]);
                    switch (used2d[cnt_red])
                    {
                        case 1: soundset = 0; delaytime = 0; SceneManager.LoadScene("2dset"); break;
                        case 2: soundset = 0; delaytime = 1; SceneManager.LoadScene("2dset"); break;
                        case 3: soundset = 0; delaytime = 2; SceneManager.LoadScene("2dset"); break;
                        case 4: soundset = 0; delaytime = 3; SceneManager.LoadScene("2dset"); break;
                        case 5: soundset = 0; delaytime = 4; SceneManager.LoadScene("2dset"); break;
                        case 6: soundset = 0; delaytime = 5; SceneManager.LoadScene("2dset"); break;
                        case 7: soundset = 0; delaytime = 6; SceneManager.LoadScene("2dset"); break;
                        case 8: soundset = 0; delaytime = 7; SceneManager.LoadScene("2dset"); break;
                        case 9: soundset = 0; delaytime = 8; SceneManager.LoadScene("2dset"); break;
                        case 10: soundset = 1; delaytime = 0; SceneManager.LoadScene("2dset"); break;
                        case 11: soundset = 1; delaytime = 1; SceneManager.LoadScene("2dset"); break;
                        case 12: soundset = 1; delaytime = 2; SceneManager.LoadScene("2dset"); break;
                        case 13: soundset = 1; delaytime = 3; SceneManager.LoadScene("2dset"); break;
                        case 14: soundset = 1; delaytime = 4; SceneManager.LoadScene("2dset"); break;
                        case 15: soundset = 1; delaytime = 5; SceneManager.LoadScene("2dset"); break;
                        case 16: soundset = 1; delaytime = 6; SceneManager.LoadScene("2dset"); break;
                        case 17: soundset = 1; delaytime = 7; SceneManager.LoadScene("2dset"); break;
                        case 18: soundset = 1; delaytime = 8; SceneManager.LoadScene("2dset"); break;
                        case 19: soundset = 2; delaytime = 0; SceneManager.LoadScene("2dset"); break;
                        case 20: soundset = 2; delaytime = 1; SceneManager.LoadScene("2dset"); break;
                        case 21: soundset = 2; delaytime = 2; SceneManager.LoadScene("2dset"); break;
                        case 22: soundset = 2; delaytime = 3; SceneManager.LoadScene("2dset"); break;
                        case 23: soundset = 2; delaytime = 4; SceneManager.LoadScene("2dset"); break;
                        case 24: soundset = 2; delaytime = 5; SceneManager.LoadScene("2dset"); break;
                        case 25: soundset = 2; delaytime = 6; SceneManager.LoadScene("2dset"); break;
                        case 26: soundset = 2; delaytime = 7; SceneManager.LoadScene("2dset"); break;
                        case 27: soundset = 2; delaytime = 8; SceneManager.LoadScene("2dset"); break;

                    }

                    cnt_red++;
                    print(cnt_red);
                }
                else
                {
                    // print(usedvalues2d[cnt_red]);
                    recording_2d[cnt_red - 1].timedelay = 0.05f * delaytime;
                    recording_2d[cnt_red - 1].rating = nowvalue;
					recording_2d [cnt_red - 1].sound = soundset;
					sp.WriteLine("    可能性 : " + nowvalue+"%");
                    sp.Close();
                    print(used2d[cnt_red]);
                    switch (used2d[cnt_red] - gauge)
                    {

                        case 1: soundset = 0; delaytime = 0; SceneManager.LoadScene("2dset"); break;
                        case 2: soundset = 0; delaytime = 1; SceneManager.LoadScene("2dset"); break;
                        case 3: soundset = 0; delaytime = 2; SceneManager.LoadScene("2dset"); break;
                        case 4: soundset = 0; delaytime = 3; SceneManager.LoadScene("2dset"); break;
                        case 5: soundset = 0; delaytime = 4; SceneManager.LoadScene("2dset"); break;
                        case 6: soundset = 0; delaytime = 5; SceneManager.LoadScene("2dset"); break;
                        case 7: soundset = 0; delaytime = 6; SceneManager.LoadScene("2dset"); break;
                        case 8: soundset = 0; delaytime = 7; SceneManager.LoadScene("2dset"); break;
                        case 9: soundset = 0; delaytime = 8; SceneManager.LoadScene("2dset"); break;
                        case 10: soundset = 1; delaytime = 0; SceneManager.LoadScene("2dset"); break;
                        case 11: soundset = 1; delaytime = 1; SceneManager.LoadScene("2dset"); break;
                        case 12: soundset = 1; delaytime = 2; SceneManager.LoadScene("2dset"); break;
                        case 13: soundset = 1; delaytime = 3; SceneManager.LoadScene("2dset"); break;
                        case 14: soundset = 1; delaytime = 4; SceneManager.LoadScene("2dset"); break;
                        case 15: soundset = 1; delaytime = 5; SceneManager.LoadScene("2dset"); break;
                        case 16: soundset = 1; delaytime = 6; SceneManager.LoadScene("2dset"); break;
                        case 17: soundset = 1; delaytime = 7; SceneManager.LoadScene("2dset"); break;
                        case 18: soundset = 1; delaytime = 8; SceneManager.LoadScene("2dset"); break;
                        case 19: soundset = 2; delaytime = 0; SceneManager.LoadScene("2dset"); break;
                        case 20: soundset = 2; delaytime = 1; SceneManager.LoadScene("2dset"); break;
                        case 21: soundset = 2; delaytime = 2; SceneManager.LoadScene("2dset"); break;
                        case 22: soundset = 2; delaytime = 3; SceneManager.LoadScene("2dset"); break;
                        case 23: soundset = 2; delaytime = 4; SceneManager.LoadScene("2dset"); break;
                        case 24: soundset = 2; delaytime = 5; SceneManager.LoadScene("2dset"); break;
                        case 25: soundset = 2; delaytime = 6; SceneManager.LoadScene("2dset"); break;
                        case 26: soundset = 2; delaytime = 7; SceneManager.LoadScene("2dset"); break;
                        case 27: soundset = 2; delaytime = 8; SceneManager.LoadScene("2dset"); break;

                    }
                    cnt_red++;
                    print(cnt_red);
                }

            }
            else
            {

                if (cnt_red == 54)
                {
                    recording_2d[cnt_red - 1].timedelay = 0.05f * delaytime;
                    recording_2d[cnt_red - 1].rating = nowvalue;
					recording_2d [cnt_red - 1].sound = soundset;
                    bubblesort_2d();
                    sp.WriteLine("    可能性 : " + nowvalue+"%");
                    sp.Close();
                    SceneManager.LoadScene("Finishscene_2d");
                }
            }
        }
        IEnumerator wait_3d()
        {
            yield return new WaitForSeconds(2f);
            if (cnt_pinkonly < 54)
            {
				

                if (used3d[cnt_pinkonly] <= 27)
                {
                    recording_3d[cnt_pinkonly - 1].timedelay = 0.05f * delaytime;
                    recording_3d[cnt_pinkonly - 1].rating = nowvalue;
					recording_3d [cnt_pinkonly - 1].sound = soundset;
                    sp.WriteLine("可能性 : " + nowvalue+"%");
                    sp.Close();
                    switch (used3d[cnt_pinkonly])
                    {
                        case 1: soundset = 0; delaytime = 0; SceneManager.LoadScene("3dset"); break;
                        case 2: soundset = 0; delaytime = 1; SceneManager.LoadScene("3dset"); break;
                        case 3: soundset = 0; delaytime = 2; SceneManager.LoadScene("3dset"); break;
                        case 4: soundset = 0; delaytime = 3; SceneManager.LoadScene("3dset"); break;
                        case 5: soundset = 0; delaytime = 4; SceneManager.LoadScene("3dset"); break;
                        case 6: soundset = 0; delaytime = 5; SceneManager.LoadScene("3dset"); break;
                        case 7: soundset = 0; delaytime = 6; SceneManager.LoadScene("3dset"); break;
                        case 8: soundset = 0; delaytime = 7; SceneManager.LoadScene("3dset"); break;
                        case 9: soundset = 0; delaytime = 8; SceneManager.LoadScene("3dset"); break;
                        case 10: soundset = 1; delaytime = 0; SceneManager.LoadScene("3dset"); break;
                        case 11: soundset = 1; delaytime = 1; SceneManager.LoadScene("3dset"); break;
                        case 12: soundset = 1; delaytime = 2; SceneManager.LoadScene("3dset"); break;
                        case 13: soundset = 1; delaytime = 3; SceneManager.LoadScene("3dset"); break;
                        case 14: soundset = 1; delaytime = 4; SceneManager.LoadScene("3dset"); break;
                        case 15: soundset = 1; delaytime = 5; SceneManager.LoadScene("3dset"); break;
                        case 16: soundset = 1; delaytime = 6; SceneManager.LoadScene("3dset"); break;
                        case 17: soundset = 1; delaytime = 7; SceneManager.LoadScene("3dset"); break;
                        case 18: soundset = 1; delaytime = 8; SceneManager.LoadScene("3dset"); break;
                        case 19: soundset = 2; delaytime = 0; SceneManager.LoadScene("3dset"); break;
                        case 20: soundset = 2; delaytime = 1; SceneManager.LoadScene("3dset"); break;
                        case 21: soundset = 2; delaytime = 2; SceneManager.LoadScene("3dset"); break;
                        case 22: soundset = 2; delaytime = 3; SceneManager.LoadScene("3dset"); break;
                        case 23: soundset = 2; delaytime = 4; SceneManager.LoadScene("3dset"); break;
                        case 24: soundset = 2; delaytime = 5; SceneManager.LoadScene("3dset"); break;
                        case 25: soundset = 2; delaytime = 6; SceneManager.LoadScene("3dset"); break;
                        case 26: soundset = 2; delaytime = 7; SceneManager.LoadScene("3dset"); break;
                        case 27: soundset = 2; delaytime = 8; SceneManager.LoadScene("3dset"); break;
                    }
                    cnt_pinkonly++;
                    print(cnt_pinkonly);
                }
                else
                {
                    recording_3d[cnt_pinkonly - 1].timedelay = 0.05f * delaytime;
                    recording_3d[cnt_pinkonly - 1].rating = nowvalue;
					recording_3d [cnt_pinkonly - 1].sound = soundset;
                    sp.WriteLine("可能性 : " + nowvalue+"%");
                    sp.Close();
                    switch (used3d[cnt_pinkonly] - gauge)
                    {
                        case 1: soundset = 0; delaytime = 0; SceneManager.LoadScene("3dset"); break;
                        case 2: soundset = 0; delaytime = 1; SceneManager.LoadScene("3dset"); break;
                        case 3: soundset = 0; delaytime = 2; SceneManager.LoadScene("3dset"); break;
                        case 4: soundset = 0; delaytime = 3; SceneManager.LoadScene("3dset"); break;
                        case 5: soundset = 0; delaytime = 4; SceneManager.LoadScene("3dset"); break;
                        case 6: soundset = 0; delaytime = 5; SceneManager.LoadScene("3dset"); break;
                        case 7: soundset = 0; delaytime = 6; SceneManager.LoadScene("3dset"); break;
                        case 8: soundset = 0; delaytime = 7; SceneManager.LoadScene("3dset"); break;
                        case 9: soundset = 0; delaytime = 8; SceneManager.LoadScene("3dset"); break;
                        case 10: soundset = 1; delaytime = 0; SceneManager.LoadScene("3dset"); break;
                        case 11: soundset = 1; delaytime = 1; SceneManager.LoadScene("3dset"); break;
                        case 12: soundset = 1; delaytime = 2; SceneManager.LoadScene("3dset"); break;
                        case 13: soundset = 1; delaytime = 3; SceneManager.LoadScene("3dset"); break;
                        case 14: soundset = 1; delaytime = 4; SceneManager.LoadScene("3dset"); break;
                        case 15: soundset = 1; delaytime = 5; SceneManager.LoadScene("3dset"); break;
                        case 16: soundset = 1; delaytime = 6; SceneManager.LoadScene("3dset"); break;
                        case 17: soundset = 1; delaytime = 7; SceneManager.LoadScene("3dset"); break;
                        case 18: soundset = 1; delaytime = 8; SceneManager.LoadScene("3dset"); break;
                        case 19: soundset = 2; delaytime = 0; SceneManager.LoadScene("3dset"); break;
                        case 20: soundset = 2; delaytime = 1; SceneManager.LoadScene("3dset"); break;
                        case 21: soundset = 2; delaytime = 2; SceneManager.LoadScene("3dset"); break;
                        case 22: soundset = 2; delaytime = 3; SceneManager.LoadScene("3dset"); break;
                        case 23: soundset = 2; delaytime = 4; SceneManager.LoadScene("3dset"); break;
                        case 24: soundset = 2; delaytime = 5; SceneManager.LoadScene("3dset"); break;
                        case 25: soundset = 2; delaytime = 6; SceneManager.LoadScene("3dset"); break;
                        case 26: soundset = 2; delaytime = 7; SceneManager.LoadScene("3dset"); break;
                        case 27: soundset = 2; delaytime = 8; SceneManager.LoadScene("3dset"); break;
                    }
                    cnt_pinkonly++;
                    print(cnt_pinkonly);
                }
            }
            else
            {
                if (cnt_pinkonly == 54)
                {
                    recording_3d[cnt_pinkonly - 1].timedelay = 0.05f * delaytime;
                    recording_3d[cnt_pinkonly - 1].rating = nowvalue;
					recording_3d [cnt_pinkonly - 1].sound = soundset;
                    bubblesort_3d();
                    sp.WriteLine("可能性 : " + nowvalue+"%");
                    sp.Close();
                    SceneManager.LoadScene("Finishscene_3d");
                }
            }
        }
		IEnumerator wait_spatial()
		{
			yield return new WaitForSeconds(2f);
			if (cnt_multiple < 120) {
				/*if (cnt_multiple == 10) {
					bubblesort_spatial ();
					for (int i = 0; i < 10; i++) {
						print(recording_spatial[i].timedelay);
					}
				}*/
				if (usedspatial[cnt_multiple]<=60) {
					//print (usedspatial[cnt_multiple]);
					recording_spatial[cnt_multiple-1].timedelay=0.05f*delaytime;
					recording_spatial[cnt_multiple - 1].rating = nowvalue;
					recording_spatial[cnt_multiple - 1].angle = angleset * 20f;
					recording_spatial[cnt_multiple - 1].sound = soundset;
					sp.WriteLine("    可能性 : " + nowvalue+"%");
					sp.Close();
					switch (usedspatial [cnt_multiple]) {
					case 1:
						soundset = 0;
						delaytime = 0;
						angleset = 1;
						SceneManager.LoadScene ("spatial");  break;
					case 2:
						soundset = 0;
						delaytime = 0;
						angleset = 2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 3:
						soundset = 0;
						delaytime = 0;
						angleset = 3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 4:
						soundset = 0;
						delaytime = 0;
						angleset = -1;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 5:
						soundset = 0;
						delaytime = 0;
						angleset = -2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 6:
						soundset = 0;
						delaytime = 0;
						angleset = -3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 7:
						soundset = 0;
						delaytime = 1;
						angleset = 1; 
						SceneManager.LoadScene ("spatial"); break;
					case 8:
						soundset = 0;
						delaytime = 1;
						angleset = 2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 9:
						soundset = 0;
						delaytime = 1;
						angleset = 3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 10:
						soundset = 0;
						delaytime = 0;
						angleset = -1;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 11:
						soundset = 0;
						delaytime = 0;
						angleset = -2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 12:
						soundset = 0;
						delaytime = 1;
						angleset = -3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 13:
						soundset = 0;
						delaytime = 2;
						angleset = 1;   
						SceneManager.LoadScene ("spatial"); break;
					case 14:
						soundset = 0;
						delaytime = 2;
						angleset = 2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 15:
						soundset = 0;
						delaytime = 2;
						angleset = 3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 16:
						soundset = 0;
						delaytime = 2;
						angleset = -1;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 17:
						soundset = 0;
						delaytime = 2;
						angleset = -2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 18:
						soundset = 0;
						delaytime = 2;
						angleset = -3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 19:
						soundset = 0;
						delaytime = 4;
						angleset = 1;   
						SceneManager.LoadScene ("spatial"); break;
					case 20:
						soundset = 0;
						delaytime = 4;
						angleset = 2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 21:
						soundset = 0;
						delaytime = 4;
						angleset = 3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 22:
						soundset = 0;
						delaytime = 4;
						angleset = -1;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 23:
						soundset = 0;
						delaytime = 4;
						angleset = -2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 24:
						soundset = 0;
						delaytime = 4;
						angleset = -3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 25:
						soundset = 0;
						delaytime = 8;
						angleset = 1;   
						SceneManager.LoadScene ("spatial"); break;
					case 26:
						soundset = 0;
						delaytime = 8;
						angleset = 2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 27:
						soundset = 0;
						delaytime = 8;
						angleset = 3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 28:
						soundset = 0;
						delaytime = 8;
						angleset = -1;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 29:
						soundset = 0;
						delaytime = 8;
						angleset = -2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 30:
						soundset = 0;
						delaytime = 8;
						angleset = -3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 31:
						soundset = 2;
						delaytime = 0;
						angleset = 1;  
						SceneManager.LoadScene ("spatial"); break;
					case 32:
						soundset = 2;
						delaytime = 0;
						angleset = 2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 33:
						soundset = 2;
						delaytime = 0;
						angleset = 3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 34:
						soundset = 2;
						delaytime = 0;
						angleset = -1;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 35:
						soundset = 2;
						delaytime = 0;
						angleset = -2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 36:
						soundset = 2;
						delaytime = 0;
						angleset = -3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 37:
						soundset = 2;
						delaytime = 1;
						angleset = 1;  
						SceneManager.LoadScene ("spatial"); break;
					case 38:
						soundset = 2;
						delaytime = 1;
						angleset = 2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 39:
						soundset = 2;
						delaytime = 1;
						angleset = 3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 40:
						soundset = 2;
						delaytime = 0;
						angleset = -1;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 41:
						soundset = 2;
						delaytime = 0;
						angleset = -2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 42:
						soundset = 2;
						delaytime = 1;
						angleset = -3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 43:
						soundset = 2;
						delaytime = 2;
						angleset = 1;   
						SceneManager.LoadScene ("spatial"); break;
					case 44:
						soundset = 2;
						delaytime = 2;
						angleset = 2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 45:
						soundset = 2;
						delaytime = 2;
						angleset = 3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 46:
						soundset = 2;
						delaytime = 2;
						angleset = -1;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 47:
						soundset = 2;
						delaytime = 2;
						angleset = -2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 48:
						soundset = 2;
						delaytime = 2;
						angleset = -3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 49:
						soundset = 2;
						delaytime = 4;
						angleset = 1;   
						SceneManager.LoadScene ("spatial"); break;
					case 50:
						soundset = 2;
						delaytime = 4;
						angleset = 2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 51:
						soundset = 2;
						delaytime = 4;
						angleset = 3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 52:
						soundset = 2;
						delaytime = 4;
						angleset = -1;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 53:
						soundset = 2;
						delaytime = 4;
						angleset = -2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 54:
						soundset = 2;
						delaytime = 4;
						angleset = -3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 55:
						soundset = 2;
						delaytime = 8;
						angleset = 1;   
						SceneManager.LoadScene ("spatial"); break;
					case 56:
						soundset = 2;
						delaytime = 8;
						angleset = 2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 57:
						soundset = 2;
						delaytime = 8;
						angleset = 3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 58:
						soundset = 2;
						delaytime = 8;
						angleset = -1;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 59:
						soundset = 2;
						delaytime = 8;
						angleset = -2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 60:
						soundset = 2;
						delaytime = 8;
						angleset = -3;
						SceneManager.LoadScene ("spatial"); 
						break;
					}
					cnt_multiple++;
				}
				else {
					print (usedspatial[cnt_multiple]);
					recording_spatial[cnt_multiple-1].timedelay=0.05f*delaytime;
					recording_spatial[cnt_multiple - 1].rating = nowvalue;
					recording_spatial [cnt_multiple - 1].angle = angleset * 20f;
					recording_spatial [cnt_multiple - 1].sound = soundset;
					sp.WriteLine("    可能性 : " + nowvalue+"%");
					sp.Close();
					switch (usedspatial [cnt_multiple] - 60) {
					case 1:
						soundset = 0;
						delaytime = 0;
						angleset = 1;
						SceneManager.LoadScene ("spatial");  break;
					case 2:
						soundset = 0;
						delaytime = 0;
						angleset = 2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 3:
						soundset = 0;
						delaytime = 0;
						angleset = 3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 4:
						soundset = 0;
						delaytime = 0;
						angleset = -1;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 5:
						soundset = 0;
						delaytime = 0;
						angleset = -2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 6:
						soundset = 0;
						delaytime = 0;
						angleset = -3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 7:
						soundset = 0;
						delaytime = 1;
						angleset = 1; 
						SceneManager.LoadScene ("spatial"); break;
					case 8:
						soundset = 0;
						delaytime = 1;
						angleset = 2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 9:
						soundset = 0;
						delaytime = 1;
						angleset = 3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 10:
						soundset = 0;
						delaytime = 0;
						angleset = -1;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 11:
						soundset = 0;
						delaytime = 0;
						angleset = -2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 12:
						soundset = 0;
						delaytime = 1;
						angleset = -3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 13:
						soundset = 0;
						delaytime = 2;
						angleset = 1;   
						SceneManager.LoadScene ("spatial"); break;
					case 14:
						soundset = 0;
						delaytime = 2;
						angleset = 2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 15:
						soundset = 0;
						delaytime = 2;
						angleset = 3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 16:
						soundset = 0;
						delaytime = 2;
						angleset = -1;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 17:
						soundset = 0;
						delaytime = 2;
						angleset = -2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 18:
						soundset = 0;
						delaytime = 2;
						angleset = -3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 19:
						soundset = 0;
						delaytime = 4;
						angleset = 1;   
						SceneManager.LoadScene ("spatial"); break;
					case 20:
						soundset = 0;
						delaytime = 4;
						angleset = 2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 21:
						soundset = 0;
						delaytime = 4;
						angleset = 3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 22:
						soundset = 0;
						delaytime = 4;
						angleset = -1;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 23:
						soundset = 0;
						delaytime = 4;
						angleset = -2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 24:
						soundset = 0;
						delaytime = 4;
						angleset = -3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 25:
						soundset = 0;
						delaytime = 8;
						angleset = 1;   
						SceneManager.LoadScene ("spatial"); break;
					case 26:
						soundset = 0;
						delaytime = 8;
						angleset = 2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 27:
						soundset = 0;
						delaytime = 8;
						angleset = 3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 28:
						soundset = 0;
						delaytime = 8;
						angleset = -1;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 29:
						soundset = 0;
						delaytime = 8;
						angleset = -2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 30:
						soundset = 0;
						delaytime = 8;
						angleset = -3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 31:
						soundset = 2;
						delaytime = 0;
						angleset = 1;  
						SceneManager.LoadScene ("spatial"); break;
					case 32:
						soundset = 2;
						delaytime = 0;
						angleset = 2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 33:
						soundset = 2;
						delaytime = 0;
						angleset = 3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 34:
						soundset = 2;
						delaytime = 0;
						angleset = -1;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 35:
						soundset = 2;
						delaytime = 0;
						angleset = -2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 36:
						soundset = 2;
						delaytime = 0;
						angleset = -3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 37:
						soundset = 2;
						delaytime = 1;
						angleset = 1;  
						SceneManager.LoadScene ("spatial"); break;
					case 38:
						soundset = 2;
						delaytime = 1;
						angleset = 2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 39:
						soundset = 2;
						delaytime = 1;
						angleset = 3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 40:
						soundset = 2;
						delaytime = 0;
						angleset = -1;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 41:
						soundset = 2;
						delaytime = 0;
						angleset = -2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 42:
						soundset = 2;
						delaytime = 1;
						angleset = -3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 43:
						soundset = 2;
						delaytime = 2;
						angleset = 1;   
						SceneManager.LoadScene ("spatial"); break;
					case 44:
						soundset = 2;
						delaytime = 2;
						angleset = 2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 45:
						soundset = 2;
						delaytime = 2;
						angleset = 3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 46:
						soundset = 2;
						delaytime = 2;
						angleset = -1;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 47:
						soundset = 2;
						delaytime = 2;
						angleset = -2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 48:
						soundset = 2;
						delaytime = 2;
						angleset = -3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 49:
						soundset = 2;
						delaytime = 4;
						angleset = 1;   
						SceneManager.LoadScene ("spatial"); break;
					case 50:
						soundset = 2;
						delaytime = 4;
						angleset = 2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 51:
						soundset = 2;
						delaytime = 4;
						angleset = 3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 52:
						soundset = 2;
						delaytime = 4;
						angleset = -1;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 53:
						soundset = 2;
						delaytime = 4;
						angleset = -2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 54:
						soundset = 2;
						delaytime = 4;
						angleset = -3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 55:
						soundset = 2;
						delaytime = 8;
						angleset = 1;   
						SceneManager.LoadScene ("spatial"); break;
					case 56:
						soundset = 2;
						delaytime = 8;
						angleset = 2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 57:
						soundset = 2;
						delaytime = 8;
						angleset = 3;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 58:
						soundset = 2;
						delaytime = 8;
						angleset = -1;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 59:
						soundset = 2;
						delaytime = 8;
						angleset = -2;
						SceneManager.LoadScene ("spatial"); 
						break;
					case 60:
						soundset = 2;
						delaytime = 8;
						angleset = -3;
						SceneManager.LoadScene ("spatial"); 
						break;
					}
					cnt_multiple++;
				}
			
			
			} 
			else {
				if (cnt_multiple == 120) {
					recording_spatial[cnt_multiple-1].timedelay=0.05f*delaytime;
					recording_spatial[cnt_multiple - 1].rating = nowvalue;
					recording_spatial [cnt_multiple - 1].angle = angleset * 20f;
					recording_spatial [cnt_multiple - 1].sound = soundset;
				    bubblesort_spatial();
					sp.WriteLine("可能性 : " + nowvalue+"%");
					sp.Close();
					SceneManager.LoadScene("Finishscene_spatial");
					     
				}
			}
		}
        public void Button_Black()
        {
            if (cnt_multiple == 0)
            {
                switch (random_multiple)
                {
                    case 1: SceneManager.LoadScene("MULTIPLE"); break;
                    case 2: SceneManager.LoadScene("MULTIPLE 1"); break;
                    case 3: SceneManager.LoadScene("MULTIPLE 2"); break;
                    case 4: SceneManager.LoadScene("MULTIPLE 3"); break;
                    case 5: SceneManager.LoadScene("MULTIPLE 4"); break;

                }
                cnt_multiple++;
            }
            else
            {
                if (cnt_multiple == 5)
                {
                    tp3.SetActive(true);
                }
                else
                {
                    switch (random_multiple + cnt_multiple)
                    {
                        case 1: SceneManager.LoadScene("MULTIPLE"); break;
                        case 2: SceneManager.LoadScene("MULTIPLE 1"); break;
                        case 3: SceneManager.LoadScene("MULTIPLE 2"); break;
                        case 4: SceneManager.LoadScene("MULTIPLE 3"); break;
                        case 5: SceneManager.LoadScene("MULTIPLE 4"); break;
                        case 6: SceneManager.LoadScene("MULTIPLE"); break;
                        case 7: SceneManager.LoadScene("MULTIPLE 1"); break;
                        case 8: SceneManager.LoadScene("MULTIPLE 2"); break;
                        case 9: SceneManager.LoadScene("MULTIPLE 3"); break;
                        case 10: SceneManager.LoadScene("MULTIPLE 4"); break;
                    }
                    cnt_multiple++;
                }
            }
        }
        public void Button_Black2()
        {

        }
        public void Button_Black3()
        {

        }
        public void Button_White1()
        {
            scrollvalue = 1;
            GameObject yes;
            GameObject no;
            GameObject hint;
            text3.choose.SetActive(true);
            text3.rating.SetActive(true);
            text3.submit.SetActive(true);
            yes = GameObject.Find("1");
            yes.SetActive(false);
            no = GameObject.Find("0");
            no.SetActive(false);
            hint = GameObject.Find("judge");
            hint.SetActive(false);
        }
        public void Button_White2()
        {
            nowvalue = 0;
            if(SceneManager.GetActiveScene().name=="submit_2d")
            {
                StartCoroutine(wait_2d());
            }
            if(SceneManager.GetActiveScene().name=="submit_3d")
            {
                StartCoroutine(wait_3d());
            }
			if(SceneManager.GetActiveScene().name=="submit_spatial")
			{
				StartCoroutine(wait_spatial());
			}
        }
        public void Button_White3()
        {

        }
        public void Toggle(bool state)
        {

        }

        public void Dropdown(int value)
        {

        }

        public void SetDropText(BaseEventData data)
        {
            var pointerData = data as PointerEventData;
            var textObject = GameObject.Find("ActionText");
            if (textObject)
            {
                var text = textObject.GetComponent<Text>();
                text.text = pointerData.pointerDrag.name + " Dropped On " + pointerData.pointerEnter.name;
            }
        }

        public void CreateCanvas()
        {
            StartCoroutine(CreateCanvasOnNextFrame());
        }

        private IEnumerator CreateCanvasOnNextFrame()
        {
            yield return null;

            var canvasCount = FindObjectsOfType<Canvas>().Length - EXISTING_CANVAS_COUNT;
            var newCanvasGO = new GameObject("TempCanvas");
            newCanvasGO.layer = 5;
            var canvas = newCanvasGO.AddComponent<Canvas>();
            var canvasRT = canvas.GetComponent<RectTransform>();
            canvasRT.position = new Vector3(-4f, 2f, 3f + canvasCount);
            canvasRT.sizeDelta = new Vector2(300f, 400f);
            canvasRT.localScale = new Vector3(0.005f, 0.005f, 0.005f);
            canvasRT.eulerAngles = new Vector3(0f, 270f, 0f);

            var newButtonGO = new GameObject("TempButton", typeof(RectTransform));
            newButtonGO.transform.SetParent(newCanvasGO.transform);
            newButtonGO.layer = 5;

            var buttonRT = newButtonGO.GetComponent<RectTransform>();
            buttonRT.position = new Vector3(0f, 0f, 0f);
            buttonRT.anchoredPosition = new Vector3(0f, 0f, 0f);
            buttonRT.localPosition = new Vector3(0f, 0f, 0f);
            buttonRT.sizeDelta = new Vector2(180f, 60f);
            buttonRT.localScale = new Vector3(1f, 1f, 1f);
            buttonRT.localEulerAngles = new Vector3(0f, 0f, 0f);

            newButtonGO.AddComponent<Image>();
            var canvasButton = newButtonGO.AddComponent<Button>();
            var buttonColourBlock = canvasButton.colors;
            buttonColourBlock.highlightedColor = Color.red;
            canvasButton.colors = buttonColourBlock;

            var newTextGO = new GameObject("BtnText", typeof(RectTransform));
            newTextGO.transform.SetParent(newButtonGO.transform);
            newTextGO.layer = 5;

            var textRT = newTextGO.GetComponent<RectTransform>();
            textRT.position = new Vector3(0f, 0f, 0f);
            textRT.anchoredPosition = new Vector3(0f, 0f, 0f);
            textRT.localPosition = new Vector3(0f, 0f, 0f);
            textRT.sizeDelta = new Vector2(180f, 60f);
            textRT.localScale = new Vector3(1f, 1f, 1f);
            textRT.localEulerAngles = new Vector3(0f, 0f, 0f);

            var txt = newTextGO.AddComponent<Text>();
            txt.text = "New Button";
            txt.color = Color.black;
            txt.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;

            newCanvasGO.AddComponent<VRTK_UICanvas>();
        }
    }
}