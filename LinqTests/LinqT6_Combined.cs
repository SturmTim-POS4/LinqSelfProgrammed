using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace LinqTests
{
  public class LinqT6_Combined : LinqTestsBase
  {
    [Fact] public void T6_01_CombinedA() => queries.CombinedA().Should().BeEquivalentTo(new List<string>() { "Susi Maurer", "Gerti Lehner" });
    [Fact] public void T6_02_CombinedB() => queries.CombinedB().Should().BeEquivalentTo(new List<double>() { 68.256, 96.127 });
  }
}
