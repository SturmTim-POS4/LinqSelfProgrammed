using LinqSelfProgrammed;
using System.Collections.Generic;

namespace LinqTests
{
  public class LinqTestsBase
  {
    protected readonly LinqQueries queries = new();
    protected readonly List<Person> persons;

    public LinqTestsBase()
    {
      persons = queries.persons;
    }

  }
}
