namespace LinqSelfProgrammed
{
  public class Person
  {
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public int Age { get; set; }
    public int Salary { get; set; }

    public override string ToString() =>  $"{Firstname} {Lastname} - {Age} / {Salary}";

  }
}
