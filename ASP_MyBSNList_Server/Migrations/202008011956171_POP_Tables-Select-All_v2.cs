using System.Collections.Generic;
using Microsoft.SqlServer.Server;

namespace ASP_MyBSNList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class POP_TablesSelectAll_v2 : DbMigration
    {
        public override void Up()
        {
            #region cities
            List<string> cities = new List<string>
            {
                "Sydney","Wollongong","Adelaide","Brisbane","Perth","Darwin","Melbourne"
            };

            /*Sql("SET IDENTITY_INSERT dbo.Cities ON");
            for (int i = 0; i < cities.Length; i++)
            {
                Sql("INSERT INTO Cities (Id,Name) VALUES (" + i + ",'" + cities[i] + "')");
            }
            Sql("SET IDENTITY_INSERT dbo.Cities OFF");*/
            #endregion

            
            #region communicationTypes
            List<string> communicationTypes = new List<string> { "Facebook", "WhatsApp", "LinkedIn", "WeChat", "KakaoTalk", "Line", "Viber", "SnapChat", "Instagram", "Mobile", "Discord", "FTF" };

            Sql("SET IDENTITY_INSERT dbo.CommunicationTypes ON");
            for (int i = 0; i < communicationTypes.Count; i++)
            {
                Sql("INSERT INTO CommunicationTypes (Id,Name) VALUES (" + i + ",'" + communicationTypes[i] + "')");
            }
            Sql("SET IDENTITY_INSERT dbo.CommunicationTypes OFF");
            #endregion

            #region countries
            List<string> countries = new List<string> { "Australia", "Indonesia", "Philippines", "Germany", "New Zealand", "USA", "China", "Hong Kong", "Sth. Korea", "Sweden", "Spain", "Columbia", "Bangladesh", "Nepal", "Scotland", "Mexico", "France", "Canada", "Malaysia", "Singapore", "Belgium", "Norway", "Asia", "Thailand" };

            Sql("SET IDENTITY_INSERT dbo.Countries ON");
            for (int i = 0; i < countries.Count; i++)
            {
                Sql("INSERT INTO Countries (Id,Name) VALUES (" + i + ",'" + countries[i] + "')");
            }
            Sql("SET IDENTITY_INSERT dbo.Countries OFF");
            #endregion

            #region industries
            List<string> industries = new List<string> { "Hospitality","IT","Retail","Engineering","Finance/Accounting","Law","Science" };

            Sql("SET IDENTITY_INSERT dbo.Industries ON");
            for (int i = 0; i < industries.Count; i++)
            {
                Sql("INSERT INTO Industries (Id,Name) VALUES (" + i + ",'" + industries[i] + "')");
            }
            Sql("SET IDENTITY_INSERT dbo.Industries OFF");
            #endregion

            #region maritalStatus
            List<string> maritalStatus = new List<string> { "Single","Relationship","Married","Divorced","Widowed" };

            Sql("SET IDENTITY_INSERT dbo.MartialStatus ON");
            for (int i = 0; i < maritalStatus.Count; i++)
            {
                Sql("INSERT INTO MartialStatus (Id,Name) VALUES (" + i + ",'" + maritalStatus[i] + "')");
            }
            Sql("SET IDENTITY_INSERT dbo.MartialStatus OFF");
            #endregion

            //string[] occupations = new string[1] { "" };

            #region ageGroups
            List<string> ageGroups = new List<string> { "18-25","26-35","36-49","50+"};

            Sql("SET IDENTITY_INSERT dbo.AgeGroups ON");
            for (int i = 0; i < ageGroups.Count; i++)
            {
                Sql("INSERT INTO AgeGroups (Id,Name) VALUES (" + i + ",'" + ageGroups[i] + "')");
            }
            Sql("SET IDENTITY_INSERT dbo.AgeGroups OFF");
            #endregion

            #region reasons
            List<string> reasons = new List<string> {
                /*Reason*/ "International,Stopped_Replying,Unreachable/_Not_Active,No_Response,Not_Looking,Research_Required",
                /*Process*/ "OLB,MSAWA/DTM,MG1,MG2,MG2/BP,Team_Eval,FU1,FU2,FU3,Launch,Team",
                /*RTD*/ "Referral,Retail"
            };

            Sql("SET IDENTITY_INSERT dbo.Reasons ON");
            for (int i = 0; i < reasons.Count; i++)
            {
                Sql("INSERT INTO Reasons (Id,Name) VALUES (" + i + ",'" + reasons[i] + "')");
            }
            Sql("SET IDENTITY_INSERT dbo.Reasons OFF");
            #endregion

            /*#region statuses
            List<string> statuses = new List<string> { "Active", "On Hold", "Contact Coach", "Contact Later", "Process", "RTD", "Disqualified" };

            Sql("SET IDENTITY_INSERT dbo.Status ON");
            for (int i = 0; i < statuses.Count; i++)
            {
                Sql("INSERT INTO Status (Id,Name) VALUES (" + i + ",'" + statuses[i] + "')");
            }
            Sql("SET IDENTITY_INSERT dbo.Status OFF");
            #endregion*/
        }
        
        public override void Down()
        {
        }
    }
}
