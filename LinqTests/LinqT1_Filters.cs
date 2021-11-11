using FluentAssertions;
using LinqSelfProgrammed;
using System.Collections.Generic;
using Xunit;

namespace LinqTests
{
  public class LinqT1_Filters : LinqTestsBase
  {
    [Fact] public void T1_01_IntegersGT50() => queries.IntegersGT50().Should().BeEquivalentTo(new List<int>() { 76, 93, 143, 67 });
    [Fact] public void T1_02_StringsWithLength4() => queries.StringsWithLength4().Should().BeEquivalentTo(new List<string>() { "Susi", "Pepi" });
    [Fact] public void T1_03_PersonsWithSallaryGT2500() => queries.PersonsWithSallaryGT2500().Should().BeEquivalentTo(new List<Person>() { persons[1], persons[3] });
    [Fact] public void T1_04_DoublesTake4() => queries.DoublesTake4().Should().BeEquivalentTo(new List<double>() { 1.23, 68.256, 44.55, 96.127 });
    [Fact] public void T1_05_PersonsSkip2() => queries.PersonsSkip2().Should().BeEquivalentTo(new List<Person>() { persons[2], persons[3], persons[4] });
    [Fact] public void T1_06_IntegersTakeWhileLT100() => queries.IntegersTakeWhileLT100().Should().BeEquivalentTo(new List<int>() { 5, 76, 3, 93 });
    [Fact] public void T1_07_StringsSkipWhileX1EQa() => queries.StringsSkipWhileX1EQa().Should().BeEquivalentTo(new List<string>() { "Heinzi", "Susi", "Pepi" });
    [Fact] public void T1_08_IntegersDistinct() => queries.IntegersDistinct().Should().BeEquivalentTo(new List<int>() { 5, 76, 3, 93, 143, 11, 67 });
  }
}
