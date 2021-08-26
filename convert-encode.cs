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
	   
       // Define a byte array.
       byte[] bytes1 = {0x4D, 0xB4, 0xA1};
       Console.WriteLine("The byte array: ");
       Console.WriteLine("   {0}\n", BitConverter.ToString(bytes1));

       // Convert the array to a base 64 string.
       string string1 = Convert.ToBase64String(bytes1);
       Console.WriteLine("The base 64 string:\n   {0}\n", string1);

       // Convert a base 64 string to byte array.
       byte[] bytes2 = Convert.FromBase64String(string1);
       Console.WriteLine("The restored byte array: ");
	   Console.WriteLine("   {0}\n", BitConverter.ToString(bytes2));
	   
	   // convert the byte array to a string
	   byte[] newBytes = {67, 65, 84, 67, 71, 84, 67, 65, 71, 71, 65, 67};
	   string string2 = Encoding.Default.GetString(newBytes);
	   Console. WriteLine("The String is: \n   {0}\n", string2);

	   // convert the string to a byte array
	   byte[] bytes3 = Encoding.Default.GetBytes(string2);
	   Console. WriteLine("Byte Array is: \n   {0}\n", String.Join(" ", bytes3));
	   
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
    static string ToBinaryString( Encoding encoding, string text )
    {
		var binary01 = encoding.GetBytes( text ).Select( n => Convert.ToString( n, 2 ).PadLeft( 8, '0' ) );
		var binary02 = encoding.GetBytes( text );
        return string.Join( " ", binary01);
    }

    static void Main( string[] args )
    {
        Console.WriteLine( ToBinaryString( Encoding.UTF8, "CATCGTCAGGAC" ) );
    }
}

// public byte[] ToArray ();
