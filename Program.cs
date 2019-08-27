using System;

namespace Lab2
{

	class MainClass
	{
		
		static int L=5;
		int[] S;
		int[] U;
		string[] txt;
		//приспособленность
		void SetU(){
			for(int i = 0;i<S.Length;i++){
				U [i] = (int)Math.Pow(i - Math.Pow(2,L-1),2);
				if (i < 32) {
					Console.WriteLine (txt [i] + " U = " + U [i]);
				}
			}
			Console.WriteLine ("================================================================================");
		}
		//Метод восхождения на холм. Поиск в глубину
		void MetodMK(int N){
			bool empty = false;
			int i=0,max = 0;
			String maxS ="";
			Random rnd = new Random ();
			int j = rnd.Next (0, S.Length);
			max = U [j];
			maxS = S [j].ToString();
			string[] W = new string[S.Length];
			int[] Wu = new int[S.Length];
			int Wcount = 0;
			Console.WriteLine ("i= 0 " + "maxS = " + txt[j] + " max = " + max.ToString ());
			for (int a = 0; a < S.Length; a++) {
				if (HamRange (txt [j], txt [a]) == 1) {
					W [Wcount] = txt [a];
					Wu [Wcount] = U [a];
					Wcount++;
					Console.WriteLine ("|| " + "S = " + txt [a] + " U = " + U [a]);
				}
			}
			while (i < N) {
				i++;
				empty = true;
				for (int a = 0; a < Wcount; a++) {
					if (W [a] != "0")
						empty = false;
				}
				if (!empty) {
					do {
						j = rnd.Next (0, Wcount);
					} while(W [j] == "0");
				} else
					break;
				Console.WriteLine("Step " + i + ".Выбран: " + W[j] + " U = " + Wu[j]);
					
				if (Wu [j] > max) {
					max = Wu [j];
					maxS = W [j];
					Console.WriteLine ("SWAP maxS = " + maxS + " max = " + max.ToString ());
					W = new string[S.Length];
					Wu = new int[S.Length];
					Wcount = 0;
					for (int a = 0; a < S.Length; a++) {
						if (HamRange (maxS, txt [a]) == 1) {
							W [Wcount] = txt [a];
							Wu [Wcount] = U [a];
							Wcount++;
							Console.WriteLine ("|| " + "S = " + txt [a] + " U = " + U [a]);
						}
					}
				} else {
					W [j] = "0";
					for (int a = 0; a < Wcount; a++) {
						if (W [a] != "0")
							Console.WriteLine ("                                || " + "S = " + W [a] + " U = " + Wu [a]);
					}
				}
				

			}
			Console.WriteLine ("END maxS = " + maxS + " max = " + max.ToString ());
		}
		//Метод возвращающий Расстоя́ние Хэ́мминга
		int HamRange(string s1,string s2){
			int range = 0;
			for(int i = 0; i<s1.Length;i++){
				if (s1 [i] != s2 [i])
					range++;
			}
			return range;
		}

		//Инициализация ПП
		public void IniS(int n){

			S = new int[(int)Math.Pow(2,n)];
			U = new int[(int)Math.Pow(2,n)];
			txt = new string[(int)Math.Pow(2,n)];
			int x;

			for (int j = 0; j < (int)Math.Pow(2,n); j++) {
				x = j;
				S [j] = j;
				string BI = Convert.ToString (S [j], 2);
				if (BI.Length < n) {
					while (BI.Length != n) {
						BI = String.Concat ('0' + BI);
					}
				}
				txt [j] = BI;
			}

		}
		public static void Main (string[] args)
		{
			MainClass MC = new MainClass();

			MC.IniS(L);
			MC.SetU ();
			MC.MetodMK (10);
		}
	}
}
