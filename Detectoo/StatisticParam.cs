using System;

namespace Gridat
{
	/// <summary>
	/// Summary description for StatisticParam.
	/// </summary>
	public class StatisticParam
	{
		public StatisticParam(double[] array)
		{
			
			N = array.Length;
            if (N < 1) return;
            if (N == 1)
            {
                N = 1;
                Average = array[0];
                StdDev = 0;
                Sqewness = double.NaN;
                Kurtosis = double.NaN;
                Max = array[0];
                Min = array[0];
                Val25 = array[0];
                Val50 = array[0];
                Val75 = array[0];
                CV = 0;
                ZX = array[0];
                ZX2 = array[0] *array[0];
                return;
            }
			double x = 0;
			for (int i=0;i<array.Length-1;i++)
				for (int j = i;j<array.Length;j++)
				{
					if (array[i]>array[j])
					{
						x = array[i];
						array[i] = array[j];
						array[j] = x;
					}
				}
			Average = 0;
			StdDev = 0;
			for(int i=0;i<array.Length;i++)
			{
				ZX += array[i];
				ZX2 += Math.Pow(array[i],2);
			}
			Average= ZX/array.Length;
			for(int i=0;i<array.Length;i++)
			{
				StdDev += Math.Pow((array[i]-Average),2);
				Sqewness += Math.Pow((array[i]-Average),3);
				Kurtosis += Math.Pow((array[i]-Average),4);
			}
			double n = (double)array.Length;
			
			StdDev/=(array.Length - 1);
			StdDev = Math.Pow(StdDev,.5);
			Sqewness /= Math.Pow(StdDev,3);
			Sqewness *=n;
			Sqewness /=(n-1);
			Sqewness /=(n-2);
			Kurtosis /= Math.Pow(StdDev,4);
			Kurtosis*=n;
			Kurtosis*=(n+1);
			Kurtosis /=(n-1);
			Kurtosis /=(n-2);
			Kurtosis /=(n-3);
			Kurtosis -= (3*(n-1)*(n-1)/((n-2)*(n-3)));
			Max = array[array.Length - 1];
			Min = array[0];
            
//			Val25 = array[(int)(n/4+0.75)-1]*(1-(n/4+0.75)%1) + array[(int)(n/4+1.75)-1]*((n/4+0.75)%1);
//			Val50 = array[(int)(n/2+0.5)-1]*(1-(n/2+.5)%1) + array[(int)(n/2+1.5)-1]*((n/2+.5)%1);
//			Val75 = array[array.Length - (int)(n*1/4+0.75)]*(1-(n/4+0.75)%1) + array[array.Length - (int)(n*1/4+1.75)]*((n/4+0.75)%1);
			double q = .25;
			Val25 = array[(int)(n*q+1-q)-1]*(1-(n*q+1-q)%1) + array[(int)(n*q+2-q)-1]*((n*q+1-q)%1);
			q = .5;
			Val50 = array[(int)(n*q+1-q)-1]*(1-(n*q+1-q)%1) + array[(int)(n*q+2-q)-1]*((n*q+1-q)%1);
			q = .75;
			Val75 = array[(int)(n*q+1-q)-1]*(1-(n*q+1-q)%1) + array[(int)(n*q+2-q)-1]*((n*q+1-q)%1);
			Perc = new double[11];
			for(int i=0;i<10;i++)
			{
				q = (double)i/10;
				Perc[i] = array[(int)(n*q+1-q)-1]*(1-(n*q+1-q)%1) + array[(int)(n*q+2-q)-1]*((n*q+1-q)%1);
			}
			Perc[10] = Max;
			CV = StdDev/Average;
		}
		public int N;
		public double Average;
		public double StdDev;
		public double Sqewness;
		public double Kurtosis;
		public double Max;
		public double Min;
		public double Val25;
		public double Val50;
		public double Val75;
		public double CV;
		public double ZX;
		public double ZX2;
		public double[] Perc;


	}
}
