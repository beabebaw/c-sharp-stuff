using System;
using System.IO;
using System.Text;
using System.Net;
using System.Text.Json;
using System.Collections.Generic;

string decode = "";

Console.WriteLine(HttpRequest.Login(decode));

// POST request to https://gene.lacuna.cc/api/users/login. The data sent is in JSON format
// https://gene.lacuna.cc/api/dna/jobs/{id}/encode
// https://gene.lacuna.cc/api/dna/jobs/{id}/decode
// https://gene.lacuna.cc/api/dna/jobs/{id}/gene
public class HttpRequest
{
	public static string Login(string decode)
	{
		var accessToken = "";
		var id = "";
		var url = "https://gene.lacuna.cc/api/dna/jobs/" + id + "/decode";
		
		// the request method is set to POST
		var request = WebRequest.Create(url);
		request.Method = "POST";

		// serialize an user object to JSON and transform it into an array of bytes 
		//var user = new User("JohnDoe", "jardineiro94");
		var json = JsonSerializer.Serialize(decode);
		byte[] byteArray = Encoding.UTF8.GetBytes(json);

		request.ContentType = "application/json";
		request.Headers["Authorization"] = "Bearer " + accessToken;
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
		
		return data;
	}
}
