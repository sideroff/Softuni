namespace _03_Company_Hierarchy.Persons
{
    public interface IEmployee
    {
        uint Salary { get; set; }
        Departments Department { get; set; }

    }
}