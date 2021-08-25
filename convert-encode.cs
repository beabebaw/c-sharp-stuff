/*
-> 2-bits arrays
A: 0b00      C: 0b01
T: 0b11      G: 0b10

String:   "CATCGTCAGGAC"
Bits:     0b010011011011010010100001
Byte[]:   [0x4D, 0xB4, 0xA1] // notice the bits to byte conversion is Big-Endian
Base64:   "TbSh"

TASK --> preciso de alguma coisa que converta bytes para 2-bits
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

       // Restore the byte array.
       byte[] bytes2 = Convert.FromBase64String(string1);
       Console.WriteLine("The restored byte array: ");
	   Console.WriteLine("   {0}\n", BitConverter.ToString(bytes2));
	   
	   // convert the byte array to a string
	   byte[] newBytes = {67, 65, 84, 67, 71, 84, 67, 65, 71, 71, 65};
	   string string2 = Encoding.Default.GetString(newBytes);
	   Console. WriteLine("The String is: \n   {0}\n", string2);

	   // convert the string to a byte array
	   byte[] bytes3 = Encoding.Default.GetBytes("CATCGTCAGGA");
	   Console. WriteLine("Byte Array is: \n   {0}\n", String.Join(" ", bytes3));
   }
} 
