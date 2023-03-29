using MicrosservicosDotnet.Model;

namespace MicrosservicosDotnet.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(int id)
        {
            return;
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for(int i = 1; i < 9; i++){
                persons.Add(new Person{
                    Id = i,
                    FirstName = "Felipe",
                    LastName = "Sobrenome",
                    Address = "Rua",
                    Gender = "Male"

                });
            }

            return persons;
        }

        public Person FindById(int id)
        {
            return new Person{
                Id = 1,
                FirstName = "Felipe",
                LastName = "Cazotti",
                Address = "BH",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}