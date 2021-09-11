using System;
using System.IO;
using System.Text;
using System.Net;
using System.Text.Json;
using System.Collections.Generic;

var user = new Dictionary<string, string>(){
	{"username", "JohnDoe"},
	{"email", "johngardener@gmail.com"},
	{"password", "jardineiro94"}
};

HttpRequest.Create(user);

// Checking if the return has only username and password keywords
//foreach (KeyValuePair<string, string> i in user)  
//    {  
//        Console.WriteLine("Key: {0}, Value: {1}",  
//            i.Key, i.Value);  
//    }

// POST request to https://gene.lacuna.cc/api/users/create. The data sent is in JSON format 
public class HttpRequest
{
	public static object Create(Dictionary <string, string> user)
	{
		var url = "https://gene.lacuna.cc/api/users/create";

		// the request method is set to POST
		var request = WebRequest.Create(url);
		request.Method = "POST";

		// serialize an user object to JSON and transform it into an array of bytes 
		//var user = new User("JohnDoe", "johngardener@gmail.com", "jardineiro94");
		var json = JsonSerializer.Serialize(user);
		byte[] byteArray = Encoding.UTF8.GetBytes(json);

		request.ContentType = "application/json";
		request.ContentLength = byteArray.Length;

		// get the stream of the request with GetRequestStream and write the byte array into the stream with Write
		using var reqStream = request.GetRequestStream();
		reqStream.Write(byteArray, 0, byteArray.Length);

		// get response with GetResponse
		using var response = request.GetResponse();
		// and print the status of the response
		Console.WriteLine(((HttpWebResponse)response).StatusDescription);

		// read the data from the response stream
		using var respStream = response.GetResponseStream();

		using var reader = new StreamReader(respStream);
		string data = reader.ReadToEnd();
		Console.WriteLine(data);
		
		reader.Close();
		respStream.Close();
		response.Close();
		
		return user.Remove("email");
		//record User(string username, string email, string password);
	}
}
