using System;
namespace GroupBy2{
    internal class Student{
        public int Id{get;set;}
        public string Firstname{get;set;}
        public string Lastname{get;set;}
        public Gender Gender {get;set;}
        public StudyField StudyField{get;set;}
        public DateTime BirthDate{get;set;}
        public MarriageStatus MarriageStatus{get;set;}



        public override string ToString() => $"{Firstname} {Lastname}";
    }
}