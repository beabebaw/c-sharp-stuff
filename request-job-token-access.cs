using System;
using System.IO;
using System.Net;

var url = "https://gene.lacuna.cc/api/dna/jobs";
var token = "3C801A614966D740B82C96F4439416C90EFAA463ED9D5C9047012E65245BBF5F6C835817387674FF19BD1CCF250AA364376D218E41FCF2D0EDE1998ACB82B781CA06B6060EEAF1E31829EE4D64A0FEA2";

var httpRequest = (HttpWebRequest)WebRequest.Create(url);
httpRequest.Method = "GET";

httpRequest.Accept = "application/json";
httpRequest.Headers["Authorization"] = "Bearer " + token;

var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
var streamReader = new StreamReader(httpResponse.GetResponseStream());
var result = streamReader.ReadToEnd();

Console.WriteLine(httpResponse.StatusCode);
Console.WriteLine(result);
