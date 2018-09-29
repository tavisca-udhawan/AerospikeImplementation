using Aerospike.Client;
using AerospikeWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AerospikeWebApi.DataAccess
{
    public class Tweet
    {
        public List<Data> getData(List<long> id)
        {
            try
            {
                var aerospikeClient = new AerospikeClient("18.235.70.103", 3000);
                string nameSpace = "AirEngine";
                string setName = "Utkarsh";
                List<Data> tweetData = new List<Data>();
                foreach(long tid in id)
                {
                    Record record = aerospikeClient.Get(new BatchPolicy(), new Key(nameSpace, setName, tid.ToString()));
                    Data tweet = new Data();
                    tweet.TweetId =Convert.ToInt64(record.GetValue("tweet_id").ToString());
                    tweet.Author = record.GetValue("author").ToString();
                    tweet.Content = record.GetValue("content").ToString();
                    tweet.Region= record.GetValue("region").ToString();
                    tweet.Language = record.GetValue("language").ToString();
                    tweet.Following = Convert.ToInt32(record.GetValue("following").ToString());
                    tweetData.Add(tweet);
                }
                return tweetData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool DeleteData(List<long> id)
        {
            try
            {
                var aerospikeClient = new AerospikeClient("18.235.70.103", 3000);
                string nameSpace = "AirEngine";
                string setName = "Utkarsh";
                List<Data> tweetData = new List<Data>();
                foreach (long tid in id)
                {
                    Key key= new Key(nameSpace, setName, tid.ToString());
                    aerospikeClient.Delete(new WritePolicy(),key);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool PutData(Data data)
        {
            try
            {
                var aerospikeClient = new AerospikeClient("18.235.70.103", 3000);
                string nameSpace = "AirEngine";
                string setName = "Utkarsh";
                List<Data> tweetData = new List<Data>();
                Key key = new Key(nameSpace, setName,data.TweetId.ToString());
                    aerospikeClient.Put(new WritePolicy(), key, new Bin[] { new Bin("content", data.Content) });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
