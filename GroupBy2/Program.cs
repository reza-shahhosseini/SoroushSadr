using System;
using System.Linq;
using System.Collections.Generic;
namespace GroupBy2
{
    class Program
    {

        private static List<Student> _students = new List<Student>(){
            new Student{Id=1,Firstname="Reza",Lastname="Shahhosseini",Gender=Gender.Male,StudyField=StudyField.ComputerEngineering,BirthDate=new DateTime(),MarriageStatus=MarriageStatus.Single},
            new Student{Id=2,Firstname="Sara",Lastname="Mehrabi",Gender=Gender.Female,StudyField=StudyField.ComputerScience,BirthDate=new DateTime(),MarriageStatus=MarriageStatus.Married},
            new Student{Id=3,Firstname="Moslem",Lastname="Arefi",Gender=Gender.Male,StudyField=StudyField.ComputerEngineering,BirthDate=new DateTime(),MarriageStatus=MarriageStatus.Married},
            new Student{Id=4,Firstname="Mina",Lastname="Salemi",Gender=Gender.Female,StudyField=StudyField.ElectronicsEngineering,BirthDate=new DateTime(),MarriageStatus=MarriageStatus.Single},
            new Student{Id=5,Firstname="Farshid",Lastname="Hamzei",Gender=Gender.Male,StudyField=StudyField.Physics,BirthDate=new DateTime(),MarriageStatus=MarriageStatus.Divorced},
            new Student{Id=6,Firstname="Roya",Lastname="Izadi",Gender=Gender.Female,StudyField=StudyField.ComputerScience,BirthDate=new DateTime(),MarriageStatus=MarriageStatus.Engaged},
        };
        static void Main(string[] args)
        {
            //GroupByGender();
            //GroupByStudyField();
            GroupByMarriageStatus();
        }

        private static void GroupByGender(){
            var query = from std in _students
            group std by std.Gender into genderGroup
            select new {
                GroupKey = genderGroup.Key,
                GroupItems = genderGroup,
                GroupItemsCount = genderGroup.Count()
            };

            foreach(var group in query){
                Console.WriteLine($"{group.GroupKey} students : ");
                foreach(Student std in group.GroupItems){
                    Console.WriteLine(std);
                }
            }
            
        }

        private static void GroupByStudyField(){
            var query = from student in _students 
            group student by student.StudyField into studyFieldGroup 
            select new {
                GroupKey = studyFieldGroup.Key,
                GroupItems = studyFieldGroup,
                GroupItemsCount = studyFieldGroup.Count(),
            };

            foreach(var group in query){
                Console.WriteLine($"Students who study {group.GroupKey} :");
                foreach(Student student in group.GroupItems){
                    Console.WriteLine(student);
                }
            }
        }


        private static void GroupByMarriageStatus(){
            var query = from student in _students
            group student by student.MarriageStatus into marriageStatusGroup
            select new {
                GroupKey = marriageStatusGroup.Key,
                GroupItems = marriageStatusGroup,
                GroupItemsCount = marriageStatusGroup.Count()
            };

            foreach(var group in query){
                Console.WriteLine($"{group.GroupKey} students are:");
                foreach(Student student in group.GroupItems){
                    Console.WriteLine(student);
                }
            }
        }
    }
}
