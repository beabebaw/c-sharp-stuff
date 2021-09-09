// i want to check if theres an n amount of string01 in string02
// it can start at any index and go straight, but it need to contain at least 1/2 of the string01 within string02

using System;
using System.Collections.Generic;

string gene = "TACCGCTTCATAAACCGCTAGACTGCATGATCGGGT";
string inputDnaStrand = "CATCTCAGTCCTACTAAACTCGCGAAGCTCATACTAGCTACTAAACCGCTAGACTGCATGATCGCATAGCTAGCTACGCT";

Console.WriteLine(CheckGene.IsActivated(gene, inputDnaStrand));

public class CheckGene
{
	public static bool IsActivated(string gene, string inputDnaStrand)
	{
		// i need to check if the DNA strand is the template or the complementary one
		string TemplateOrComplementary(string value)
		{
			// IS THIS THE TEMPLATE OR COMPLEMENTARY STRAND?
			string isThisTheComplementaryStrand = inputDnaStrand.Substring(0, 3);
			if (isThisTheComplementaryStrand != "CAT")
			{
				//Console.WriteLine("This is the complementary strand\n");
				// DNA STRAND STRING TO DNA STRAND STRING LIST
				List<string> dnaStrandList = new List<string>();

				for (int i = 0; i < inputDnaStrand.Length; i++)
				{
					dnaStrandList.Add(inputDnaStrand.Substring(i, 1));
				}
				//Console.WriteLine(String.Join("-", dnaStrandList));

				List<string> dnaTemplateStrandList = new List<string>();

				// DNA COMPLEMENTARY STRAND TO TEMPLATE STRAND
				foreach (string a in dnaStrandList)
				{
					if (a == "A") 
					{
						dnaTemplateStrandList.Add("T");
					} 
					else if (a == "C") 
					{
						dnaTemplateStrandList.Add("G");
					} 
					else if (a == "T")
					{
						dnaTemplateStrandList.Add("A");
					}
					else
					{
						dnaTemplateStrandList.Add("C");
					} 
				}
				string dnaTemplateStrand = String.Join("", dnaTemplateStrandList);
				return dnaTemplateStrand;
			} else
			{
				string dnaTemplateStrand = inputDnaStrand;
				return dnaTemplateStrand;
			}
		}
		
		//Console.WriteLine("This is a template strand: \n{0}\n", TemplateOrComplementary(inputDnaStrand));
		var dnaStrand = TemplateOrComplementary(inputDnaStrand);
		
		// ---------------------------------------------------------------------------------------------------
   
		int isStringIndexEven = gene.Length % 2;
		//Console.WriteLine("String is even: {0}", isStringIndexEven == 0);
		
		bool geneActivated = true;
		
		// GENE SUBSTRING HAS EVEN NUMBERS OF CHARACTERS
		if (isStringIndexEven == 0)
		{
			int endIndex = gene.Length / 2;
			//Console.WriteLine("Each part of the string has {0} characters \n", endIndex);
			
			// SPLIT AND CHECKING IF THE DNA STRAND CONTAINS THE GENE SUBSTRING
			// IT RUNS THROUGH THE INDEX ONE BY ONE WITH A SUBSTRING WITH CONSTANTE LENGTH
			for (int startIndex = 0; startIndex <= endIndex; startIndex++)
			{    
				string geneSubstring = gene.Substring(startIndex, endIndex);
				bool b = dnaStrand.Contains(geneSubstring);
				
				// CHECKING IF DNA STRAND CONTAINS GENE SUBSTRING
				if (b == true)
				{
					geneActivated = true;
					//Console.WriteLine("String2 contains String1");
					//Console.WriteLine("Part: {0}\n", geneSubstring);
					break;
				}
				else
				{
					if (startIndex == endIndex)
					{
						//Console.WriteLine("String2 doesn't contains String1");
						break;
					}
					geneActivated = false;
				}
			}
		}
		
		// GENE SUBSTRING HAS ODD NUMBERS OF CHARACTERS
		else
		{
			int endIndex = (gene.Length + 1) / 2;
			//Console.WriteLine("Each part of the string has {0} characters \n", endIndex);
			for (int startIndex = 0; startIndex < endIndex; startIndex++)
			{    
				string geneSubstring = gene.Substring(startIndex, endIndex);
				bool b = dnaStrand.Contains(geneSubstring);
				
				// CHECKING IF DNA STRAND CONTAINS GENE SUBSTRING
				if (b == true)
				{
					geneActivated = true;
					//Console.WriteLine("String2 contains String1");
					//Console.WriteLine("Part: {0}\n", geneSubstring);
					break;
				}
				else
				{
					if (startIndex == endIndex - 1)
					{
						//Console.WriteLine("String2 doesn't contains String1");
						break;
					}
					geneActivated = false;
				}
			}
		}
		return geneActivated;
	}
} 
