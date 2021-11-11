using FluentAssertions;
using Xunit;

namespace LinqTests
{
  public class LinqT3_FirstLast : LinqTestsBase
  {
    [Fact] public void T3_01_FirstDouble() => queries.FirstDouble().Should().Be(1.23);
    [Fact] public void T3_02_FirstPersonAgeLT60() => queries.FirstPersonAgeLT60().Should().BeEquivalentTo(persons[2]);
    [Fact] public void T3_03_LastDouble() => queries.LastDouble().Should().Be(4.1);
    [Fact] public void T3_04_FirstOrDefaultIntGT1000() => queries.FirstOrDefaultIntGT1000().Should().Be(default(int));
  }
}
