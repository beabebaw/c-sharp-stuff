// i want to check if theres an n amount of string01 in string02
// it can start at any index and go straight, but it need to contain at least 1/2 of the string01 within string02

using System;

public class CheckGene
{
	public static void Main()
	{
		//string gene = "012345678";
		//string dnaStrand = "28347928348456423424567834239423";
		string gene = "TACCGCTTCATAAACCGCTAGACTGCATGATCGGGT";
		string dnaStrand = "CATCTCAGTCCTACTAAACTCGCGAAGCTCATACTAGCTACTAAACCGCTAGACTGCATGATCGCATAGCTAGCTACGCT";
   
		int isStringIndexEven = gene.Length % 2;
		Console.WriteLine("String is even: {0}", isStringIndexEven == 0);
		
		// GENE SUBSTRING HAS EVEN NUMBERS OS CHARACTERS
		if (isStringIndexEven == 0)
		{
			int endIndex = gene.Length / 2;
			Console.WriteLine("Each part of the string has {0} characters \n", endIndex);
			// SPLIT AND CHECKING IF THE DNA STRAND CONTAINS THE GENE SUBSTRING
			// IT RUNS THROUGH THE INDEX ONE BY ONE WITH A SUBSTRING WITH CONSTANTE LENGTH
			for (int startIndex = 0; startIndex <= endIndex; startIndex++)
			{    
				string geneSubstring = gene.Substring(startIndex, endIndex);
				bool b = dnaStrand.Contains(geneSubstring);
				
				// CHECKING IF DNA STRAND CONTAINS GENE SUBSTRING
				if (b == true)
				{
					Console.WriteLine("String2 contains String1");
					Console.WriteLine("Part: {0}\n", geneSubstring);
					break;
				}
				else
				{
					if (startIndex == endIndex)
					{
						Console.WriteLine("String2 doesn't contains String1");
						break;
					}
				}
			}
		}
		
		// GENE SUBSTRING HAS ODD NUMBERS OS CHARACTERS
		else
		{
			int endIndex = (gene.Length + 1) / 2;
			Console.WriteLine("Each part of the string has {0} characters \n", endIndex);
			for (int startIndex = 0; startIndex < endIndex; startIndex++)
			{    
				string geneSubstring = gene.Substring(startIndex, endIndex);
				bool b = dnaStrand.Contains(geneSubstring);
				
				// CHECKING IF DNA STRAND CONTAINS GENE SUBSTRING
				if (b == true)
				{
					Console.WriteLine("String2 contains String1");
					Console.WriteLine("Part: {0}\n", geneSubstring);
					break;
				}
				else
				{
					if (startIndex == endIndex - 1)
					{
						Console.WriteLine("String2 doesn't contains String1");
						break;
					}
				}
			}
		}
	}
} 
