using System;

namespace ModelMVC.Models
{
    public class User{
        public string Username{get;set;}
        public string Password{get;set;}
        public int RollId{get;set;}

        public User(string Username, string Password, int RollId){
            this.Username = Username;
            this.Password = Password;
            this.RollId = RollId;
        }
        public User(string Username, string Password){
            this.Username = Username;
            this.Password = Password;
        }
    }

    public class Role{
        public int RollId{get;set;}
        public string RollName{get;set;}
        public Role(int RollId, string RollName){
            this.RollId = RollId;
            this.RollName = RollName;
        }
    }
}   