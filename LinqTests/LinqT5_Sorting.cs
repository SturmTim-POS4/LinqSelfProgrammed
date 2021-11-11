using FluentAssertions;
using LinqSelfProgrammed;
using System.Collections.Generic;
using Xunit;

namespace LinqTests
{
  public class LinqT5_Sorting : LinqTestsBase
  {
    [Fact] public void T5_01_IntsSorted() => queries.IntsSorted().Should().BeEquivalentTo(new List<int>() { 3, 5, 5, 5, 11, 67, 76, 93, 143 });
    [Fact] public void T5_02_DoublesSortedDescending() => queries.DoublesSortedDescending().Should().BeEquivalentTo(new List<double>() { 393.4567, 96.127, 68.256, 44.55, 4.1, 2.45, 1.23 });
    [Fact] public void T5_03_PersonsSortedDescendingBySalary() => queries.PersonsSortedDescendingBySalary().Should().BeEquivalentTo(new List<Person>() { persons[1], persons[3], persons[2], persons[0], persons[4] });
    [Fact] public void T5_04_PersonFirstnamesSortedDescendingBySalary() => queries.PersonFirstnamesSortedDescendingBySalary().Should().BeEquivalentTo(new List<string>() { "Heinzi", "Gerti", "Susi", "Hansi", "Pauli" });

  }
}
