using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
  Solution for r/dailyprogrammer challenge #215

  http://www.reddit.com/r/dailyprogrammer/comments/36cyxf/20150518_challenge_215_easy_sad_cycles/

 */

namespace SadCycles
{
    class Program
    {
        static void Main(string[] args)
        {
	    int power = Convert.ToInt32(Console.ReadLine());
	    int number = Convert.ToInt32(Console.ReadLine());
	    
	    List<int> sadCycle = GetSadCycle(number, power);
	    foreach(int i in sadCycle)
		Console.WriteLine(i);	    
        }

	static List<int> GetSadCycle(int number, int power)
	{
	    List<int> mainCycle = new List<int>();
	    int nextValue = number;

	    while(true)
	    {
	        nextValue = AddValuesOfEachDigitToThePowerOfN(nextValue, power);
		if(nextValue == 1 || NumberAppearedInCycle(mainCycle, nextValue))
		    break;
		
		mainCycle.Add(nextValue);
	    }

	    return FindSadCycle(mainCycle, nextValue);
	}
	
	static int AddValuesOfEachDigitToThePowerOfN(int number, int n)
	{
	    int [] digits = ExtractDigits(number);

	    int sum = 0;
	    
	    foreach(int i in digits)
	    {
		sum += (int)Math.Pow(i, n);
	    }

	    return sum;
	}

	static int[] ExtractDigits(int number)
	{
	    string numberString = number.ToString();
	    int [] digits = new int[numberString.Length];
	    for(int i = 0; i < digits.Length; i++)
	    {
		digits[i] = int.Parse(numberString[i].ToString());
	    }

	    return digits;
	}

	static bool NumberAppearedInCycle(List<int> cycle, int number)
	{
	    return cycle.Contains(number);
	}

	static List<int> FindSadCycle(List<int> cycle, int nextValue)
	{
	    if(nextValue == 1)
		return new List<int>(new int[1] {1});

	    List<int> sadCycle = new List<int>();

	    int cycleStart = -1;

	    for(int i = 0; i < cycle.Count(); i++)
	    {
		if(cycle[i] == nextValue)
		{
		    cycleStart = i;
		    break;
		}
	    }

	    for(int i = cycleStart; i < cycle.Count(); i++)
	    {
		sadCycle.Add(cycle[i]);
	    }

	    return sadCycle;
	}
    }
}
