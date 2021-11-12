using MyLinqLib;
using System.Collections.Generic;
using System.Globalization;

namespace LinqSelfProgrammed
{
  public class LinqQueries
  {
    #region ---------------------------------------------------- Data
    private readonly List<int> integers = new() { 5, 76, 3, 93, 143, 5, 11, 67, 5 };
    private readonly List<double> doubles = new() { 1.23, 68.256, 44.55, 96.127, 393.4567, 2.45, 4.1 };
    private readonly List<string> strings = new() { "Hansi", "Pauli", "Heinzi", "Susi", "Pepi" };
    public readonly List<Person> persons = new()
    {
      new Person { Firstname = "Hansi", Lastname = "Huber", Age = 66, Salary = 1513 },
      new Person { Firstname = "Heinzi", Lastname = "Prüller", Age = 77, Salary = 3100 },
      new Person { Firstname = "Susi", Lastname = "Maurer", Age = 55, Salary = 2460 },
      new Person { Firstname = "Gerti", Lastname = "Lehner", Age = 55, Salary = 2941 },
      new Person { Firstname = "Pauli", Lastname = "Huber", Age = 44, Salary = 1471 }
    };
    #endregion

    #region ---------------------------------------------------- Filters
    public IEnumerable<int> IntegersGT50()
    {
      
      return integers.Where(x => x > 50);
    }
    public IEnumerable<string> StringsWithLength4()
    {
      return strings.Where(x => x.Length == 4);
    }
    public IEnumerable<Person> PersonsWithSallaryGT2500()
    {
      return persons.Where(x => x.Salary > 2500);
    }
    public IEnumerable<double> DoublesTake4()
    {
      return doubles.Take(4);
    }
    public IEnumerable<Person> PersonsSkip2()
    {
      return persons.Skip(2);
    }
    public IEnumerable<int> IntegersTakeWhileLT100()
    {
      return integers.TakeWhile(x => x < 100);
    }
    public IEnumerable<string> StringsSkipWhileX1EQa()
    {
      return strings.SkipWhile(x => x[1] == 'a');
    }
    public IEnumerable<int> IntegersDistinct()
    {
      return integers.Distinct();
    }
    #endregion

    #region ---------------------------------------------------- Projection
    public IEnumerable<int> DoublesToInt()
    {
      return doubles.Select(x => (int)x);
    }
    public IEnumerable<string> StringsToUpper()
    {
      return strings.Select(x => x.ToUpper());
    }
    public IEnumerable<string> PersonsToLastnameSallary()
    {
      return persons.Select(x => $"{x.Lastname} --> {x.Salary}");
    }
    public IEnumerable<object> PersonsToAnonymous()
    {
      return persons.Select(x => new { Name = $"{x.Firstname} {x.Lastname}" });
    }
    #endregion

    #region ---------------------------------------------------- First/Last
    public double FirstDouble()
    {
      return doubles.First();
    }
    public Person FirstPersonAgeLT60()
    {
      return persons.First(x => x.Age < 60);
    }
    public double LastDouble()
    {
      return doubles.Last();
    }
    public int FirstOrDefaultIntGT1000()
    {
      return integers.FirstOrDefault(x => x > 1000);
    }
    #endregion

    #region ---------------------------------------------------- Aggregation
    public int AverageInt()
    {
      return integers.Average();
    }
    public double AverageDouble()
    {
      return doubles.Average();
    }
    public double AveragePersonSalary()
    {
      return persons.Average(x => x.Salary);
    }
    public int CountPersonsAgeGT60()
    {
      return persons.Count(x => x.Age > 60);
    }
    public int CountPersonsWithLastnameLengthGT5()
    {
      return persons.Count(x => x.Lastname.Length > 5);
    }
    #endregion

    #region ---------------------------------------------------- Sorting
    public IEnumerable<int> IntsSorted()
    {
      return integers.OrderBy(x => x);
    }
    public IEnumerable<double> DoublesSortedDescending()
    {
      return doubles.OrderByDescending(x => x);
    }
    public IEnumerable<Person> PersonsSortedDescendingBySalary()
    {
      return persons.OrderByDescending(x => x.Salary);
    }
    public IEnumerable<string> PersonFirstnamesSortedDescendingBySalary()
    {
      return persons.OrderByDescending(x => x.Salary).Select(x => x.Firstname);
    }
    #endregion

    #region ---------------------------------------------------- Combined
    public IEnumerable<string> CombinedA()
    {
      return persons
      .Where(x => x.Age < 70)
      .Skip(1)
      .Take(2)
      .Select(x => $"{x.Firstname} {x.Lastname}");
    }
    public IEnumerable<double> CombinedB()
    {
      CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
      return doubles
      .Select(x => $"{x}".Split('.'))
      .Where(x => x[1].Length > 2)
      .Where(x => int.Parse(x[0]) % 2 == 0)
      .Select(x => string.Join(".", x))
      .Select(x => double.Parse(x));
    }
    #endregion

  }
}
