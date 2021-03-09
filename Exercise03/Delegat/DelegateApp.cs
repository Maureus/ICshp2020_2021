using System;

namespace Delegat {
    internal sealed class DelegateApp {
        private Students _students;

        private const string Menu = @"App menu:
1 -> Generate 10 random students 
2 -> Print students to console 
3 -> Sort students by id 
4 -> Sort students by name 
5 -> Sort students by faculty 
6 -> Print menu
0 -> Exit ";

        public DelegateApp() {
            _students = new Students(10);
        }

        public void Run() {
            PrintMenu();
            while (true) {
                Console.Write("Please press key of command you want to run: ");
                var input = Console.ReadKey();
                Console.WriteLine();
                switch (input.KeyChar) {
                    case '1':
                        GenerateTenRandomStudents();
                        break;
                    case '2':
                        PrintStudentsToConsole();
                        break;
                    case '3':
                        SortStudents(SortBy.Id);
                        break;
                    case '4':
                        SortStudents(SortBy.Name);
                        break;
                    case '5':
                        SortStudents(SortBy.Faculty);
                        break;
                    case '6':
                        PrintMenu();
                        break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("Wrong input! Please try again.");
                        break;
                }
            }
        }

        private void SortStudents(SortBy attribute) {
            if (attribute == SortBy.Faculty) {
                _students.Sort(CompareStudentsByFaculties);
            }
            else if (attribute == SortBy.Id) {
                _students.Sort(CompareStudentsByIds);
            }
            else if (attribute == SortBy.Name) {
                _students.Sort(CompareStudentsByNames);
            }
        }

        private void PrintStudentsToConsole() {
            for (int i = 0; i < _students.Length; i++) {
                Console.WriteLine(_students[i].ToString());
            }
        }

        private bool CompareStudentsByFaculties(Student firstStudent, Student secondStudent) {
            return string.CompareOrdinal(firstStudent.Faculty.ToString(), secondStudent.Faculty.ToString()) > 0;
        }

        private bool CompareStudentsByIds(Student firstStudent, Student secondStudent) {
            return firstStudent.Id > secondStudent.Id;
        }

        private bool CompareStudentsByNames(Student firstStudent, Student secondStudent) {
            return string.CompareOrdinal(firstStudent.Name, secondStudent.Name) > 0;
        }

        private void GenerateTenRandomStudents() {
            Random random = new Random();
            for (var i = 0; i < 10; i++) {
                var randInt = random.Next(1, 100000);
                _students.Push(new Student
                    {Faculty = (Faculty) random.Next(1, 4), Id = randInt, Name = $"Student{randInt}"});
            }
        }

        private void PrintMenu() {
            Console.WriteLine(Menu);
        }

        private enum SortBy {
            Id,
            Name,
            Faculty
        }
    }
}