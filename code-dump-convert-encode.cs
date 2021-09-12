// THIS IS SOME SHIT ABOUT THE REQUEST JOB WITH ACCESS TOKEN ETC

using System;
using System.Collections.Generic;

// DATA STRING
string data = "{'job':{'id':'d3617e21a4674e58a5d90d0ef1e11514','type':'CheckGene','strandEncoded':'TKqH1AVi+gYnL4wIX/s3sKrzYcRlBN0c4ObhLB9ZZoMPD3xJjppoazeo4Euvn6NWP8nV9POHHTv7vlOb6loyYBWNHEfgjKEPivaNvSOSbUBCgF1+dmk+RfhLfSSmSeppwROCpqZT4eF/03JOPFkMOv203ABwaFdfyrRXMnD8aUEMI/wQD8aa7557/qL28AieP0In8m3p+Vm8Itzx+65xg2oxQRld/Co2Ge1i9Gq0admsufMt1XfUIiqiU+3pqPPvCXs4xK/uQEIY8Nh/hgTvB7kDRUK7Q63zXR7vuqg9TXH5curufKQqvXmwFeSeVJsls0wz5mOxNMbNRGaQ/4Wa2qNnhhQZAIsU2YjJCi4=','geneEncoded':'yFQJg8oHXAlnDUg+JCE3PZq+8xY6QTfNhwuzwB8M2+cplwTwXQ01fj7RPFk91fXeU9Y/ydX084cdO/u+U5vqWjJgFY0cR+CMiXXY'},'code':'Success'}";

char[] splitChars = {',', ':'};
string[] splitData = data.Split(splitChars);
List<string> dataStringList = new List<string>();

 foreach (var sub in splitData)
{
	char[] trimChars = { '{', '}', '\''};
	var subList = sub.Trim(trimChars);
    //Console.WriteLine($"Substring: {subList}");
	dataStringList.Add(subList);
}

//Console.WriteLine(String.Join(" ", stringList));
Console.WriteLine("Job id: {0}\n", dataStringList[2]);
Console.WriteLine("Job type: {0}\n", dataStringList[4]);
Console.WriteLine("Strand encoded: {0}\n", dataStringList[6]);
Console.WriteLine("Gene encoded: {0}", dataStringList[8]);

// -----------------------------------------------------------------------------------------------------------------------------

/*
CODE TO CONVERT SRTING STRAND IN BASE64
*/

using System;
using System.Linq;
using System.Collections.Generic;

public class Example
{
	public static void Main()
	{
		// STRAND STRING
		string strand = "CATCGTCAGGAC";
		
		// SPLIT STRAND INTO ARRAYS
		int chunkSize = 1;
		int stringLength = strand.Length;
		List<string> strandStringList = new List<string>();

		for (int i = 0; i < stringLength ; i += chunkSize)
		{
			if (i + chunkSize > stringLength) chunkSize = stringLength - i;
			{
				strandStringList.Add(strand.Substring(i, chunkSize));
				Console.WriteLine("   {0}", strand.Substring(i, chunkSize));
			}
		}
		//Console.WriteLine(String.Join(", ", strandStringList));

		// CHARS TO BINARY
		List<string> binaryStringArray = new List<string>();
		
		foreach (string a in strandStringList)
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
		Console.WriteLine(String.Join("", binaryStringArray));
	}
} 

// -----------------------------------------------------------------------------------------------------------------------------

/* TO CONVERT BINARY TO HEX BYTES - UNDER CONSTRUCTION */

using System;
using System.Text;
using System.Collections.Generic;

class Program
{
	static void Main()
	{
		string strHex = Convert.ToInt32("010011011011010010100001",2).ToString("X");
		Console.WriteLine(strHex);

		//string hex = String.Format("{0:X2}", Convert.ToUInt64("010011011011010010100001", 2));
		//Console.WriteLine(Convert.ToByte(hex));

		int chunkSize = 2;
		int stringLength = strHex.Length;
		
		string[] stringArray = new string[stringLength];
		//string[] oi = {"-"};
		
		for (int i = 0; i < stringLength ; i += chunkSize)
		{
			if (i + chunkSize > stringLength) chunkSize = stringLength - i;
			{
				//sb.Insert(i + 2, "x");
				//Console.WriteLine(cars.Join<string>("-", cars));
				//Console.WriteLine(i);
				Console.WriteLine("   {0}", strHex.Substring(i, chunkSize));
				stringArray.Append(strHex.Substring(i, chunkSize));
				Console.WriteLine(string.Join("x", stringArray));
			}
		}
		//Console.WriteLine(result);
	}
}

