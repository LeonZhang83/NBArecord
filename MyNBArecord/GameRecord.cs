using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNBArecord
{
    public class GameRecord
    {
        public string AwayName,HomeName,Status;
        public string AwayScore, HomeScore;
        public string AwayQpoint, HomeQpoint;

        public GameRecord(string AwayName, string HomeName, string Status, string AwayScore, string HomeScore, string AwayQpoint, string HomeQpoint)
        {
            this.AwayName = AwayName;
            this.HomeName = HomeName;
            this.Status = Status;
            this.AwayScore = AwayScore;
            this.HomeScore = HomeScore;
            this.AwayQpoint = AwayQpoint;
            this.HomeQpoint = HomeQpoint;
        }
        /*
        public string getAwayName() { return this.AwayName; }
        public string getHomeName() { return this.HomeName; }
        public string getStatus() { return this.Status; }
        public string getAwayScore() { return this.AwayScore; }
        public string getHomeScore() { return this.HomeScore; }
        */
    }
}
