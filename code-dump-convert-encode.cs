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