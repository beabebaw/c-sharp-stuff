using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;

public class Encode
{
	public static void Main()
	{
		// STRAND STRING
		string stringStrand = "CATCGTCAGGAC";
		
		// SPLIT STRAND INTO ARRAYS
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

		// CHARS TO BINARY
		List<string> binaryStringArray = new List<string>();
		
		foreach (string a in stringStrandList)
		{
			if (a == "A") 
			{
				binaryStringArray.Add("00");
			} 
			else if (a == "C") 
			{
				binaryStringArray.Add("01");
			} 
			else if (a == "T")
			{
				binaryStringArray.Add("11");
			}
			else
			{
				binaryStringArray.Add("10");
			} 
		}
		string binaryString = String.Join("", binaryStringArray);
		//Console.WriteLine(String.Join("", binaryStringArray));
		
		// BINARY TO HEX STRING
		string hexString = Convert.ToInt32(binaryString, 2).ToString("X");
		//Console.WriteLine(strHex);
		
		// FORMATTING HEX STRING
        for (int i = 2; i <= hexString.Length; i += 2)
        {
            hexString = hexString.Insert(i, "-");
            i++;
        }
		string formatStringHex = hexString.TrimEnd('-');
		//Console.WriteLine(formatStringHex);
		
		// STRING HEX TO BYTE HEX THEN BASE64
		byte[] hexBytes = formatStringHex.Split('-')
		.Select(x => byte.Parse(x, NumberStyles.HexNumber))
		.ToArray();

		string base64String = Convert.ToBase64String(hexBytes);
		Console.WriteLine(base64String);
		
		//Console.WriteLine(BitConverter.ToString(hexBytes));
	}
} 
