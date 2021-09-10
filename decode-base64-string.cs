using System;
using System.Linq;
using System.Collections.Generic;

// BASE64
string base64 = "T+vX+o2Z7TflV/EwZ6HfOhAtu5Ai5hyNakZQiHGqDAtXU9L14fqWuI7GpKBELXO17HVhXU0G72DOSo9GSWXGOkrl2RPP6VgVlwMBXEF8SD3Tmpv7Sa6+UWNxJ5ZrT24pAGpVX1Rf5gMdS8ZJBJMfUgJSc6/JyvCcJoivXsLBqkeU11vXJujoc7SY3v7odUzPUtWUGNu/XzV6uTjLsIdAW6F+tC04SCsZaQD6Mezxs7E83wztLZFs1HclXG2wHcMsV4JdacAflwmpeq7axC5JiAWHj9B7Uy4PEt+1Euu+aEw9ztlplErwHEgCQ7LjkRBI3NRnKY3ysARUTlbgaYUe6xJinfVV3/O7lnKHeQ97K4E=";

Console.WriteLine(Decode.DecodingBase64(base64));

public class Decode
{
	public static string DecodingBase64(string base64)
	{
		// BASE64 TO HEXADECIMAL ARRAY
		byte[] hexArray = Convert.FromBase64String(base64);
		//Console.WriteLine("Base64 to Hex array: ");
		//Console.WriteLine("   {0}\n", BitConverter.ToString(hexArray));	   

		// HEX ARRAY TO BINARY STRING
		var binary = string.Join("",hexArray.Select(n => Convert.ToString(n, 2).PadLeft(8, '0')));
		//Console.WriteLine("Hex array to Binary: ");
		//Console.WriteLine("   {0}\n", binary);

		// SPLIT BINARY STRING INTO 2BITS ARRAYS
		int chunkSize = 2;
		int stringLength = binary.Length;
		List<string> binaryStringList = new List<string>();

		for (int i = 0; i < stringLength ; i += chunkSize)
		{
			if (i + chunkSize > stringLength) chunkSize = stringLength - i;
			{
				binaryStringList.Add(binary.Substring(i, chunkSize));
				//Console.WriteLine("   {0}", binary.Substring(i, chunkSize));
			}
		}
		//Console.WriteLine(String.Join(", ", binaryStringList));

		// 2BITS TO CHARS
		List<string> strandString = new List<string>();
		
		foreach (string a in binaryStringList)
		{
			if (a == "00") 
			{
				strandString.Add("A");
			} 
			else if (a == "01") 
			{
				strandString.Add("C");
			} 
			else if (a == "11")
			{
				strandString.Add("T");
			}
			else
			{
				strandString.Add("G");
			} 
		}
		//Console.WriteLine(String.Join("", strandString));
		string convertedStrandString = String.Join("", strandString);
		return convertedStrandString;
	}
} 