/* THIS WILL BE VERY USEFUL

using System;
using System.Linq;
using System.Globalization;
					
public class Program
{
	public static void Main()
	{
	string s = "4D-B4-A1";
	byte[] bytes = s.Split('-')
    .Select(x => byte.Parse(x, NumberStyles.HexNumber))
    .ToArray();
	
	string a = Convert.ToBase64String(bytes);
	Console.WriteLine(a);
		
	Console.WriteLine(BitConverter.ToString(bytes));
	}
}

*/

// -----------------------------------------------------------------------------------------------------------------------------

/*
1st get the strandEncoded and convert to an hexadecimal array
2nd with the hex array parse it as a binary string
3rd split the binary string in pairs and put in a array
4th associate every binary pair with a char in a loop
*/

using System;
using System.Text;
using System.Linq;

public class Example
{
   public static void Main()
   {
	// BASE64
	string base64 = "T+vX+o2Z7TflV/EwZ6HfOhAtu5Ai5hyNakZQiHGqDAtXU9L14fqWuI7GpKBELXO17HVhXU0G72DOSo9GSWXGOkrl2RPP6VgVlwMBXEF8SD3Tmpv7Sa6+UWNxJ5ZrT24pAGpVX1Rf5gMdS8ZJBJMfUgJSc6/JyvCcJoivXsLBqkeU11vXJujoc7SY3v7odUzPUtWUGNu/XzV6uTjLsIdAW6F+tC04SCsZaQD6Mezxs7E83wztLZFs1HclXG2wHcMsV4JdacAflwmpeq7axC5JiAWHj9B7Uy4PEt+1Euu+aEw9ztlplErwHEgCQ7LjkRBI3NRnKY3ysARUTlbgaYUe6xJinfVV3/O7lnKHeQ97K4E=";

	// BASE64 TO HEXADECIMAL ARRAY
	byte[] hexArray = Convert.FromBase64String(base64);
	Console.WriteLine("Base64 to Hex array: ");
	Console.WriteLine("   {0}\n", BitConverter.ToString(hexArray));	   
	
	var binary = string.Join(" ",hexArray.Select(n => Convert.ToString(n, 2).PadLeft(8, '0')));
	Console.WriteLine("Hex array do Binary: ");
	Console.WriteLine("   {0}\n", binary);
	   
	// NOW I NEED TO GET THIS BINARY CODE AND SEPARATE BY PAIRS
	
	//Console.WriteLine("Hex array: ");
	//Console.WriteLine("   {0}\n", BitConverter.ToString(hexArray));
	
	// HEXADECIMAL ARRAY TO BASE64
	//string string1 = Convert.ToBase64String(hexArray);
	//Console.WriteLine("Hex array to base64:\n   {0}\n", string1);

	// BASE64 TO HEXADECIMAL ARRAY
	//byte[] hexArray = Convert.FromBase64String(string1);
	//Console.WriteLine("Base64 to Big Endian: ");
	//Console.WriteLine("   {0}\n", BitConverter.ToString(bytes2));	   
   }
} 

// -----------------------------------------------------------------------------------------------------------------------------

/*
-> 2-bits arrays
A: 0b00      C: 0b01
T: 0b11      G: 0b10
String:   "CATCGTCAGGAC"
Bits:     0b010011011011010010100001
Byte[]:   [0x4D, 0xB4, 0xA1] // notice the bits to byte conversion is Big-Endian
Base64:   "TbSh"
TASK --> preciso de alguma coisa que converta bytes para 2-bits
o objetivo é receber string e converter para base64
*/

using System;
using System.Text;

