using System;
using System.Collections.Generic;
using System.Linq;

using Wintellect.PowerCollections;

public class PersonCollection : IPersonCollection
{
    private Dictionary<string, Person> peopleByEmail;
    private Dictionary<string, SortedDictionary<string, Person>> peopleByDomain;
    private Dictionary<string, SortedDictionary<string, Person>> peopleByNameAndTown;
    private OrderedDictionary<int, SortedDictionary<string, Person>> peopleByAge;
    private Dictionary<string, OrderedDictionary<int, SortedDictionary<string, Person>>>
        peopleByTownThenByAge;

    public PersonCollection()
    {
        this.peopleByEmail = new Dictionary<string, Person>();
        this.peopleByDomain = new Dictionary<string, SortedDictionary<string, Person>>();
        this.peopleByNameAndTown = new Dictionary<string, SortedDictionary<string, Person>>();
        this.peopleByAge = new OrderedDictionary<int, SortedDictionary<string, Person>>();
        this.peopleByTownThenByAge = new Dictionary<string, OrderedDictionary<int, SortedDictionary<string, Person>>>();
    }
    public bool AddPerson(string email, string name, int age, string town)
    {
        if (this.peopleByEmail.ContainsKey(email))
        {
            return false;
        }
        Person newPerson = new Person(email, name, age, town);
        this.peopleByEmail[email] = newPerson; //<- Email add


        string domain = email.Split('@')[1];
        if (!this.peopleByDomain.ContainsKey(domain))
        {
            this.peopleByDomain[domain] = new SortedDictionary<string, Person>();
        }
        this.peopleByDomain[domain][email] = newPerson;  //<- Domain add


        string nameTownConc = name + town;
        if (!this.peopleByNameAndTown.ContainsKey(nameTownConc))
        {
            this.peopleByNameAndTown[nameTownConc] = new SortedDictionary<string, Person>();
        }
        this.peopleByNameAndTown[nameTownConc][email] = newPerson; //<- NameTown add


        if (!this.peopleByAge.ContainsKey(age))
        {
            this.peopleByAge[age] = new SortedDictionary<string, Person>();
        }
        this.peopleByAge[age][email] = newPerson; //<- byAge add


        if (!this.peopleByTownThenByAge.ContainsKey(town))
        {
            this.peopleByTownThenByAge[town] = new OrderedDictionary<int, SortedDictionary<string, Person>>();
        }
        if (!this.peopleByTownThenByAge[town].ContainsKey(age))
        {
            this.peopleByTownThenByAge[town][age] = new SortedDictionary<string, Person>();
        }
        this.peopleByTownThenByAge[town][age][email] = newPerson; //<- TownThenAge add
        

        return true;
    }

    public int Count
    {
        get
        {
            return this.peopleByEmail.Count;
        }
    }

    public Person FindPerson(string email)
    {
        if (this.peopleByEmail.ContainsKey(email))
        {
            return this.peopleByEmail[email];
        }
        return null;
    }

    public bool DeletePerson(string email)
    {
        Person forDeletion = null;
        if (this.peopleByEmail.ContainsKey(email))
        {
            forDeletion = this.peopleByEmail[email];
            string domain = email.Split('@')[1];
            string nameAndTown = forDeletion.Name + forDeletion.Town;
            int age = forDeletion.Age;
            string town = forDeletion.Town;

            this.peopleByEmail.Remove(email); //by email removal

            this.peopleByDomain[domain].Remove(email);
            if (this.peopleByDomain[domain].Count == 0)
            {
                this.peopleByDomain.Remove(domain);
            }                           //by domain removal and domain removal if necessary

            this.peopleByNameAndTown[nameAndTown].Remove(email);
            if (this.peopleByNameAndTown[nameAndTown].Count == 0)
            {
                this.peopleByNameAndTown.Remove(nameAndTown);
            }                           //by nameAndTown removal and nameAndTown removal if necessary

            this.peopleByAge[age].Remove(email);
            if (this.peopleByAge[age].Count == 0)
            {
                this.peopleByAge.Remove(age);
            }                           //by age removal and age removal if necessary


            this.peopleByTownThenByAge[town][age].Remove(email);
            if (this.peopleByTownThenByAge[town][age].Count == 0)
            {
                this.peopleByTownThenByAge[town].Remove(age);
                if (this.peopleByTownThenByAge[town].Count == 0)
                {
                    this.peopleByTownThenByAge.Remove(town);
                }
            }                           //by town and age removal and age removal if necessary and town removal if necessary
            

            return true;
        }
        return false;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        if (this.peopleByDomain.ContainsKey(emailDomain))
        {
            return this.peopleByDomain[emailDomain].Values;
        }
        return new Person[0];
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        if (this.peopleByNameAndTown.ContainsKey(name + town))
        {
            return this.peopleByNameAndTown[name + town].Values;
        }
        return new Person[0];
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        var collection = this.peopleByAge.Range(startAge, true, endAge, true).SelectMany(c=>c.Value.Values);
        return collection;
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        if (this.peopleByTownThenByAge.ContainsKey(town))
        {
            return
                this.peopleByTownThenByAge[town].Range(startAge, true, endAge, true)
                    .SelectMany(c => c.Value.Values);
        }
        return new Person[0];
    }
}

