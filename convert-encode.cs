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

	// STRING TO DECIMAL BYTE ARRAY
	byte[] bytes3 = Encoding.Default.GetBytes(string2);
	Console. WriteLine("String to Decimal byte array: \n   {0}\n", String.Join("-", bytes3));

	// STRING TO HEXADECIMAL BYTE ARRAY
	byte[] oi = Encoding.Unicode.GetBytes("CATCGTCAGGAC");
	//Console.WriteLine("   {0}\n", BitConverter.ToString(oi));

	byte[] tchau = Encoding.Convert(Encoding.Unicode, Encoding.ASCII, oi);
	Console.WriteLine("String to Hexadecimal byte array: ");
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
