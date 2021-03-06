namespace Delegat {
    public class Student {
        public string Name { get; set; }
        public int Id { get; set; }
        public Faculty Faculty { get; set; }

        public Student() {
            
        }

        public Student(string name, int id, Faculty faculty) {
            Name = name;
            Id = id;
            Faculty = faculty;
        }

        public override string ToString() {
            return $"ID: {Id}, Name: {Name}, Faculty: {Faculty}";
        }
    }

    public enum Faculty {
        FES, FF, FEI, FCHT
    }
}