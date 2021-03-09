using System;

namespace Delegat {
    internal class Students {
        private Student[] _students;
        public int Length { get; private set; }

        public Students(int size) {
            _students = new Student[size];
            Length = 0;
        }

        public delegate bool CompareStudents(Student firstStudent, Student secondStudent);

        public void Push(Student student) {
            if (student == null) {
                throw new ArgumentNullException(nameof(student), "Student can not be null.");
            }

            if (Length >= _students.Length) {
                Student[] temp = new Student[_students.Length + 5];
                for (int i = 0; i < _students.Length; i++) {
                    temp[i] = _students[i];
                }

                _students = temp;
            }

            _students[Length++] = student;
        }

        

        public Student this[int position] {
            get {
                if (position < 0 || position >= Length) {
                    throw new ArgumentOutOfRangeException(nameof(position), "Position is out of range.");
                }

                return _students[position];
            }
            set {
                if (position < 0 || position > Length) {
                    throw new ArgumentOutOfRangeException(nameof(position), "Position is out of range.");
                }

                if (position == Length) {
                    _students[Length++] = value;
                }
                else {
                    _students[position] = value;
                }
            }
        }

        public void Sort(CompareStudents compareStudents) {
            if (Length == 0) {
                return;
            }

            bool swapped = true;
            int start = 0;
            int end = Length;

            while (swapped) {
                swapped = false;

                for (int i = start; i < end - 1; ++i) {
                    swapped = IsSwapped(compareStudents, swapped, i);
                }

                if (!swapped)
                    break;

                swapped = false;
                end -= 1;

                for (int i = end - 1; i >= start; i--) {
                    swapped = IsSwapped(compareStudents, swapped, i);
                }

                start += 1;
            }
        }

        private bool IsSwapped(CompareStudents compareStudents, bool swapped, int i) {
            if (compareStudents(_students[i], _students[i + 1])) {
                var temp = _students[i];
                _students[i] = _students[i + 1];
                _students[i + 1] = temp;
                swapped = true;
            }

            return swapped;
        }
    }
}