public class Example
{
   public static void Main()
   {
	// BYTE ARRAYS
	byte[] bigEndian = {0x4D, 0xB4, 0xA1};
	byte[] decBytes = {67, 65, 84, 67, 71, 84, 67, 65, 71, 71, 65, 67};
	byte[] hexBytes = {43, 41, 54, 43, 47, 54, 43, 41, 47, 47, 41, 43};

	Console.WriteLine("Big endian array: ");
	Console.WriteLine("   {0}\n", BitConverter.ToString(bigEndian));
	Console.WriteLine("Decimal array: ");
	Console.WriteLine("   {0}\n", BitConverter.ToString(decBytes));
	Console.WriteLine("Hexadecimal array: ");
	Console.WriteLine("   {0}\n", BitConverter.ToString(hexBytes));

	// BIG ENDIAN BYTE ARRAY TO BASE64
	string string1 = Convert.ToBase64String(bigEndian);
	Console.WriteLine("Big Endian to Base64:\n   {0}\n", string1);

	// BASE64 TO BIG ENDIAN BYTE ARRAY
	byte[] bytes2 = Convert.FromBase64String(string1);
	Console.WriteLine("Base64 to Big Endian: ");
	Console.WriteLine("   {0}\n", BitConverter.ToString(bytes2));

	// DECIMAL BYTE ARRAY TO STRING
	string string2 = Encoding.Default.GetString(decBytes);
	Console. WriteLine("Decimal byte array to String: \n   {0}\n", string2);

	// STRING TO BYTE ARRAY
	byte[] bytes3 = Encoding.Default.GetBytes(string2);
	Console. WriteLine("String to Byte array: \n   {0}\n", String.Join("-", bytes3));

	// STRING TO BYTE ARRAY
	byte[] oi = Encoding.Default.GetBytes("CATCGTCAGGAC");
	Console.WriteLine("String to apparently hex byte array: ");
	Console.WriteLine("   {0}\n", BitConverter.ToString(oi));

	byte[] tchau = Encoding.Convert(Encoding.Default, Encoding.UTF8, oi);
	Console.WriteLine("String Byte array: ");
	Console.WriteLine("   {0}\n", BitConverter.ToString(tchau));
	   
   }
} 

// -----------------------------------------------------------------------------------------------------------------------------

/* using System;
using System.Text;

byte[] bytes = Encoding.Default.GetBytes("CATCGTCAGGAC");
string encodedStr = Convert.ToBase64String(bytes);
string inputStr = Encoding.Default.GetString(Convert.FromBase64String(encodedStr));

Console.WriteLine(BitConverter.ToString(bytes));
Console.WriteLine(encodedStr);
Console.WriteLine(inputStr); */

// STRING TO 2-BITS BINARY

using System;
using System.Linq;
using System.Text;

class Program
{
    static string ToBinaryString01( Encoding encoding, string text )
    {
	var binary = encoding.GetBytes( text ).Select( n => Convert.ToString( n, 2 ).PadLeft( 8, '0' ) );
        return string.Join( " ", binary);
    }
	
	static string ToBinaryString02( Encoding encoding, string text )
    {
	var binary = encoding.GetBytes( text ).Select( n => Convert.ToString( n, 2 ));
        return string.Join( " ", binary);
    }
	
	static string ToBinaryString03( Encoding encoding, string text )
    {
	var binary = encoding.GetBytes( text );
        return string.Join( " ", binary);
    }

    static void Main( string[] args )
    {
        Console.WriteLine("With padding: \n   {0}\n", ToBinaryString01( Encoding.UTF8, "CATCGTCAGGAC" ) );
	Console.WriteLine("Without padding: \n   {0}\n", ToBinaryString02( Encoding.UTF8, "CATCGTCAGGAC" ) );
	Console.WriteLine("Without Select method: \n   {0}\n", ToBinaryString03( Encoding.UTF8, "CATCGTCAGGAC" ) );
    }
}

// -----------------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
					
public class Program
{
	public static void Main()
	{
		byte[] hexBytes = {43, 41, 54, 43, 47, 54, 43, 41, 47, 47, 41, 43};
		var olar = string.Join( " ",hexBytes.Select( n => Convert.ToString( n, 2 ).PadLeft( 8, '0')));
		var olar2 = string.Join( " ",hexBytes.Select( n => Convert.ToString( n, 8 )));
		var olar3 = string.Join( " ",hexBytes.Select( n => Convert.ToString( n, 16 )));

		Console.WriteLine(olar);
		Console.WriteLine(olar2);
		Console.WriteLine(olar3);
	}
}
