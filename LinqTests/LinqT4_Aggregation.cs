using FluentAssertions;
using Xunit;

namespace LinqTests
{
  public class LinqT4_Aggregation : LinqTestsBase
  {
    [Fact] public void T4_01_AverageInt() => queries.AverageInt().Should().Be(45);
    [Fact] public void T4_02_AverageDouble() => queries.AverageDouble().Should().BeApproximately(87.1671, 0.001);
    [Fact] public void T4_03_AveragePersonSalary() => queries.AveragePersonSalary().Should().Be(2297);
    [Fact] public void T4_04_CountPersonsAgeGT60() => queries.CountPersonsAgeGT60().Should().Be(2);
    [Fact] public void T4_05_CountPersonsWithLastnameLengthGT5() => queries.CountPersonsWithLastnameLengthGT5().Should().Be(3);
  }
}
