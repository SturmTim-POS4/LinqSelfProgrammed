using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace LinqTests
{
  public class LinqT2_Projection : LinqTestsBase
  {
    [Fact] public void T2_01_DoublesToInt() => queries.DoublesToInt().Should().BeEquivalentTo(new List<int>() { 1, 68, 44, 96, 393, 2, 4 });
    [Fact] public void T2_02_StringsToUpper() => queries.StringsToUpper().Should().BeEquivalentTo(new List<string>() { "HANSI", "PAULI", "HEINZI", "SUSI", "PEPI" });
    [Fact] public void T2_03_PersonsToLastnameSallary() => queries.PersonsToLastnameSallary().Should().BeEquivalentTo(new List<string>() { "Huber --> 1513", "Prüller --> 3100", "Maurer --> 2460", "Lehner --> 2941", "Huber --> 1471" });
    [Fact] public void T2_04_PersonsToAnonymous() => queries.PersonsToAnonymous().Should().BeEquivalentTo(new List<object>() { new { Name = "Hansi Huber" }, new { Name = "Heinzi Prüller" }, new { Name = "Susi Maurer" }, new { Name = "Gerti Lehner" }, new { Name = "Pauli Huber" } });
  }
}
