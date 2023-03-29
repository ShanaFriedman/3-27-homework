using System.Data.SqlClient;

namespace March_27_homework.Data
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    public class PeopleManager
    {
        private string _connectionString;
        public PeopleManager(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Person> GetPeople()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM PeopleTable";
            List<Person> people = new List<Person>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                people.Add(new()
                {
                    Id = (int)reader["id"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"]
                });
            }
            return people;
        }
        public void AddPerson(Person p)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO PeopleTable VALUES(@firstName, @lastName, @age)";
            command.Parameters.AddWithValue("@firstName", p.FirstName);
            command.Parameters.AddWithValue("@lastName", p.LastName);
            command.Parameters.AddWithValue("@age", p.Age);
            connection.Open();
            command.ExecuteNonQuery();
        }

        public void AddManyPeople(List<Person> people)
        {
            foreach (Person p in people)
            {
                AddPerson(p);
            }
        }
    }
}