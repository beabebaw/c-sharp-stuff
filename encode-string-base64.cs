using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;

string stringStrand = "TAAGGAGTTAGGTACTAAGCCCCTCGGGTTCGAGCATATAAGGGCCCCGAGAGCTTATAAGGAGTTAGGTACTAAGCCCCTCGGGTTCGTAAGACCGTAAGAGAGCTTATAAGGAGTTAGGTACTAAG";
//Console.WriteLine(stringStrand.Length);

Console.WriteLine(Encode.EncodingString(stringStrand));

public class Encode
{
	public static string EncodingString(string stringStrand)
	{
		// SPLIT STRAND INTO STRING LIST
		int chunkSize = 1;
		int stringLength = stringStrand.Length;
		List<string> stringStrandList = new List<string>();

		for (int i = 0; i < stringLength ; i += chunkSize)
		{
			if (i + chunkSize > stringLength) chunkSize = stringLength - i;
			{
				stringStrandList.Add(stringStrand.Substring(i, chunkSize));
				//Console.WriteLine("   {0}", strand.Substring(i, chunkSize));
			}
		}
		//Console.WriteLine(String.Join(", ", strandStringList));

		// EACH STRING LIST ITEM TO BINARY
		List<string> binaryStringList = new List<string>();
		
		foreach (string a in stringStrandList)
		{
			if (a == "A") 
			{
				binaryStringList.Add("00");
			} 
			else if (a == "C") 
			{
				binaryStringList.Add("01");
			} 
			else if (a == "T")
			{
				binaryStringList.Add("11");
			}
			else
			{
				binaryStringList.Add("10");
			} 
		}
		string binaryString = String.Join("", binaryStringList);
		//Console.WriteLine(String.Join("", binaryStringList));
		//Console.WriteLine(binaryStringList.Count);
		
		int binaryChunkSize = 4;
		int binaryLength = binaryString.Length;
		List<string> binaryChunkList = new List<string>();

		for (int i = 0; i < binaryLength ; i += binaryChunkSize)
		{
			if (i + binaryChunkSize > binaryLength) binaryChunkSize = binaryLength - i;
			{
				binaryChunkList.Add(binaryString.Substring(i, binaryChunkSize));
				//Console.WriteLine("   {0}", strand.Substring(i, binaryChunkSize));
			}
		}
		//Console.WriteLine(String.Join(" - ", binaryChunkList));
		
		// BINARY TO HEX STRING
		List<string> hexList = new List<string>();
		foreach (string item in binaryChunkList)
		{
			string hexChunkString = Convert.ToInt64(item, 2).ToString("X");
			hexList.Add(hexChunkString);
			//Console.WriteLine(hexChunkString);
		}
		string hexString = String.Join("", hexList);
		//Console.WriteLine(String.Join("", hexList));
		
		// FORMATTING HEX STRING
		for (int i = 2; i <= hexString.Length; i += 2)
		{
		    hexString = hexString.Insert(i, "-");
		    i++;
		}
		string formatStringHex = hexString.TrimEnd('-');
		//Console.WriteLine(formatStringHex);
		
		// HEX STRING TO HEX BYTE THEN BASE64
		byte[] hexBytes = formatStringHex.Split('-')
		.Select(x => byte.Parse(x, NumberStyles.HexNumber))
		.ToArray();

		string base64String = Convert.ToBase64String(hexBytes);
		//Console.WriteLine(base64String);
		
		return base64String;
		//Console.WriteLine(BitConverter.ToString(hexBytes));
	}
}
