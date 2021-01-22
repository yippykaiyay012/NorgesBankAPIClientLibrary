using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorgesBankAPIClientLibrary
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class BankResult
    {
        public Meta meta { get; set; }
        public Data data { get; set; }
    }
    public class Sender
    {
        public string id { get; set; }
    }

    public class Receiver
    {
        public string id { get; set; }
    }

    public class Link
    {
        public string href { get; set; }
        public string rel { get; set; }
        public string uri { get; set; }
        public string urn { get; set; }
    }

    public class Meta
    {
        public string id { get; set; }
        public DateTime prepared { get; set; }
        public bool test { get; set; }
        public Sender sender { get; set; }
        public Receiver receiver { get; set; }
        public List<Link> links { get; set; }
    }

    public class Observations
    {
        [JsonProperty("0")]
        public List<string> _0 { get; set; }
    }

    public class _0000
    {
        public List<int> attributes { get; set; }
        public Observations observations { get; set; }
    }

    public class Series
    {
        [JsonProperty("0:0:0:0")]
        public _0000 _0000 { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int keyPosition { get; set; }
        public object role { get; set; }
        public List<Value> values { get; set; }
        public Relationship relationship { get; set; }
    }

    public class DataSet
    {
        public List<Link> links { get; set; }
        public string action { get; set; }
        public Series series { get; set; }
    }

    public class Names
    {
        public string en { get; set; }
    }

    public class Descriptions
    {
        public string en { get; set; }
    }

    public class Value
    {
        public string id { get; set; }
        public string name { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
    }

    public class Observation
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int keyPosition { get; set; }
        public string role { get; set; }
        public List<Value> values { get; set; }
    }

    public class Dimensions
    {
        public List<object> dataset { get; set; }
        public List<Series> series { get; set; }
        public List<Observation> observation { get; set; }
    }

    public class Relationship
    {
        public List<string> dimensions { get; set; }
    }

    public class Attributes
    {
        public List<object> dataset { get; set; }
        public List<Series> series { get; set; }
        public List<object> observation { get; set; }
    }

    public class Structure
    {
        public List<Link> links { get; set; }
        public string name { get; set; }
        public Names names { get; set; }
        public string description { get; set; }
        public Descriptions descriptions { get; set; }
        public Dimensions dimensions { get; set; }
        public Attributes attributes { get; set; }
    }

    public class Data
    {
        public List<DataSet> dataSets { get; set; }
        public Structure structure { get; set; }
    }


}
